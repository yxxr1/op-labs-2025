namespace LabLibrary
{
    public class PassengerPlane: Plane
    {
        // тип самолета, наследники могут представлять конкретную модель самолета этого типа, но не могут переопределить тип
        public override sealed string Type { get => "Passenger"; }
        private int maxPassengers;
        private string flightId;
        public override string FlightId
        {
            // добавляется тип и количество пассажиров к FlightId
            get => flightId + "_" + Type + "_" + MaxPassengers;
            set => flightId = value;
        }

        public int MaxPassengers
        {
            get => maxPassengers;
            set
            {
                // максимальное количество пассажиров - 500
                maxPassengers = Math.Min(value, 500);
            }
        }

        // переопределенное свойство Serialized, добавляющее тип и количество пассажиров
        public override string Serialized
        {
            get => base.Serialized + "\n" + Type + "\n" + MaxPassengers;
        }

        // переопределенный метод GetText, добавляющий спецификацию самолета
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

        // реализация абстрактного метода
        public override string GetPlaneSpecText()
        {
            return "Тип: Пассажирский\nКоличество пассажиров: " + MaxPassengers;
        }
    }
}
