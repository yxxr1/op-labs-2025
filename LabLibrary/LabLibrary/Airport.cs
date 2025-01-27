namespace LabLibrary
{
    public class Airport: ICommunication
    {
        // свойство из интерфейса ICommunication
        public string Name { get => "Airport"; }

        // коллекция самолетов
        public List<Plane> Planes = new List<Plane>();

        // индексатор по индексу в коллекции самолетов
        public Plane this[int index]
        {
            get => Planes[index];
            set
            {
                if (index < Planes.Count)
                {
                    Plane oldPlane = Planes[index];
                    Planes.Insert(index, value);
                    value.OnAddToAirport(this);
                    // отправка сообщения самолету с количеством самолетов в аэропорту
                    value.ReceiveMessage(this, "Самолетов в аэропорту: " + Planes.Count);
                    // вызов события
                    Event.Invoke("Рейс " + oldPlane.FlightId + " был перезаписан рейсом " + value.FlightId);
                }
            }
        }

        // индексатор по flightId в коллекции самолетов
        public Plane? this[string flightId]
        {
            get
            {
                for (int i = 0; i < this.Planes.Count; i++)
                {
                    if (Planes[i].FlightId == flightId)
                    {
                        // возвращает самолет с указанным flightId
                        return this.Planes[i];
                    }
                }

                return null;
            }
            set
            {
                if (value != null)
                {
                    for (int i = 0; i < this.Planes.Count; i++)
                    {
                        if (Planes[i].FlightId == flightId)
                        {
                            // замена самолета с указанным flightId
                            this.Planes[i] = value;
                            // вызов метода самолета на добавление в аэропорт
                            value.OnAddToAirport(this);
                            // отправка сообщения самолету с количеством самолетов в аэропорту
                            value.ReceiveMessage(this, "Самолетов в аэропорту: " + Planes.Count);
                            // вызов события
                            Event.Invoke("Рейс " + flightId + " был перезаписан рейсом " + value.FlightId);
                            return;
                        }
                    }

                    // вызов события - рейс не найден
                    Event.Invoke("Не удалось перезаписать рейс " + flightId + ", т.к. он не существует");
                }
            }
        }

        // цвет для вывода в UI
        public static readonly Color OutputColor;

        public List<string> ReceivedMessages { get; private set; }

        // статический конструктор инициализирует OutputColor в зависимости от дня недели
        static Airport()
        {
            DateTime now = DateTime.Now;

            if (now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday)
            {
                Airport.OutputColor = Color.Red;
            }
            else
            {
                Airport.OutputColor = Color.Green;
            }
        }
        public Airport()
        {
            ReceivedMessages = new List<string>();
        }

        // метод добавления самолета в аэропорт
        public void AddPlane(Plane plane)
        {
            Planes.Add(plane);
            Event.Invoke("Рейс \"" + plane.FlightId + "\" добавлен в аэропорт " + Name);
            plane.OnAddToAirport(this);
            plane.ReceiveMessage(this, "Самолетов в аэропорту: " + Planes.Count);
        }

        // метод чтения сохраненных данных изщ файла
        public void ReadFromFile(OpenFileDialog dialog)
        {
            // выбор файла
            if (dialog.ShowDialog() != DialogResult.Cancel) {
                this.Planes.Clear();
                StreamReader reader = new StreamReader(dialog.FileName);
                Event.Invoke("Данные рейсов загружаются из файла " + dialog.FileName);

                // чтение до конца файла
                while (!reader.EndOfStream) {
                    // каждая строка - поле самолета
                    string? flightId = reader.ReadLine();
                    string? companyName = reader.ReadLine();
                    string? destination = reader.ReadLine();
                    string? dateTime = reader.ReadLine();
                    string? price = reader.ReadLine();
                    string? photo = reader.ReadLine();
                    string? type = reader.ReadLine();
                    string? spec = reader.ReadLine();

                    if (type != null && flightId != null && companyName != null && destination != null && dateTime != null && price != null && spec != null && photo != null) {
                        // выбор класса самолета в зависимости от типа
                        if (type == "Passenger")
                        {
                            PassengerPlane plane = new PassengerPlane(flightId, companyName, destination, DateTime.Parse(dateTime), Int32.Parse(price), Int32.Parse(spec), photo);
                            this.AddPlane(plane);
                        } else if (type == "Cargo")
                        {
                            CargoPlane plane = new CargoPlane(flightId, companyName, destination, DateTime.Parse(dateTime), Int32.Parse(price), Int32.Parse(spec), photo);
                            this.AddPlane(plane);
                        }
                    }
                }
                
                reader.Close();

                Event.Invoke("Конец загрузки из файла");
            }
        }

        // перегруженный метод записи данных приложения в файл
        public void WriteToFile(SaveFileDialog dialog)
        {
            if (dialog.ShowDialog() != DialogResult.Cancel)
            {
                StreamWriter writer = new StreamWriter(dialog.FileName);

                for (int i = 0; i < this.Planes.Count; i++) {
                    // в файл записывается свойство Serialized объекта
                    writer.WriteLine(this.Planes[i].Serialized);
                }

                writer.Close();

                // вызов события
                Event.Invoke("Данные аэропорта " + Name + " выгружены в файл " + dialog.FileName);
            }
        }

        // версия, принимающая имя файла как строку
        public void WriteToFile(string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);

            for (int i = 0; i < this.Planes.Count; i++)
            {
                writer.WriteLine(this.Planes[i].Serialized);
            }

            writer.Close();

            Event.Invoke("Данные аэропорта " + Name + " выгружены в файл " + fileName);
        }

        // перегруженный метод для получения текста по всем рейсам в аэропорту
        public void GetText(ref string text)
        {
            for (int i = 0; i < this.Planes.Count; i++)
            {
                Plane plane = this.Planes[i];
                text += plane.GetText() + "\n\n";
            }
        }

        // версия метода с поиском по рейсам
        public void GetText(ref string text, SearchParams searchParams)
        {
            for (int i = 0; i < this.Planes.Count; i++)
            {
                Plane plane = this.Planes[i];
                bool checkFlightId = searchParams.flightId == "" || plane.FlightId == searchParams.flightId;
                bool checkDateTime = plane.DepartureDateTime.CompareTo(searchParams.dateTime) > 0;
                bool checkDestination = searchParams.destination == "" || plane.Destination == searchParams.destination;

                if (checkFlightId && checkDateTime && checkDestination)
                {
                    text += plane.GetText() + "\n\n";
                }
            }
        }

        // события аэропорта
        public delegate void AirportEvent(string message);
        public event AirportEvent Event;

        // метод из ICommunication
        public void ReceiveMessage(ICommunication sender, string message)
        {
            string messageText = "Получено сообщение от \"" + sender.Name + "\": " + message;
            Event.Invoke(messageText);
            ReceivedMessages.Add(messageText);
        }
    }
}
