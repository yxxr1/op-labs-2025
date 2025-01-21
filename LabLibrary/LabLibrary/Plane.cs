namespace LabLibrary
{
    public class Plane
    {
        public string Destination;
        public string FlightId;
        public string CompanyName;
        public DateTime DepartureDateTime;
        public int FlightPrice;

        public Plane(string flightId, string companyName, string destination, DateTime dateTime, int price) {
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
