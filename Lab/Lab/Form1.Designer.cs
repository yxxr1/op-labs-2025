namespace Lab
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            outputGroupBox = new GroupBox();
            searchLabel = new Label();
            searchDestinationLabel = new Label();
            searchDateTimeLabel = new Label();
            searchFlightIdLabel = new Label();
            searchFlightIdTextBox = new TextBox();
            searchDateTimePicker = new DateTimePicker();
            searchButton = new Button();
            searchDestinationTextBox = new TextBox();
            fileLoadButton = new Button();
            fileSaveButton = new Button();
            outputTextBox = new RichTextBox();
            refreshButton = new Button();
            flightIdTextBox = new TextBox();
            flightIdLabel = new Label();
            companyNameLabel = new Label();
            destinationLabel = new Label();
            dateTimeLabel = new Label();
            priceLabel = new Label();
            companyNameTextBox = new TextBox();
            destinationTextBox = new TextBox();
            departureDateTimePicker = new DateTimePicker();
            priceNumericUpDown = new NumericUpDown();
            addFlightButton = new Button();
            editListBox = new ListBox();
            resetButton = new Button();
            editButton = new Button();
            pictureBox = new PictureBox();
            photoButton = new Button();
            photoOpenFileDialog = new OpenFileDialog();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            planeTypeLabel = new Label();
            planeSpecPassengerLabel = new Label();
            passengerTypeRadioButton = new RadioButton();
            cargoTypeRadioButton = new RadioButton();
            planeSpecNumericUpDown = new NumericUpDown();
            planeSpecCargoLabel = new Label();
            photoGroupBox = new GroupBox();
            fontDialog = new FontDialog();
            fontButton = new Button();
            eventTextBox = new RichTextBox();
            eventGroupBox = new GroupBox();
            eventLogButton = new Button();
            eventLogSaveFileDialog = new SaveFileDialog();
            replaceIdLabel = new Label();
            replaceIdTextBox = new TextBox();
            outputGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)planeSpecNumericUpDown).BeginInit();
            photoGroupBox.SuspendLayout();
            eventGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // outputGroupBox
            // 
            outputGroupBox.Controls.Add(searchLabel);
            outputGroupBox.Controls.Add(searchDestinationLabel);
            outputGroupBox.Controls.Add(searchDateTimeLabel);
            outputGroupBox.Controls.Add(searchFlightIdLabel);
            outputGroupBox.Controls.Add(searchFlightIdTextBox);
            outputGroupBox.Controls.Add(searchDateTimePicker);
            outputGroupBox.Controls.Add(searchButton);
            outputGroupBox.Controls.Add(searchDestinationTextBox);
            outputGroupBox.Controls.Add(fileLoadButton);
            outputGroupBox.Controls.Add(fileSaveButton);
            outputGroupBox.Controls.Add(outputTextBox);
            outputGroupBox.Controls.Add(refreshButton);
            outputGroupBox.Location = new Point(390, 12);
            outputGroupBox.Name = "outputGroupBox";
            outputGroupBox.Size = new Size(398, 539);
            outputGroupBox.TabIndex = 1;
            outputGroupBox.TabStop = false;
            outputGroupBox.Text = "Рейсы";
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            searchLabel.Location = new Point(159, 265);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(71, 25);
            searchLabel.TabIndex = 10;
            searchLabel.Text = "Поиск";
            // 
            // searchDestinationLabel
            // 
            searchDestinationLabel.AutoSize = true;
            searchDestinationLabel.Location = new Point(76, 360);
            searchDestinationLabel.Name = "searchDestinationLabel";
            searchDestinationLabel.Size = new Size(110, 15);
            searchDestinationLabel.TabIndex = 9;
            searchDestinationLabel.Text = "Пункт назначения:";
            // 
            // searchDateTimeLabel
            // 
            searchDateTimeLabel.AutoSize = true;
            searchDateTimeLabel.Location = new Point(68, 331);
            searchDateTimeLabel.Name = "searchDateTimeLabel";
            searchDateTimeLabel.Size = new Size(118, 15);
            searchDateTimeLabel.TabIndex = 8;
            searchDateTimeLabel.Text = "Дата и время после:";
            // 
            // searchFlightIdLabel
            // 
            searchFlightIdLabel.AutoSize = true;
            searchFlightIdLabel.Location = new Point(132, 302);
            searchFlightIdLabel.Name = "searchFlightIdLabel";
            searchFlightIdLabel.Size = new Size(54, 15);
            searchFlightIdLabel.TabIndex = 7;
            searchFlightIdLabel.Text = "Flight ID:";
            // 
            // searchFlightIdTextBox
            // 
            searchFlightIdTextBox.Location = new Point(192, 299);
            searchFlightIdTextBox.Name = "searchFlightIdTextBox";
            searchFlightIdTextBox.Size = new Size(200, 23);
            searchFlightIdTextBox.TabIndex = 6;
            // 
            // searchDateTimePicker
            // 
            searchDateTimePicker.Location = new Point(192, 328);
            searchDateTimePicker.Name = "searchDateTimePicker";
            searchDateTimePicker.Size = new Size(200, 23);
            searchDateTimePicker.TabIndex = 5;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(6, 386);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(386, 33);
            searchButton.TabIndex = 4;
            searchButton.Text = "Искать";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // searchDestinationTextBox
            // 
            searchDestinationTextBox.Location = new Point(192, 357);
            searchDestinationTextBox.Name = "searchDestinationTextBox";
            searchDestinationTextBox.Size = new Size(200, 23);
            searchDestinationTextBox.TabIndex = 3;
            // 
            // fileLoadButton
            // 
            fileLoadButton.Location = new Point(202, 437);
            fileLoadButton.Name = "fileLoadButton";
            fileLoadButton.Size = new Size(190, 39);
            fileLoadButton.TabIndex = 2;
            fileLoadButton.Text = "Загрузить из файла";
            fileLoadButton.UseVisualStyleBackColor = true;
            fileLoadButton.Click += fileLoadButton_Click;
            // 
            // fileSaveButton
            // 
            fileSaveButton.Location = new Point(6, 437);
            fileSaveButton.Name = "fileSaveButton";
            fileSaveButton.Size = new Size(190, 39);
            fileSaveButton.TabIndex = 1;
            fileSaveButton.Text = "Сохранить в файл";
            fileSaveButton.UseVisualStyleBackColor = true;
            fileSaveButton.Click += fileSaveButton_Click;
            // 
            // outputTextBox
            // 
            outputTextBox.Location = new Point(6, 22);
            outputTextBox.Name = "outputTextBox";
            outputTextBox.ReadOnly = true;
            outputTextBox.Size = new Size(386, 240);
            outputTextBox.TabIndex = 0;
            outputTextBox.Text = "";
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(6, 482);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(386, 51);
            refreshButton.TabIndex = 2;
            refreshButton.Text = "Показать все рейсы";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // flightIdTextBox
            // 
            flightIdTextBox.Location = new Point(176, 34);
            flightIdTextBox.Name = "flightIdTextBox";
            flightIdTextBox.Size = new Size(208, 23);
            flightIdTextBox.TabIndex = 3;
            // 
            // flightIdLabel
            // 
            flightIdLabel.AutoSize = true;
            flightIdLabel.Location = new Point(116, 37);
            flightIdLabel.Name = "flightIdLabel";
            flightIdLabel.Size = new Size(54, 15);
            flightIdLabel.TabIndex = 4;
            flightIdLabel.Text = "Flight ID:";
            // 
            // companyNameLabel
            // 
            companyNameLabel.AutoSize = true;
            companyNameLabel.Location = new Point(104, 66);
            companyNameLabel.Name = "companyNameLabel";
            companyNameLabel.Size = new Size(66, 15);
            companyNameLabel.TabIndex = 5;
            companyNameLabel.Text = "Компания:";
            // 
            // destinationLabel
            // 
            destinationLabel.AutoSize = true;
            destinationLabel.Location = new Point(60, 95);
            destinationLabel.Name = "destinationLabel";
            destinationLabel.Size = new Size(110, 15);
            destinationLabel.TabIndex = 6;
            destinationLabel.Text = "Пункт назначения:";
            // 
            // dateTimeLabel
            // 
            dateTimeLabel.AutoSize = true;
            dateTimeLabel.Location = new Point(88, 121);
            dateTimeLabel.Name = "dateTimeLabel";
            dateTimeLabel.Size = new Size(82, 15);
            dateTimeLabel.TabIndex = 7;
            dateTimeLabel.Text = "Дата и время:";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(100, 152);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(70, 15);
            priceLabel.TabIndex = 8;
            priceLabel.Text = "Стоимость:";
            // 
            // companyNameTextBox
            // 
            companyNameTextBox.Location = new Point(176, 63);
            companyNameTextBox.Name = "companyNameTextBox";
            companyNameTextBox.Size = new Size(208, 23);
            companyNameTextBox.TabIndex = 9;
            // 
            // destinationTextBox
            // 
            destinationTextBox.Location = new Point(176, 92);
            destinationTextBox.Name = "destinationTextBox";
            destinationTextBox.Size = new Size(208, 23);
            destinationTextBox.TabIndex = 10;
            // 
            // departureDateTimePicker
            // 
            departureDateTimePicker.Location = new Point(176, 121);
            departureDateTimePicker.Name = "departureDateTimePicker";
            departureDateTimePicker.Size = new Size(152, 23);
            departureDateTimePicker.TabIndex = 11;
            // 
            // priceNumericUpDown
            // 
            priceNumericUpDown.Location = new Point(176, 150);
            priceNumericUpDown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            priceNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            priceNumericUpDown.Name = "priceNumericUpDown";
            priceNumericUpDown.Size = new Size(120, 23);
            priceNumericUpDown.TabIndex = 12;
            priceNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // addFlightButton
            // 
            addFlightButton.Location = new Point(128, 306);
            addFlightButton.Name = "addFlightButton";
            addFlightButton.Size = new Size(256, 31);
            addFlightButton.TabIndex = 13;
            addFlightButton.Text = "Добавить рейс";
            addFlightButton.UseVisualStyleBackColor = true;
            addFlightButton.Click += addFlightButton_Click;
            // 
            // editListBox
            // 
            editListBox.FormattingEnabled = true;
            editListBox.ItemHeight = 15;
            editListBox.Location = new Point(176, 343);
            editListBox.Name = "editListBox";
            editListBox.Size = new Size(208, 154);
            editListBox.TabIndex = 14;
            editListBox.SelectedIndexChanged += editListBox_SelectedIndexChanged;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(12, 306);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(110, 31);
            resetButton.TabIndex = 15;
            resetButton.Text = "Сброс";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(176, 503);
            editButton.Name = "editButton";
            editButton.Size = new Size(208, 48);
            editButton.TabIndex = 16;
            editButton.Text = "Редактировать";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(6, 22);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(146, 123);
            pictureBox.TabIndex = 17;
            pictureBox.TabStop = false;
            // 
            // photoButton
            // 
            photoButton.Location = new Point(176, 179);
            photoButton.Name = "photoButton";
            photoButton.Size = new Size(96, 29);
            photoButton.TabIndex = 18;
            photoButton.Text = "Выбрать фото";
            photoButton.UseVisualStyleBackColor = true;
            photoButton.Click += photoButton_Click;
            // 
            // planeTypeLabel
            // 
            planeTypeLabel.AutoSize = true;
            planeTypeLabel.Location = new Point(85, 218);
            planeTypeLabel.Name = "planeTypeLabel";
            planeTypeLabel.Size = new Size(85, 15);
            planeTypeLabel.TabIndex = 19;
            planeTypeLabel.Text = "Тип самолета:";
            // 
            // planeSpecPassengerLabel
            // 
            planeSpecPassengerLabel.AutoSize = true;
            planeSpecPassengerLabel.Location = new Point(25, 250);
            planeSpecPassengerLabel.Name = "planeSpecPassengerLabel";
            planeSpecPassengerLabel.Size = new Size(145, 15);
            planeSpecPassengerLabel.TabIndex = 20;
            planeSpecPassengerLabel.Text = "Количество пассажиров:";
            // 
            // passengerTypeRadioButton
            // 
            passengerTypeRadioButton.AutoSize = true;
            passengerTypeRadioButton.Checked = true;
            passengerTypeRadioButton.Location = new Point(176, 214);
            passengerTypeRadioButton.Name = "passengerTypeRadioButton";
            passengerTypeRadioButton.Size = new Size(107, 19);
            passengerTypeRadioButton.TabIndex = 21;
            passengerTypeRadioButton.TabStop = true;
            passengerTypeRadioButton.Text = "Пассажирский";
            passengerTypeRadioButton.UseVisualStyleBackColor = true;
            passengerTypeRadioButton.CheckedChanged += passengerTypeRadioButton_CheckedChanged;
            // 
            // cargoTypeRadioButton
            // 
            cargoTypeRadioButton.AutoSize = true;
            cargoTypeRadioButton.Location = new Point(289, 214);
            cargoTypeRadioButton.Name = "cargoTypeRadioButton";
            cargoTypeRadioButton.Size = new Size(76, 19);
            cargoTypeRadioButton.TabIndex = 22;
            cargoTypeRadioButton.Text = "Грузовой";
            cargoTypeRadioButton.UseVisualStyleBackColor = true;
            cargoTypeRadioButton.CheckedChanged += cargoTypeRadioButton_CheckedChanged;
            // 
            // planeSpecNumericUpDown
            // 
            planeSpecNumericUpDown.Location = new Point(176, 248);
            planeSpecNumericUpDown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            planeSpecNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            planeSpecNumericUpDown.Name = "planeSpecNumericUpDown";
            planeSpecNumericUpDown.Size = new Size(120, 23);
            planeSpecNumericUpDown.TabIndex = 23;
            planeSpecNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // planeSpecCargoLabel
            // 
            planeSpecCargoLabel.AutoSize = true;
            planeSpecCargoLabel.Location = new Point(52, 250);
            planeSpecCargoLabel.Name = "planeSpecCargoLabel";
            planeSpecCargoLabel.Size = new Size(118, 15);
            planeSpecCargoLabel.TabIndex = 24;
            planeSpecCargoLabel.Text = "Максимальный вес:";
            planeSpecCargoLabel.Visible = false;
            // 
            // photoGroupBox
            // 
            photoGroupBox.Controls.Add(pictureBox);
            photoGroupBox.Location = new Point(12, 343);
            photoGroupBox.Name = "photoGroupBox";
            photoGroupBox.Size = new Size(158, 151);
            photoGroupBox.TabIndex = 25;
            photoGroupBox.TabStop = false;
            photoGroupBox.Text = "Фото";
            // 
            // fontButton
            // 
            fontButton.Location = new Point(12, 503);
            fontButton.Name = "fontButton";
            fontButton.Size = new Size(158, 48);
            fontButton.TabIndex = 26;
            fontButton.Text = "Выбор шрифта";
            fontButton.UseVisualStyleBackColor = true;
            fontButton.Click += fontButton_Click;
            // 
            // eventTextBox
            // 
            eventTextBox.Location = new Point(6, 22);
            eventTextBox.Name = "eventTextBox";
            eventTextBox.ReadOnly = true;
            eventTextBox.Size = new Size(266, 463);
            eventTextBox.TabIndex = 27;
            eventTextBox.Text = "";
            // 
            // eventGroupBox
            // 
            eventGroupBox.Controls.Add(eventLogButton);
            eventGroupBox.Controls.Add(eventTextBox);
            eventGroupBox.Location = new Point(794, 12);
            eventGroupBox.Name = "eventGroupBox";
            eventGroupBox.Size = new Size(278, 539);
            eventGroupBox.TabIndex = 28;
            eventGroupBox.TabStop = false;
            eventGroupBox.Text = "События";
            // 
            // eventLogButton
            // 
            eventLogButton.Location = new Point(6, 491);
            eventLogButton.Name = "eventLogButton";
            eventLogButton.Size = new Size(266, 39);
            eventLogButton.TabIndex = 28;
            eventLogButton.Text = "Выбрать файл для лога";
            eventLogButton.UseVisualStyleBackColor = true;
            eventLogButton.Click += eventLogButton_Click;
            // 
            // replaceIdLabel
            // 
            replaceIdLabel.AutoSize = true;
            replaceIdLabel.Location = new Point(88, 280);
            replaceIdLabel.Name = "replaceIdLabel";
            replaceIdLabel.Size = new Size(85, 15);
            replaceIdLabel.TabIndex = 29;
            replaceIdLabel.Text = "ID для замены";
            // 
            // replaceIdTextBox
            // 
            replaceIdTextBox.Location = new Point(176, 277);
            replaceIdTextBox.Name = "replaceIdTextBox";
            replaceIdTextBox.Size = new Size(208, 23);
            replaceIdTextBox.TabIndex = 30;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 561);
            Controls.Add(replaceIdTextBox);
            Controls.Add(replaceIdLabel);
            Controls.Add(eventGroupBox);
            Controls.Add(fontButton);
            Controls.Add(photoGroupBox);
            Controls.Add(planeSpecCargoLabel);
            Controls.Add(planeSpecNumericUpDown);
            Controls.Add(cargoTypeRadioButton);
            Controls.Add(passengerTypeRadioButton);
            Controls.Add(planeSpecPassengerLabel);
            Controls.Add(planeTypeLabel);
            Controls.Add(photoButton);
            Controls.Add(editButton);
            Controls.Add(resetButton);
            Controls.Add(editListBox);
            Controls.Add(addFlightButton);
            Controls.Add(priceNumericUpDown);
            Controls.Add(departureDateTimePicker);
            Controls.Add(destinationTextBox);
            Controls.Add(companyNameTextBox);
            Controls.Add(priceLabel);
            Controls.Add(dateTimeLabel);
            Controls.Add(destinationLabel);
            Controls.Add(companyNameLabel);
            Controls.Add(flightIdLabel);
            Controls.Add(flightIdTextBox);
            Controls.Add(outputGroupBox);
            MaximizeBox = false;
            MaximumSize = new Size(1100, 600);
            MinimumSize = new Size(1100, 600);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            outputGroupBox.ResumeLayout(false);
            outputGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)planeSpecNumericUpDown).EndInit();
            photoGroupBox.ResumeLayout(false);
            eventGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox outputGroupBox;
        private RichTextBox outputTextBox;
        private Button refreshButton;
        private TextBox flightIdTextBox;
        private Label flightIdLabel;
        private Label companyNameLabel;
        private Label destinationLabel;
        private Label dateTimeLabel;
        private Label priceLabel;
        private TextBox companyNameTextBox;
        private TextBox destinationTextBox;
        private DateTimePicker departureDateTimePicker;
        private NumericUpDown priceNumericUpDown;
        private Button addFlightButton;
        private ListBox editListBox;
        private Button resetButton;
        private Button editButton;
        private PictureBox pictureBox;
        private Button photoButton;
        private OpenFileDialog photoOpenFileDialog;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private Button fileLoadButton;
        private Button fileSaveButton;
        private Label planeTypeLabel;
        private Label planeSpecPassengerLabel;
        private RadioButton passengerTypeRadioButton;
        private RadioButton cargoTypeRadioButton;
        private NumericUpDown planeSpecNumericUpDown;
        private Label planeSpecCargoLabel;
        private GroupBox photoGroupBox;
        private FontDialog fontDialog;
        private Button fontButton;
        private RichTextBox eventTextBox;
        private GroupBox eventGroupBox;
        private Button eventLogButton;
        private SaveFileDialog eventLogSaveFileDialog;
        private Label replaceIdLabel;
        private TextBox replaceIdTextBox;
        private TextBox searchFlightIdTextBox;
        private DateTimePicker searchDateTimePicker;
        private Button searchButton;
        private TextBox searchDestinationTextBox;
        private Label searchFlightIdLabel;
        private Label searchLabel;
        private Label searchDestinationLabel;
        private Label searchDateTimeLabel;
    }
}
