namespace Venue.UI.Forms
{
    partial class AdminAddOwner
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            checkBox1 = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();

            SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular);
            label1.ForeColor = Color.Maroon;
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(250, 40);
            label1.Text = "Add Owner";

            // Username label
            label2.AutoSize = true;
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(20, 80);
            label2.Text = "Username";

            // textBox1 (username)
            textBox1.BackColor = Color.FromArgb(255, 224, 192);
            textBox1.Location = new Point(20, 105);
            textBox1.Size = new Size(250, 27);

            // Email label
            label3.AutoSize = true;
            label3.ForeColor = Color.Maroon;
            label3.Location = new Point(20, 140);
            label3.Text = "Email";

            // textBox2 (email)
            textBox2.BackColor = Color.FromArgb(255, 224, 192);
            textBox2.Location = new Point(20, 165);
            textBox2.Size = new Size(250, 27);

            // Password label
            label4.AutoSize = true;
            label4.ForeColor = Color.Maroon;
            label4.Location = new Point(20, 200);
            label4.Text = "Password";

            // textBox3 (password)
            textBox3.BackColor = Color.FromArgb(255, 224, 192);
            textBox3.Location = new Point(20, 225);
            textBox3.Size = new Size(250, 27);
            textBox3.UseSystemPasswordChar = true;

            // checkbox show password
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = Color.Maroon;
            checkBox1.Location = new Point(20, 260);
            checkBox1.Text = "Show Password";
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;

            // button register
            button1.BackColor = Color.LightCoral;
            button1.ForeColor = Color.White;
            button1.Location = new Point(20, 300);
            button1.Size = new Size(250, 45);
            button1.Text = "Register";
            button1.Click += button1_Click;

            // button back/login
            button2.BackColor = Color.LightCoral;
            button2.ForeColor = Color.White;
            button2.Location = new Point(20, 355);
            button2.Size = new Size(250, 45);
            button2.Text = "Back";
            button2.Click += button2_Click;

            // form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaShell;
            ClientSize = new Size(300, 430);
            FormBorderStyle = FormBorderStyle.None;
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(button2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminAddOwner";

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private CheckBox checkBox1;
        private Button button1;
        private Button button2;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}