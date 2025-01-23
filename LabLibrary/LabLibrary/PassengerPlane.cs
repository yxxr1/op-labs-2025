namespace LabLibrary
{
    public class PassengerPlane: Plane
    {
        public override sealed string Type { get => "Passenger"; }
        private int maxPassengers;
        private string flightId;
        public override string FlightId
        {
            get => flightId + "_" + Type + "_" + MaxPassengers;
            set => flightId = value;
        }

        public int MaxPassengers
        {
            get => maxPassengers;
            set
            {
                maxPassengers = Math.Min(value, 500);
            }
        }
        public override string Serialized
        {
            get => base.Serialized + "\n" + Type + "\n" + MaxPassengers;
        }

        public override string GetText(bool isShowDaysToDeparture = true)
        {
            return base.GetText(isShowDaysToDeparture) + "\n" + GetPlaneSpecText();
        }

        public PassengerPlane(string flightId, string companyName, string destination, DateTime dateTime, int price, int maxPassengers, string photo): base(flightId, companyName, destination, dateTime, price, photo)
        {
            this.MaxPassengers = maxPassengers;
        }

        public PassengerPlane( string destination, DateTime dateTime, int price, int maxPassengers, string photo): base(destination, dateTime, price, photo)
        {
            this.MaxPassengers = maxPassengers;
        }

        public new void DaysToDeparture(out int result)
        {
            result = (this.DepartureDateTime - DateTime.Now).Days;
        }

        public override string GetPlaneSpecText()
        {
            return "Тип: Пассажирский\nКоличество пассажиров: " + MaxPassengers;
        }
    }
}
