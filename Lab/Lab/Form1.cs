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
            Airport.Event += ShowLog;
            Airport.Event += WriteLogToFile;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            editListBox.DataSource = this.Airport.Planes;
            editListBox.DisplayMember = "FlightId";
        }

        private void ShowLog(string airportMessage)
        {
            eventTextBox.Text += airportMessage + "\n";
        }
        private void WriteLogToFile(string airportMessage)
        {
            if (eventLogSaveFileDialog.FileName != "")
            {
                StreamWriter writer = new StreamWriter(eventLogSaveFileDialog.FileName, true);

                writer.WriteLine("[" + DateTime.Now.ToString() + "] " + airportMessage);

                writer.Close();
            }
        }

        private void outputFlights(SearchParams? searchParams = null)
        {
            string text = "";

            if (searchParams == null)
            {
                this.Airport.GetText(ref text);
            } else
            {
                this.Airport.GetText(ref text, (SearchParams)searchParams);
            }

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
            this.passengerTypeRadioButton.Checked = true;
            this.planeSpecNumericUpDown.Value = 1;
            this.replaceIdTextBox.Text = "";
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
                    if (passengerTypeRadioButton.Checked)
                    {
                        plane = new PassengerPlane(
                            this.flightIdTextBox.Text,
                            this.companyNameTextBox.Text,
                            this.destinationTextBox.Text,
                            this.departureDateTimePicker.Value,
                            (int)this.priceNumericUpDown.Value,
                            (int)this.planeSpecNumericUpDown.Value,
                            this.photoOpenFileDialog.FileName
                            );
                    }
                    else
                    {
                        plane = new CargoPlane(
                            this.flightIdTextBox.Text,
                            this.companyNameTextBox.Text,
                            this.destinationTextBox.Text,
                            this.departureDateTimePicker.Value,
                            (int)this.priceNumericUpDown.Value,
                            (int)this.planeSpecNumericUpDown.Value,
                            this.photoOpenFileDialog.FileName
                            );
                    }
                }
                else
                {
                    if (passengerTypeRadioButton.Checked)
                    {
                        plane = new PassengerPlane(
                            this.destinationTextBox.Text,
                            this.departureDateTimePicker.Value,
                            (int)this.priceNumericUpDown.Value,
                            (int)this.planeSpecNumericUpDown.Value,
                            this.photoOpenFileDialog.FileName
                            );
                    }
                    else
                    {
                        plane = new CargoPlane(
                            this.destinationTextBox.Text,
                            this.departureDateTimePicker.Value,
                            (int)this.priceNumericUpDown.Value,
                            (int)this.planeSpecNumericUpDown.Value,
                            this.photoOpenFileDialog.FileName
                            );
                    }
                }

                if (replaceIdTextBox.Text != "")
                {
                    Airport[replaceIdTextBox.Text] = plane;
                }
                else
                {
                    Airport.AddPlane(plane);
                }

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
            this.planeSpecNumericUpDown.DataBindings.Clear();
        }

        private void setDataBindings(PassengerPlane item)
        {
            this.flightIdTextBox.DataBindings.Add("Text", item, "FlightId");
            this.companyNameTextBox.DataBindings.Add("Text", item, "CompanyName");
            this.destinationTextBox.DataBindings.Add("Text", item, "Destination");
            this.departureDateTimePicker.DataBindings.Add("Value", item, "DepartureDateTime");
            this.priceNumericUpDown.DataBindings.Add("Value", item, "FlightPrice");
            this.planeSpecNumericUpDown.DataBindings.Add("Value", item, "MaxPassengers");
        }
        private void setDataBindings(CargoPlane item)
        {
            this.flightIdTextBox.DataBindings.Add("Text", item, "FlightId");
            this.companyNameTextBox.DataBindings.Add("Text", item, "CompanyName");
            this.destinationTextBox.DataBindings.Add("Text", item, "Destination");
            this.departureDateTimePicker.DataBindings.Add("Value", item, "DepartureDateTime");
            this.priceNumericUpDown.DataBindings.Add("Value", item, "FlightPrice");
            this.planeSpecNumericUpDown.DataBindings.Add("Value", item, "MaxWeight");
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            this.resetDataBindings();
            this.clearForm();
            this.addFlightButton.Enabled = true;
            this.photoButton.Enabled = true;
            this.passengerTypeRadioButton.Enabled = true;
            this.cargoTypeRadioButton.Enabled = true;
            this.replaceIdTextBox.Enabled = true;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (this.editListBox.SelectedItem != null)
            {
                this.addFlightButton.Enabled = false;
                this.photoButton.Enabled = false;
                this.passengerTypeRadioButton.Enabled = false;
                this.cargoTypeRadioButton.Enabled = false;
                this.replaceIdTextBox.Enabled = false;
                this.resetDataBindings();
                this.replaceIdTextBox.Text = "";

                Plane selectedItem = Airport[this.editListBox.SelectedIndex];

                if (selectedItem.Type == "Passenger")
                {
                    this.passengerTypeRadioButton.Checked = true;
                    this.setDataBindings((PassengerPlane)selectedItem);
                }
                else if (selectedItem.Type == "Cargo")
                {
                    this.cargoTypeRadioButton.Checked = true;
                    this.setDataBindings((CargoPlane)selectedItem);
                }

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

        private void passengerTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.planeSpecCargoLabel.Visible = false;
            this.planeSpecPassengerLabel.Visible = true;
        }

        private void cargoTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.planeSpecPassengerLabel.Visible = false;
            this.planeSpecCargoLabel.Visible = true;
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
            fontDialog.ShowDialog();
        }

        private void editListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.editListBox.SelectedItem != null)
            {
                Plane selectedItem = Airport[this.editListBox.SelectedIndex];
                selectedItem.DrawFlightId(pictureBox, fontDialog.Font);
            }
        }

        private void eventLogButton_Click(object sender, EventArgs e)
        {
            if (eventLogSaveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                eventLogButton.ForeColor = Color.Green;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchParams searchParams = new() { flightId = searchFlightIdTextBox.Text, dateTime = searchDateTimePicker.Value, destination = searchDestinationTextBox.Text };

            outputFlights(searchParams);
        }
    }
}
