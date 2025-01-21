using LabLibrary;

namespace Lab
{
    public partial class Form1 : Form
    {
        private Airport Airport;
        public Form1()
        {
            InitializeComponent();

            this.Airport = new Airport();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void outputFlights()
        {
            string text = "";

            for (int i = 0; i < this.Airport.Planes.Count; i++)
            {
                Plane plane = this.Airport.Planes[i];
                text += "Рейс \"" + plane.FlightId + "\" компании \"" + plane.CompanyName
                    + "\":\nПункт назначения: " + plane.Destination
                    + "\nДата и время отправления: " + plane.DepartureDateTime.ToString()
                    + "\nСтоимость: " + plane.FlightPrice + "\n\n";
            }

            outputTextBox.Text = text;
            outputTextBox.ForeColor = Airport.OutputColor;
        }
        private void clearForm() {
            this.flightIdTextBox.Text = "";
            this.companyNameTextBox.Text = "";
            this.destinationTextBox.Text = "";
            this.departureDateTimePicker.Value = DateTime.Now;
            this.priceNumericUpDown.Value = 1;
        }

        private void refreshButton_Click(object sender, EventArgs e) {
            this.outputFlights();
        }

        private void addFlightButton_Click(object sender, EventArgs e)
        {
            if (this.destinationTextBox.Text != "") {
                Plane plane;

                if (this.flightIdTextBox.Text != "" && this.companyNameTextBox.Text != "") {
                     plane = new Plane(this.flightIdTextBox.Text, this.companyNameTextBox.Text, this.destinationTextBox.Text, this.departureDateTimePicker.Value, (int)this.priceNumericUpDown.Value);
                } else {
                    plane = new Plane(this.destinationTextBox.Text, this.departureDateTimePicker.Value, (int)this.priceNumericUpDown.Value);
                }

                this.Airport.Planes.Add(plane);

                this.outputFlights();
                this.clearForm();
            }
        }

        private void testButton_Click(object sender, EventArgs e) {
            string text = "";

            text += "ToString(): \n" + this.Airport.ToString()
                + "\n\nGetHashCode(): \n" + this.Airport.GetHashCode();

            outputTextBox.Text = text;
        }
    }
}
