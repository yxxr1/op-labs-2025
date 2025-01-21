using System.Drawing;

namespace LabLibrary
{
    public class Airport
    {
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
    }
}
