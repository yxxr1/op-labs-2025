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

        private void Form1_Load(object sender, EventArgs e)
        {
            editListBox.DataSource = this.Airport.Planes;
            editListBox.DisplayMember = "FlightId";
        }

        private void outputFlights()
        {
            string text = "";

            this.Airport.GetText(ref text);

            outputTextBox.Text = text;
            outputTextBox.ForeColor = Airport.OutputColor;

            editListBox.DataSource = null;
            editListBox.DataSource = this.Airport.Planes;
            editListBox.DisplayMember = "FlightId";
        }
        private void clearForm()
        {
            this.flightIdTextBox.Text = "";
            this.companyNameTextBox.Text = "";
            this.destinationTextBox.Text = "";
            this.departureDateTimePicker.Value = DateTime.Now;
            this.priceNumericUpDown.Value = 1;
            this.photoOpenFileDialog.FileName = "";
            this.pictureBox.Image = null;
            this.photoButton.ForeColor = Color.Black;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.outputFlights();
        }

        private void addFlightButton_Click(object sender, EventArgs e)
        {
            if (this.destinationTextBox.Text != "" && this.photoOpenFileDialog.FileName != "")
            {
                Plane plane;

                if (this.flightIdTextBox.Text != "" && this.companyNameTextBox.Text != "")
                {
                    plane = new Plane(this.flightIdTextBox.Text, this.companyNameTextBox.Text, this.destinationTextBox.Text, this.departureDateTimePicker.Value, (int)this.priceNumericUpDown.Value, this.photoOpenFileDialog.FileName);
                }
                else
                {
                    plane = new Plane(this.destinationTextBox.Text, this.departureDateTimePicker.Value, (int)this.priceNumericUpDown.Value, this.photoOpenFileDialog.FileName);
                }

                this.Airport.Planes.Add(plane);

                this.outputFlights();
                this.clearForm();
            }
        }

        private void resetDataBindings()
        {
            this.flightIdTextBox.DataBindings.Clear();
            this.companyNameTextBox.DataBindings.Clear();
            this.destinationTextBox.DataBindings.Clear();
            this.departureDateTimePicker.DataBindings.Clear();
            this.priceNumericUpDown.DataBindings.Clear();
        }

        private void setDataBindings(Plane item)
        {
            this.flightIdTextBox.DataBindings.Add("Text", item, "FlightId");
            this.companyNameTextBox.DataBindings.Add("Text", item, "CompanyName");
            this.destinationTextBox.DataBindings.Add("Text", item, "Destination");
            this.departureDateTimePicker.DataBindings.Add("Value", item, "DepartureDateTime");
            this.priceNumericUpDown.DataBindings.Add("Value", item, "FlightPrice");
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            this.resetDataBindings();
            this.clearForm();
            this.addFlightButton.Enabled = true;
            this.photoButton.Enabled = true;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (this.editListBox.SelectedItem != null)
            {
                this.addFlightButton.Enabled = false;
                this.photoButton.Enabled = false;
                this.resetDataBindings();

                Plane selectedItem = (Plane)this.editListBox.SelectedItem;

                this.setDataBindings(selectedItem);
                selectedItem.ShowPhoto(this.pictureBox);
            }
        }

        private void photoButton_Click(object sender, EventArgs e)
        {
            if (this.photoOpenFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                this.photoButton.ForeColor = Color.Green;
            }
        }

        private void fileSaveButton_Click(object sender, EventArgs e)
        {
            this.Airport.WriteToFile(this.saveFileDialog);
        }

        private void fileLoadButton_Click(object sender, EventArgs e)
        {
            this.Airport.ReadFromFile(this.openFileDialog);
            this.outputFlights();
            this.clearForm();
        }
    }
}
