namespace LabLibrary
{
    public class CargoPlane: Plane
    {
        // тип самолета, наследники могут представлять конкретную модель самолета этого типа, но не могут переопределить тип
        public override sealed string Type { get => "Cargo"; }
        private int maxWeight;
        private string flightId;
        public override string FlightId
        {
            // добавляется тип и максимальный вес к FlightId
            get => flightId + "_" + Type + "_" + MaxWeight;
            set => flightId = value;
        }

        public int MaxWeight {
            get => maxWeight;
            set {
                // максимальный вес - 10000
                maxWeight = Math.Min(value, 10000);
            }
        }

        // переопределенное свойство Serialized, добавляющее тип и максимальный вес
        public override string Serialized
        {
            get => base.Serialized + "\n" + Type + "\n" + MaxWeight;
        }

        // переопределенный метод GetText, добавляющий спецификацию самолета
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

        // реализация абстрактного метода
        public override string GetPlaneSpecText()
        {
            return "Тип: Грузовой\nМаксимальный вес: " + MaxWeight;
        }
    }
}
