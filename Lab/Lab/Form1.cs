using LabLibrary;

namespace Lab
{
    public partial class Form1 : Form
    {
        private Airport Airport;
        public Form1()
        {
            InitializeComponent();

            // создание объекта аэропорта
            this.Airport = new Airport();
            // назначение обработчиков событий
            Airport.Event += ShowLog;
            Airport.Event += WriteLogToFile;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // привязка списка самолетов к ListBox
            editListBox.DataSource = this.Airport.Planes;
            editListBox.DisplayMember = "FlightId";
        }

        // вывод текста события в UI
        private void ShowLog(string airportMessage)
        {
            eventTextBox.Text += airportMessage + "\n";
        }

        // запись лога в файл, если он выбран
        private void WriteLogToFile(string airportMessage)
        {
            if (eventLogSaveFileDialog.FileName != "")
            {
                StreamWriter writer = new StreamWriter(eventLogSaveFileDialog.FileName, true);

                writer.WriteLine("[" + DateTime.Now.ToString() + "] " + airportMessage);

                writer.Close();
            }
        }

        // вывод рейсов аэропорта в UI
        private void outputFlights(SearchParams? searchParams = null)
        {
            string text = "";

            // вызов нужной версии метода
            if (searchParams == null)
            {
                this.Airport.GetText(ref text);
            } else
            {
                this.Airport.GetText(ref text, (SearchParams)searchParams);
            }

            outputTextBox.Text = text;
            // цвет текста инициализируется в статическом конструкторе аэропорта
            outputTextBox.ForeColor = Airport.OutputColor;

            editListBox.DataSource = null;
            editListBox.DataSource = this.Airport.Planes;
            editListBox.DisplayMember = "FlightId";
        }

        // очистка формы
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

        // обработчик кнопки "Показать все рейсы"
        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.outputFlights();
        }

        // обработчик кнопки "Добавить рейс"
        private void addFlightButton_Click(object sender, EventArgs e)
        {
            // проверка заполнения обязательных полей
            if (this.destinationTextBox.Text != "" && this.photoOpenFileDialog.FileName != "")
            {
                Plane plane;

                // вызов нужного конструктора
                if (this.flightIdTextBox.Text != "" && this.companyNameTextBox.Text != "")
                {
                    // выбор нужного класса в зависимости от чекбокса "Тип самолета"
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

                // если поле "ID для замены" заполнено - рейс с указанным id перезаписывается с помощью индексатора
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

        // очистка привязки данных к полям формы
        private void resetDataBindings()
        {
            this.flightIdTextBox.DataBindings.Clear();
            this.companyNameTextBox.DataBindings.Clear();
            this.destinationTextBox.DataBindings.Clear();
            this.departureDateTimePicker.DataBindings.Clear();
            this.priceNumericUpDown.DataBindings.Clear();
            this.planeSpecNumericUpDown.DataBindings.Clear();
        }

        // установка привязки данных переданного объекта к полям формы для PassengerPlane
        private void setDataBindings(PassengerPlane item)
        {
            this.flightIdTextBox.DataBindings.Add("Text", item, "FlightId");
            this.companyNameTextBox.DataBindings.Add("Text", item, "CompanyName");
            this.destinationTextBox.DataBindings.Add("Text", item, "Destination");
            this.departureDateTimePicker.DataBindings.Add("Value", item, "DepartureDateTime");
            this.priceNumericUpDown.DataBindings.Add("Value", item, "FlightPrice");
            this.planeSpecNumericUpDown.DataBindings.Add("Value", item, "MaxPassengers");
        }
        // версия метода для CargoPlane
        private void setDataBindings(CargoPlane item)
        {
            this.flightIdTextBox.DataBindings.Add("Text", item, "FlightId");
            this.companyNameTextBox.DataBindings.Add("Text", item, "CompanyName");
            this.destinationTextBox.DataBindings.Add("Text", item, "Destination");
            this.departureDateTimePicker.DataBindings.Add("Value", item, "DepartureDateTime");
            this.priceNumericUpDown.DataBindings.Add("Value", item, "FlightPrice");
            this.planeSpecNumericUpDown.DataBindings.Add("Value", item, "MaxWeight");
        }

        // обработчик кнопки "Сброс"
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

        // обработчик кнопки "Редактировать"
        private void editButton_Click(object sender, EventArgs e)
        {
            // проверка что элемент выбран
            if (this.editListBox.SelectedItem != null)
            {
                // отклочение не нужных для редактирования полей
                this.addFlightButton.Enabled = false;
                this.photoButton.Enabled = false;
                this.passengerTypeRadioButton.Enabled = false;
                this.cargoTypeRadioButton.Enabled = false;
                this.replaceIdTextBox.Enabled = false;
                this.resetDataBindings();
                this.replaceIdTextBox.Text = "";

                // получение выбранного элемента через индексатор аэропорта
                Plane selectedItem = Airport[this.editListBox.SelectedIndex];

                // вызов нужной версии setDataBindings
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

                // вывод фото самолета
                selectedItem.ShowPhoto(this.pictureBox);
            }
        }

        // обработчик кнопки "Выбрать фото"
        private void photoButton_Click(object sender, EventArgs e)
        {
            if (this.photoOpenFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                // если выбрано - текст кнопки меняется цвет
                this.photoButton.ForeColor = Color.Green;
            }
        }

        // обработчик кнопки "Сохранить в файл"
        private void fileSaveButton_Click(object sender, EventArgs e)
        {
            this.Airport.WriteToFile(this.saveFileDialog);
        }

        // обработчик кнопки "Загрузить из файла"
        private void fileLoadButton_Click(object sender, EventArgs e)
        {
            this.Airport.ReadFromFile(this.openFileDialog);
            this.outputFlights();
            this.clearForm();
        }

        // переключение на нужный Label в UI для поля спецификации самолета при изменении типа самолета
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

        // обработчик кнопки "Выбрать шрифт"
        private void fontButton_Click(object sender, EventArgs e)
        {
            fontDialog.ShowDialog();
        }

        // при изменении выбранного элемента в ListBox - отрисовка FlightId в PictureBox
        private void editListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.editListBox.SelectedItem != null)
            {
                // получение выбранного элемента через индексатор аэропорта
                Plane selectedItem = Airport[this.editListBox.SelectedIndex];
                selectedItem.DrawFlightId(pictureBox, fontDialog.Font);
            }
        }

        // обработчик кнопки "Выбрать файл для лога"
        private void eventLogButton_Click(object sender, EventArgs e)
        {
            if (eventLogSaveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                // если выбрано - текст кнопки меняется цвет
                eventLogButton.ForeColor = Color.Green;
            }
        }

        // обработчик кнопки "Искать"
        private void searchButton_Click(object sender, EventArgs e)
        {
            // создание структуры SearchParams
            SearchParams searchParams = new() { flightId = searchFlightIdTextBox.Text, dateTime = searchDateTimePicker.Value, destination = searchDestinationTextBox.Text };

            // вызов версии outputFlights с параметрами поиска
            outputFlights(searchParams);
        }
    }
}
