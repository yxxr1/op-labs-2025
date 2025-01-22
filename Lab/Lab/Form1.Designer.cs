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
            groupBox1 = new GroupBox();
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
            fileSaveButton = new Button();
            fileLoadButton = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(fileLoadButton);
            groupBox1.Controls.Add(fileSaveButton);
            groupBox1.Controls.Add(outputTextBox);
            groupBox1.Location = new Point(390, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(398, 402);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Рейсы";
            // 
            // outputTextBox
            // 
            outputTextBox.Location = new Point(6, 22);
            outputTextBox.Name = "outputTextBox";
            outputTextBox.Size = new Size(386, 327);
            outputTextBox.TabIndex = 0;
            outputTextBox.Text = "";
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(390, 420);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(398, 48);
            refreshButton.TabIndex = 2;
            refreshButton.Text = "Обновить";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // flightIdTextBox
            // 
            flightIdTextBox.Location = new Point(128, 34);
            flightIdTextBox.Name = "flightIdTextBox";
            flightIdTextBox.Size = new Size(256, 23);
            flightIdTextBox.TabIndex = 3;
            // 
            // flightIdLabel
            // 
            flightIdLabel.AutoSize = true;
            flightIdLabel.Location = new Point(68, 37);
            flightIdLabel.Name = "flightIdLabel";
            flightIdLabel.Size = new Size(54, 15);
            flightIdLabel.TabIndex = 4;
            flightIdLabel.Text = "Flight ID:";
            // 
            // companyNameLabel
            // 
            companyNameLabel.AutoSize = true;
            companyNameLabel.Location = new Point(56, 66);
            companyNameLabel.Name = "companyNameLabel";
            companyNameLabel.Size = new Size(66, 15);
            companyNameLabel.TabIndex = 5;
            companyNameLabel.Text = "Компания:";
            // 
            // destinationLabel
            // 
            destinationLabel.AutoSize = true;
            destinationLabel.Location = new Point(12, 95);
            destinationLabel.Name = "destinationLabel";
            destinationLabel.Size = new Size(110, 15);
            destinationLabel.TabIndex = 6;
            destinationLabel.Text = "Пункт назначения:";
            // 
            // dateTimeLabel
            // 
            dateTimeLabel.AutoSize = true;
            dateTimeLabel.Location = new Point(40, 121);
            dateTimeLabel.Name = "dateTimeLabel";
            dateTimeLabel.Size = new Size(82, 15);
            dateTimeLabel.TabIndex = 7;
            dateTimeLabel.Text = "Дата и время:";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(52, 150);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(70, 15);
            priceLabel.TabIndex = 8;
            priceLabel.Text = "Стоимость:";
            // 
            // companyNameTextBox
            // 
            companyNameTextBox.Location = new Point(128, 63);
            companyNameTextBox.Name = "companyNameTextBox";
            companyNameTextBox.Size = new Size(256, 23);
            companyNameTextBox.TabIndex = 9;
            // 
            // destinationTextBox
            // 
            destinationTextBox.Location = new Point(128, 92);
            destinationTextBox.Name = "destinationTextBox";
            destinationTextBox.Size = new Size(256, 23);
            destinationTextBox.TabIndex = 10;
            // 
            // departureDateTimePicker
            // 
            departureDateTimePicker.Location = new Point(128, 121);
            departureDateTimePicker.Name = "departureDateTimePicker";
            departureDateTimePicker.Size = new Size(200, 23);
            departureDateTimePicker.TabIndex = 11;
            // 
            // priceNumericUpDown
            // 
            priceNumericUpDown.Location = new Point(128, 150);
            priceNumericUpDown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            priceNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            priceNumericUpDown.Name = "priceNumericUpDown";
            priceNumericUpDown.Size = new Size(120, 23);
            priceNumericUpDown.TabIndex = 12;
            priceNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // addFlightButton
            // 
            addFlightButton.Location = new Point(128, 223);
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
            editListBox.Location = new Point(128, 260);
            editListBox.Name = "editListBox";
            editListBox.Size = new Size(256, 154);
            editListBox.TabIndex = 14;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(12, 223);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(110, 31);
            resetButton.TabIndex = 15;
            resetButton.Text = "Сброс";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(128, 420);
            editButton.Name = "editButton";
            editButton.Size = new Size(256, 48);
            editButton.TabIndex = 16;
            editButton.Text = "Редактировать";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(12, 260);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(110, 154);
            pictureBox.TabIndex = 17;
            pictureBox.TabStop = false;
            // 
            // photoButton
            // 
            photoButton.Location = new Point(128, 179);
            photoButton.Name = "photoButton";
            photoButton.Size = new Size(96, 29);
            photoButton.TabIndex = 18;
            photoButton.Text = "Выбрать фото";
            photoButton.UseVisualStyleBackColor = true;
            photoButton.Click += photoButton_Click;
            // 
            // fileSaveButton
            // 
            fileSaveButton.Location = new Point(6, 355);
            fileSaveButton.Name = "fileSaveButton";
            fileSaveButton.Size = new Size(190, 39);
            fileSaveButton.TabIndex = 1;
            fileSaveButton.Text = "Сохранить в файл";
            fileSaveButton.UseVisualStyleBackColor = true;
            fileSaveButton.Click += fileSaveButton_Click;
            // 
            // fileLoadButton
            // 
            fileLoadButton.Location = new Point(202, 355);
            fileLoadButton.Name = "fileLoadButton";
            fileLoadButton.Size = new Size(190, 39);
            fileLoadButton.TabIndex = 2;
            fileLoadButton.Text = "Загрузить из файла";
            fileLoadButton.UseVisualStyleBackColor = true;
            fileLoadButton.Click += fileLoadButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 480);
            Controls.Add(photoButton);
            Controls.Add(pictureBox);
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
            Controls.Add(refreshButton);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
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
    }
}
