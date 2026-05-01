using Microsoft.Extensions.DependencyInjection;
using Venue.Application.Dto.User;
using Venue.Application.Services.Account;
using Venue.UI;
using Venue.UI.Helpers;

namespace Loginmenu
{
    public partial class Registering : Form
    {
        public Registering()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var _userservice = Program.Services.GetService<IUserService>();
            if (_userservice == null)
            {
                MessageBox.Show("User service is not available.");
                return;
            }

            var dto = new RegisterDto()
            {
                UserName = textBox1.Text,
                Email = textBox3.Text,
                Password = textBox4.Text,
            };

            var response = await _userservice.RegisterAsync(dto);

            if (response.IsSuccess)
            {
                var loginForm = new Login_menu();
                loginForm.Show();
                this.Hide();
            }
            else
            {
                ErrorShower.ShowError(response);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginForm = new Login_menu();
            loginForm.Show();
            this.Hide();
        }
    }
}
