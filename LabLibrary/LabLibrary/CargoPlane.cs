namespace LabLibrary
{
    public class CargoPlane: Plane
    {
        public override sealed string Type { get => "Cargo"; }
        private int maxWeight;
        private string flightId;
        public override string FlightId
        {
            get => flightId + "_" + Type + "_" + MaxWeight;
            set => flightId = value;
        }

        public int MaxWeight {
            get => maxWeight;
            set {
                maxWeight = Math.Min(value, 10000);
            }
        }
        public override string Serialized
        {
            get => base.Serialized + "\n" + Type + "\n" + MaxWeight;
        }
        public override string GetText(bool isShowDaysToDeparture = true)
        {
            return base.GetText(isShowDaysToDeparture) + "\n" + GetPlaneSpecText();
        }

        public CargoPlane(string flightId, string companyName, string destination, DateTime dateTime, int price, int maxWeight, string photo) : base(flightId, companyName, destination, dateTime, price, photo)
        {
            this.MaxWeight = maxWeight;
        }

        public CargoPlane(string destination, DateTime dateTime, int price, int maxWeight, string photo) : base(destination, dateTime, price, photo)
        {
            this.MaxWeight = maxWeight;
        }

        public override string GetPlaneSpecText()
        {
            return "Тип: Грузовой\nМаксимальный вес: " + MaxWeight;
        }
    }
}
