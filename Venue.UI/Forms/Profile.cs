using Loginmenu;
using Microsoft.Extensions.DependencyInjection;
using Venue.Application.Dtos.User;
using Venue.Application.Services.Account;
using Venue.Domain.Interfaces;
using Venue.UI.Helpers;

namespace Venue.UI.Forms
{
    public partial class Profile : Form
    {
        private readonly IUserService _userService;
        private readonly IUserPasswordService _userPasswordService;
        private readonly ICurrentUserService _currentUserService;

        public Profile()
        {
            InitializeComponent();
            _userService = Program.Services.GetService<IUserService>() ?? throw new Exception("User Service not configured");
            _userPasswordService = Program.Services.GetService<IUserPasswordService>() ?? throw new Exception("User Password Service not configured");
            _currentUserService = Program.Services.GetService<ICurrentUserService>() ?? throw new Exception("Current User service not configured");

            if (_currentUserService.UserId == null)
            {
                ErrorShower.ShowError("No user is currently logged in. Please log in to continue.");
                this.Close();
            }

            Load += LoadData!;

            if (_currentUserService.Role == Venue.Domain.Enums.UserRole.User)
                label4.Hide();
            if (_currentUserService.Role == Venue.Domain.Enums.UserRole.Admin)
                linkLabel4.Show();
            else if (_currentUserService.Role == Venue.Domain.Enums.UserRole.Owner)
                linkLabel3.Show();
        }

        private async void LoadData(object sender, EventArgs e)
        {
            var userResponse = await _userService.GetCurrentUser();
            if (!userResponse.IsSuccess)
            {
                ErrorShower.ShowError(userResponse);
            }

            var user = userResponse.Data;

            if (user != null)
            {
                textBox3.Text = user.UserName;
                label19.Text = user.UserName;

                label11.Text = user.Email;
                label20.Text = user.Email;

                label24.Text = user.JoinedAt.ToString("dd/MM/yyyy");

                label12.Text = user.UserRole.ToString();

                if (user.UserRole == Domain.Enums.UserRole.User)
                {
                    label12.BackColor = Color.Green;
                }
                else if (user.UserRole == Domain.Enums.UserRole.Owner)
                {
                    label12.BackColor = Color.Blue;
                }
                else if (user.UserRole == Domain.Enums.UserRole.Admin)
                {
                    label12.BackColor = Color.Red;
                }
            }
            else
            {
                ErrorShower.ShowError("Failed to load user data.");
                this.Close();
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var UsersPage = new Users();
            UsersPage.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var myvenues = new myvenues();
            myvenues.Show();
            this.Hide();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != textBox9.Text)
            {
                ErrorShower.ShowError("New password and confirm password do not match.");
                return;
            }

            var passwordDto = new ChangePasswordRequest
            {
                CurrentPassword = textBox6.Text,
                NewPassword = textBox8.Text,
            };

            var response = await _userPasswordService.ChangePasswordAsync(passwordDto);

            if (response.IsSuccess)
            {
                MessageBox.Show("Password changed successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox6.Clear();
                textBox8.Clear();
                textBox9.Clear();
            }
            else
            {
                ErrorShower.ShowError(response);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var homepage = new mainscreen();
            homepage.Show();
            this.Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var response = await _userService.LogoutAsync();
            if (!response.IsSuccess)
            {
                ErrorShower.ShowError(response);
                return;
            }

            var loginForm = new Login_menu();
            loginForm.ShowDialog();
            this.Hide();
        }
    }
}
