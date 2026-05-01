using Microsoft.Extensions.DependencyInjection;
using Venue.Application.Dto.User;
using Venue.Application.Services.Account;
using Venue.UI.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Venue.UI.Forms
{
    public partial class AdminAddOwner : Form
    {
        public AdminAddOwner()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string password = textBox3.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All fields are required.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!email.Contains("@"))
            {
                MessageBox.Show("Invalid email format.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var _userservice = Program.Services.GetService<IUserService>();
            if (_userservice == null)
            {
                MessageBox.Show("User service is not available.");
                return;
            }

            var dto = new RegisterDto()
            {
                UserName = username,
                Email = email,
                Password = password,
            };

            var response = await _userservice.RegisterAsync(dto, Domain.Enums.UserRole.Owner);
            if (!response.IsSuccess)
            {
                ErrorShower.ShowError(response);
                return;
            }

            ClearFields();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            checkBox1.Checked = false;
        }
    }
}