namespace Venue.UI.Forms
{
    partial class AddVenueForm
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel layout;
        private FlowLayoutPanel buttonPanel;
        private Label labelTitle;
        private Label labelName;
        private Label labelDescription;
        private Label labelAddress;
        private Label labelPhone;
        private Label labelEmail;
        private Label labelCapacity;
        private Label labelPrice;
        private Label labelLocationX;
        private Label labelLocationY;
        private Label labelAvailableDays;
        private TextBox nameTextBox;
        private TextBox descriptionTextBox;
        private TextBox addressTextBox;
        private TextBox phoneTextBox;
        private TextBox emailTextBox;
        private NumericUpDown capacityInput;
        private NumericUpDown priceInput;
        private NumericUpDown locationXInput;
        private NumericUpDown locationYInput;
        private CheckedListBox availableDays;
        private Button createButton;
        private Button cancelButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            layout = new TableLayoutPanel();
            labelTitle = new Label();
            labelName = new Label();
            labelDescription = new Label();
            labelAddress = new Label();
            labelPhone = new Label();
            labelEmail = new Label();
            labelCapacity = new Label();
            labelPrice = new Label();
            labelLocationX = new Label();
            labelLocationY = new Label();
            labelAvailableDays = new Label();
            nameTextBox = new TextBox();
            descriptionTextBox = new TextBox();
            addressTextBox = new TextBox();
            phoneTextBox = new TextBox();
            emailTextBox = new TextBox();
            capacityInput = new NumericUpDown();
            priceInput = new NumericUpDown();
            locationXInput = new NumericUpDown();
            locationYInput = new NumericUpDown();
            availableDays = new CheckedListBox();
            buttonPanel = new FlowLayoutPanel();
            createButton = new Button();
            cancelButton = new Button();
            layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)capacityInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)locationXInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)locationYInput).BeginInit();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // layout
            // 
            layout.AutoScroll = true;
            layout.ColumnCount = 2;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.Controls.Add(labelTitle, 0, 0);
            layout.Controls.Add(labelName, 0, 1);
            layout.Controls.Add(nameTextBox, 1, 1);
            layout.Controls.Add(labelDescription, 0, 2);
            layout.Controls.Add(descriptionTextBox, 1, 2);
            layout.Controls.Add(labelAddress, 0, 3);
            layout.Controls.Add(addressTextBox, 1, 3);
            layout.Controls.Add(labelPhone, 0, 4);
            layout.Controls.Add(phoneTextBox, 1, 4);
            layout.Controls.Add(labelEmail, 0, 5);
            layout.Controls.Add(emailTextBox, 1, 5);
            layout.Controls.Add(labelCapacity, 0, 6);
            layout.Controls.Add(capacityInput, 1, 6);
            layout.Controls.Add(labelPrice, 0, 7);
            layout.Controls.Add(priceInput, 1, 7);
            layout.Controls.Add(labelLocationX, 0, 8);
            layout.Controls.Add(locationXInput, 1, 8);
            layout.Controls.Add(labelLocationY, 0, 9);
            layout.Controls.Add(locationYInput, 1, 9);
            layout.Controls.Add(labelAvailableDays, 0, 10);
            layout.Controls.Add(availableDays, 1, 10);
            layout.Controls.Add(buttonPanel, 0, 11);
            layout.Dock = DockStyle.Fill;
            layout.Location = new Point(0, 0);
            layout.Name = "layout";
            layout.Padding = new Padding(16);
            layout.RowCount = 12;
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.Size = new Size(520, 640);
            layout.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Left;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.Maroon;
            labelTitle.Location = new Point(19, 21);
            labelTitle.Margin = new Padding(3, 6, 3, 10);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(154, 39);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Add Venue";
            layout.SetColumnSpan(labelTitle, 2);
            // 
            // labelName
            // 
            labelName.Anchor = AnchorStyles.Left;
            labelName.AutoSize = true;
            labelName.ForeColor = Color.Maroon;
            labelName.Location = new Point(19, 81);
            labelName.Margin = new Padding(3, 6, 3, 6);
            labelName.Name = "labelName";
            labelName.Size = new Size(49, 20);
            labelName.TabIndex = 1;
            labelName.Text = "Name";
            // 
            // labelDescription
            // 
            labelDescription.Anchor = AnchorStyles.Left;
            labelDescription.AutoSize = true;
            labelDescription.ForeColor = Color.Maroon;
            labelDescription.Location = new Point(19, 119);
            labelDescription.Margin = new Padding(3, 6, 3, 6);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(85, 20);
            labelDescription.TabIndex = 2;
            labelDescription.Text = "Description";
            // 
            // labelAddress
            // 
            labelAddress.Anchor = AnchorStyles.Left;
            labelAddress.AutoSize = true;
            labelAddress.ForeColor = Color.Maroon;
            labelAddress.Location = new Point(19, 195);
            labelAddress.Margin = new Padding(3, 6, 3, 6);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(62, 20);
            labelAddress.TabIndex = 3;
            labelAddress.Text = "Address";
            // 
            // labelPhone
            // 
            labelPhone.Anchor = AnchorStyles.Left;
            labelPhone.AutoSize = true;
            labelPhone.ForeColor = Color.Maroon;
            labelPhone.Location = new Point(19, 233);
            labelPhone.Margin = new Padding(3, 6, 3, 6);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(50, 20);
            labelPhone.TabIndex = 4;
            labelPhone.Text = "Phone";
            // 
            // labelEmail
            // 
            labelEmail.Anchor = AnchorStyles.Left;
            labelEmail.AutoSize = true;
            labelEmail.ForeColor = Color.Maroon;
            labelEmail.Location = new Point(19, 271);
            labelEmail.Margin = new Padding(3, 6, 3, 6);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(46, 20);
            labelEmail.TabIndex = 5;
            labelEmail.Text = "Email";
            // 
            // labelCapacity
            // 
            labelCapacity.Anchor = AnchorStyles.Left;
            labelCapacity.AutoSize = true;
            labelCapacity.ForeColor = Color.Maroon;
            labelCapacity.Location = new Point(19, 309);
            labelCapacity.Margin = new Padding(3, 6, 3, 6);
            labelCapacity.Name = "labelCapacity";
            labelCapacity.Size = new Size(68, 20);
            labelCapacity.TabIndex = 6;
            labelCapacity.Text = "Capacity";
            // 
            // labelPrice
            // 
            labelPrice.Anchor = AnchorStyles.Left;
            labelPrice.AutoSize = true;
            labelPrice.ForeColor = Color.Maroon;
            labelPrice.Location = new Point(19, 347);
            labelPrice.Margin = new Padding(3, 6, 3, 6);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(76, 20);
            labelPrice.TabIndex = 7;
            labelPrice.Text = "Price/Event";
            // 
            // labelLocationX
            // 
            labelLocationX.Anchor = AnchorStyles.Left;
            labelLocationX.AutoSize = true;
            labelLocationX.ForeColor = Color.Maroon;
            labelLocationX.Location = new Point(19, 385);
            labelLocationX.Margin = new Padding(3, 6, 3, 6);
            labelLocationX.Name = "labelLocationX";
            labelLocationX.Size = new Size(77, 20);
            labelLocationX.TabIndex = 8;
            labelLocationX.Text = "Location X";
            // 
            // labelLocationY
            // 
            labelLocationY.Anchor = AnchorStyles.Left;
            labelLocationY.AutoSize = true;
            labelLocationY.ForeColor = Color.Maroon;
            labelLocationY.Location = new Point(19, 423);
            labelLocationY.Margin = new Padding(3, 6, 3, 6);
            labelLocationY.Name = "labelLocationY";
            labelLocationY.Size = new Size(77, 20);
            labelLocationY.TabIndex = 9;
            labelLocationY.Text = "Location Y";
            // 
            // labelAvailableDays
            // 
            labelAvailableDays.Anchor = AnchorStyles.Left;
            labelAvailableDays.AutoSize = true;
            labelAvailableDays.ForeColor = Color.Maroon;
            labelAvailableDays.Location = new Point(19, 461);
            labelAvailableDays.Margin = new Padding(3, 6, 3, 6);
            labelAvailableDays.Name = "labelAvailableDays";
            labelAvailableDays.Size = new Size(102, 20);
            labelAvailableDays.TabIndex = 10;
            labelAvailableDays.Text = "Available Days";
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = Color.FromArgb(255, 224, 192);
            nameTextBox.Dock = DockStyle.Fill;
            nameTextBox.Location = new Point(159, 79);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(342, 27);
            nameTextBox.TabIndex = 11;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.BackColor = Color.FromArgb(255, 224, 192);
            descriptionTextBox.Dock = DockStyle.Fill;
            descriptionTextBox.Location = new Point(159, 117);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(342, 70);
            descriptionTextBox.TabIndex = 12;
            // 
            // addressTextBox
            // 
            addressTextBox.BackColor = Color.FromArgb(255, 224, 192);
            addressTextBox.Dock = DockStyle.Fill;
            addressTextBox.Location = new Point(159, 193);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(342, 27);
            addressTextBox.TabIndex = 13;
            // 
            // phoneTextBox
            // 
            phoneTextBox.BackColor = Color.FromArgb(255, 224, 192);
            phoneTextBox.Dock = DockStyle.Fill;
            phoneTextBox.Location = new Point(159, 231);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(342, 27);
            phoneTextBox.TabIndex = 14;
            // 
            // emailTextBox
            // 
            emailTextBox.BackColor = Color.FromArgb(255, 224, 192);
            emailTextBox.Dock = DockStyle.Fill;
            emailTextBox.Location = new Point(159, 269);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(342, 27);
            emailTextBox.TabIndex = 15;
            // 
            // capacityInput
            // 
            capacityInput.Dock = DockStyle.Left;
            capacityInput.Location = new Point(159, 307);
            capacityInput.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            capacityInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            capacityInput.Name = "capacityInput";
            capacityInput.Size = new Size(120, 27);
            capacityInput.TabIndex = 16;
            capacityInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // priceInput
            // 
            priceInput.DecimalPlaces = 2;
            priceInput.Dock = DockStyle.Left;
            priceInput.Location = new Point(159, 345);
            priceInput.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            priceInput.Name = "priceInput";
            priceInput.Size = new Size(120, 27);
            priceInput.TabIndex = 17;
            // 
            // locationXInput
            // 
            locationXInput.DecimalPlaces = 6;
            locationXInput.Dock = DockStyle.Left;
            locationXInput.Location = new Point(159, 383);
            locationXInput.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            locationXInput.Minimum = new decimal(new int[] { 180, 0, 0, int.MinValue });
            locationXInput.Name = "locationXInput";
            locationXInput.Size = new Size(120, 27);
            locationXInput.TabIndex = 18;
            // 
            // locationYInput
            // 
            locationYInput.DecimalPlaces = 6;
            locationYInput.Dock = DockStyle.Left;
            locationYInput.Location = new Point(159, 421);
            locationYInput.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
            locationYInput.Minimum = new decimal(new int[] { 90, 0, 0, int.MinValue });
            locationYInput.Name = "locationYInput";
            locationYInput.Size = new Size(120, 27);
            locationYInput.TabIndex = 19;
            // 
            // availableDays
            // 
            availableDays.BackColor = Color.FromArgb(255, 224, 192);
            availableDays.CheckOnClick = true;
            availableDays.Dock = DockStyle.Fill;
            availableDays.FormattingEnabled = true;
            availableDays.Items.AddRange(new object[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" });
            availableDays.Location = new Point(159, 459);
            availableDays.Name = "availableDays";
            availableDays.Size = new Size(342, 84);
            availableDays.TabIndex = 20;
            // 
            // buttonPanel
            // 
            buttonPanel.AutoSize = true;
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonPanel.Controls.Add(createButton);
            buttonPanel.Controls.Add(cancelButton);
            buttonPanel.Location = new Point(19, 549);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(482, 41);
            buttonPanel.TabIndex = 21;
            layout.SetColumnSpan(buttonPanel, 2);
            // 
            // createButton
            // 
            createButton.BackColor = Color.LightCoral;
            createButton.ForeColor = Color.Black;
            createButton.Location = new Point(379, 3);
            createButton.Name = "createButton";
            createButton.Size = new Size(100, 29);
            createButton.TabIndex = 0;
            createButton.Text = "Create";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += CreateButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.LightCoral;
            cancelButton.ForeColor = Color.Black;
            cancelButton.Location = new Point(273, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 29);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;
            // 
            // AddVenueForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaShell;
            ClientSize = new Size(520, 640);
            Controls.Add(layout);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddVenueForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Venue";
            layout.ResumeLayout(false);
            layout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)capacityInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)locationXInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)locationYInput).EndInit();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
