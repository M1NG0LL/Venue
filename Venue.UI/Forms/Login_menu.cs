using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Venue.Application.Services.Account;
using Venue.UI;
using Venue.UI.Forms;

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

        private async void button1_Click(object sender, EventArgs e)
        {
            var _userservice = Program.Services.GetService<IUserService>();

            if (_userservice == null)
            {
                MessageBox.Show("User service is not available.");
                return;
            }

            var email = textBox1.Text;
            var password = textBox2.Text;

            var response = await _userservice.LoginAsync(new Venue.Application.Dto.User.LoginDto()
            {
                UserNameOrEmail = email,
                Password = password
            });

            if (!response.IsSuccess)
            {
                MessageBox.Show(response.Message);
                return;
            }

            var mainScreenForm = new Home();
            mainScreenForm.Show();

            this.Hide();
        }
    }
}
