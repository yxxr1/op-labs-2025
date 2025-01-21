namespace LabLibrary
{
    public class Plane
    {
        private string destination;
        private DateTime departureDateTime;
        private int flightPrice;

        public string Destination {
            get => destination;
            private set {
                destination = char.ToUpper(value[0]) + value.Substring(1);
            }
        }
        public string FlightId { get; private set; }
        public string CompanyName { get; private set; }
        public DateTime DepartureDateTime {
            get => departureDateTime;
            private set {
                departureDateTime = value.DayOfWeek == DayOfWeek.Saturday ? value.AddDays(2) : value.DayOfWeek == DayOfWeek.Sunday ? value.AddDays(1) : value;
            }
        }
        public int FlightPrice {
            get => flightPrice;
            private set {
                flightPrice = Math.Max(value, 100);
            }
        }

        public Plane(string flightId, string companyName, string destination, DateTime dateTime, int price)
        {
            this.Destination = destination;
            this.FlightId = flightId;
            this.CompanyName = companyName;
            this.DepartureDateTime = dateTime;
            this.FlightPrice = price;
        }
        public Plane(string destination, DateTime dateTime, int price)
        {
            this.Destination = destination;
            this.FlightId = destination + "_" + dateTime.ToString();
            this.CompanyName = "Air company";
            this.DepartureDateTime = dateTime;
            this.FlightPrice = price;
        }
    }
}
