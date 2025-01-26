namespace LabLibrary
{
    // абстрактный класс для всех самолетов
    abstract public class Plane: ICommunicaion
    {
        // тип самолета, переопределяется в наследнике
        virtual public string Type
        {
            get => "";
            set { }
        }
        private string destination;
        private DateTime departureDateTime;
        private int flightPrice;
        protected string photoFile;

        public string Destination {
            get => destination;
            set {
                // первая буква пункта назначения - заглавная
                destination = char.ToUpper(value[0]) + value.Substring(1);
            }
        }
        abstract public string FlightId { get; set; }
        public string CompanyName { get; set; }
        public DateTime DepartureDateTime {
            get => departureDateTime;
            set {
                // если день отправления - сб или вс - перенос на пн
                departureDateTime = value.DayOfWeek == DayOfWeek.Saturday ? value.AddDays(2) : value.DayOfWeek == DayOfWeek.Sunday ? value.AddDays(1) : value;
            }
        }
        public int FlightPrice {
            get => flightPrice;
            set {
                // минимальная цена - 100
                flightPrice = Math.Max(value, 100);
            }
        }
        // свойство из интерфейса ICommunication
        public string Name { get => "Рейс " + FlightId; }
        // полученные самолетом сообщения
        private string receivedMessages = "";
        // свойство для записи в файл
        public virtual string Serialized {
            get => FlightId + "\n" + CompanyName + "\n" + Destination + "\n" + DepartureDateTime.ToString() + "\n" + FlightPrice + "\n" + photoFile;
        }

        // возвращает текст для вывода в UI
        public virtual string GetText(bool isShowDaysToDeparture = true)
        {
            string daysLeftText = "";

            if (isShowDaysToDeparture) {
                this.DaysToDeparture(out int daysLeft);
                daysLeftText = " (осталось " + daysLeft + " д.)" ;
            }

            return String.Format("Рейс \"{0}\" компании \"{1}\":\nПункт назначения: {2}\nДата и время отправления: {3}{4}\nСтоимость: {5}\nПолученные сообщения:\n{6}",
                FlightId, CompanyName, Destination, DepartureDateTime.ToString(), daysLeftText, FlightPrice, receivedMessages);
        }

        // конструктор со всеми полями
        public Plane(string flightId, string companyName, string destination, DateTime dateTime, int price, string photo)
        {
            this.Destination = destination;
            this.FlightId = flightId;
            this.CompanyName = companyName;
            this.DepartureDateTime = dateTime;
            this.FlightPrice = price;
            this.photoFile = photo;
        }
        // перегруженный конструктор, FlightId и CompanyName генерируются автоматически
        public Plane(string destination, DateTime dateTime, int price, string photo)
        {
            this.Destination = destination;
            this.FlightId = destination + "_" + dateTime.ToString();
            this.CompanyName = "Air company";
            this.DepartureDateTime = dateTime;
            this.FlightPrice = price;
            this.photoFile = photo;
        }
        // вызывается при добавлении в аэропорт
        public void OnAddToAirport(Airport airport)
        {
            airport.ReceiveMessage(this, "Прибыл в аэропорт");
        }

        //перегруженные методы вывода фото
        public void ShowPhoto(PictureBox box) {
            Graphics g = Graphics.FromHwnd(box.Handle);
            g.DrawImage(Image.FromFile(this.photoFile), new Rectangle(0, 0, box.Width, box.Height));
        }

        public void ShowPhoto(Form box)
        {
            Graphics g = Graphics.FromHwnd(box.Handle);
            g.DrawImage(Image.FromFile(this.photoFile), new Rectangle(0, 0, box.Width, box.Height));
        }
        
        // возвращает количество дней до отправления
        public void DaysToDeparture(out int result) {
            result = (this.DepartureDateTime - DateTime.Now).Days;
        }

        // возвращет текст спецификации самолета
        public abstract string GetPlaneSpecText();

        // преобразованиее Plane к строке возвращает FlightId
        public override string ToString()
        {
            return this.FlightId;
        }

        // отрисовывает FlightId в переданном PictureBox
        public void DrawFlightId(PictureBox box, Font font)
        {
            Graphics g = Graphics.FromHwnd(box.Handle);
            g.Clear(SystemColors.Control);
            g.DrawString(FlightId, font, Brushes.Red, 1, 1);
        }

        // метод из ICommunication
        public void ReceiveMessage(ICommunicaion sender, string message)
        {
            receivedMessages += "Сообщение от \"" + sender.Name + "\": " + message + "\n";
        }
    }
}
