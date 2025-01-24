using System.Drawing;

namespace LabLibrary
{
    public class Airport
    {
        public const string Name = "Airport";
 
        public List<Plane> Planes = new List<Plane>();

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

        public delegate void AirportEvent(string message);
        public event AirportEvent Event;
    }
}
