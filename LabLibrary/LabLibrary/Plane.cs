﻿namespace LabLibrary
{
    abstract public class Plane: ICommunicaion
    {
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
                destination = char.ToUpper(value[0]) + value.Substring(1);
            }
        }
        abstract public string FlightId { get; set; }
        public string CompanyName { get; set; }
        public DateTime DepartureDateTime {
            get => departureDateTime;
            set {
                departureDateTime = value.DayOfWeek == DayOfWeek.Saturday ? value.AddDays(2) : value.DayOfWeek == DayOfWeek.Sunday ? value.AddDays(1) : value;
            }
        }
        public int FlightPrice {
            get => flightPrice;
            set {
                flightPrice = Math.Max(value, 100);
            }
        }
        public string Name { get => "Рейс " + FlightId; }
        private string receivedMessages = "";
        public virtual string Serialized {
            get => FlightId + "\n" + CompanyName + "\n" + Destination + "\n" + DepartureDateTime.ToString() + "\n" + FlightPrice + "\n" + photoFile;
        }

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

        public Plane(string flightId, string companyName, string destination, DateTime dateTime, int price, string photo)
        {
            this.Destination = destination;
            this.FlightId = flightId;
            this.CompanyName = companyName;
            this.DepartureDateTime = dateTime;
            this.FlightPrice = price;
            this.photoFile = photo;
        }
        public Plane(string destination, DateTime dateTime, int price, string photo)
        {
            this.Destination = destination;
            this.FlightId = destination + "_" + dateTime.ToString();
            this.CompanyName = "Air company";
            this.DepartureDateTime = dateTime;
            this.FlightPrice = price;
            this.photoFile = photo;
        }
        public void OnAddToAirport(Airport airport)
        {
            airport.ReceiveMessage(this, "Прибыл в аэропорт");
        }

        public void ShowPhoto(PictureBox box) {
            Graphics g = Graphics.FromHwnd(box.Handle);
            g.DrawImage(Image.FromFile(this.photoFile), new Rectangle(0, 0, box.Width, box.Height));
        }

        public void ShowPhoto(Form box)
        {
            Graphics g = Graphics.FromHwnd(box.Handle);
            g.DrawImage(Image.FromFile(this.photoFile), new Rectangle(0, 0, box.Width, box.Height));
        }

        public void DaysToDeparture(out int result) {
            result = (this.DepartureDateTime - DateTime.Now).Days;
        }

        public abstract string GetPlaneSpecText();

        public override string ToString()
        {
            return this.FlightId;
        }

        public void DrawFlightId(PictureBox box, Font font)
        {
            Graphics g = Graphics.FromHwnd(box.Handle);
            g.Clear(SystemColors.Control);
            g.DrawString(FlightId, font, Brushes.Red, 1, 1);
        }
        public void ReceiveMessage(ICommunicaion sender, string message)
        {
            receivedMessages += "Сообщение от \"" + sender.Name + "\": " + message + "\n";
        }
    }
}
