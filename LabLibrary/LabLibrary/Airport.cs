﻿using System.Drawing;
using System.Numerics;

namespace LabLibrary
{
    public class Airport: ICommunicaion
    {
        public string Name { get => "Airport"; }
 
        public List<Plane> Planes = new List<Plane>();
        public Plane this[int index]
        {
            get => Planes[index];
            set => Planes.Insert(index, value);
        }
        public Plane? this[string flightId]
        {
            get
            {
                for (int i = 0; i < this.Planes.Count; i++)
                {
                    if (Planes[i].FlightId == flightId)
                    {
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
                            this.Planes[i] = value;
                            value.OnAddToAirport(this);
                            value.ReceiveMessage(this, "Самолетов в аэропорту: " + Planes.Count);
                            Event.Invoke("Рейс " + flightId + " был перезаписан рейсом " + value.FlightId);
                            return;
                        }
                    }

                    Event.Invoke("Не удалось перезаписать рейс " + flightId + ", т.к. он не существует");
                }
            }
        }

        public static readonly Color OutputColor;

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

        public void AddPlane(Plane plane)
        {
            Planes.Add(plane);
            Event.Invoke("Рейс \"" + plane.FlightId + "\" добавлен в аэропорт " + Name);
            plane.OnAddToAirport(this);
            plane.ReceiveMessage(this, "Самолетов в аэропорту: " + Planes.Count);
        }

        public void ReadFromFile(OpenFileDialog dialog)
        {
            if (dialog.ShowDialog() != DialogResult.Cancel) {
                this.Planes.Clear();
                StreamReader reader = new StreamReader(dialog.FileName);
                Event.Invoke("Данные рейсов загружаются из файла " + dialog.FileName);

                while (!reader.EndOfStream) {
                    string? flightId = reader.ReadLine();
                    string? companyName = reader.ReadLine();
                    string? destination = reader.ReadLine();
                    string? dateTime = reader.ReadLine();
                    string? price = reader.ReadLine();
                    string? photo = reader.ReadLine();
                    string? type = reader.ReadLine();
                    string? spec = reader.ReadLine();

                    if (type != null && flightId != null && companyName != null && destination != null && dateTime != null && price != null && spec != null && photo != null) {
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
        public void WriteToFile(SaveFileDialog dialog)
        {
            if (dialog.ShowDialog() != DialogResult.Cancel)
            {
                StreamWriter writer = new StreamWriter(dialog.FileName);

                for (int i = 0; i < this.Planes.Count; i++) {
                    writer.WriteLine(this.Planes[i].Serialized);
                }

                writer.Close();

                Event.Invoke("Данные аэропорта " + Name + " выгружены в файл " + dialog.FileName);
            }
        }
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

        public void GetText(ref string text)
        {
            for (int i = 0; i < this.Planes.Count; i++)
            {
                Plane plane = this.Planes[i];
                text += plane.GetText() + "\n\n";
            }
        }
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

        public delegate void AirportEvent(string message);
        public event AirportEvent Event;

        public void ReceiveMessage(ICommunicaion sender, string message)
        {
            Event.Invoke("Получено сообщение от \"" + sender.Name + "\": " + message);
        }
    }
}
