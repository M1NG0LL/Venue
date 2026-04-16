using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loginmenu
{
    public partial class Login_menu : Form
    {
        public Login_menu()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            button2.Click += button2_Click;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var registeringForm = new Registering();
            registeringForm.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
