using Loginmenu;
using Microsoft.Extensions.DependencyInjection;
using Venue.Application.Services.Admin;
using Venue.Domain.Interfaces;
using Venue.UI.Helpers;

namespace Venue.UI.Forms
{
    public partial class Users : Form
    {
        private readonly IAdminService _adminService;
        private readonly ICurrentUserService _currentUserService;

        public Users()
        {
            InitializeComponent();

            _adminService = Program.Services.GetService<IAdminService>() ?? throw new Exception("Admin service not configured");
            _currentUserService = Program.Services.GetService<ICurrentUserService>() ?? throw new Exception("Current User service not configured");

            Load += LoadData!;

            if (_currentUserService.UserId == null)
            {
                ErrorShower.ShowError("No user is currently logged in. Please log in to continue.");
                this.Close();
            }

            if (_currentUserService.Role != Domain.Enums.UserRole.Admin)
            {
                ErrorShower.ShowError("Invalid Credentials!");
                this.Close();
            }

            ClearUsers();
        }

        public async void LoadData(object sender, EventArgs e)
        {
            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            var usersResponse = await _adminService.GetUsersAsync(new Application.Dtos.Admin.AdminSearchDto()
            {
                SortByType = Application.Common.SortByType.Descending,
                PageNumber = 1,
                PageSize = 7
            });

            if (!usersResponse.IsSuccess)
            {
                ErrorShower.ShowError(usersResponse);
                return;
            }

            var users = usersResponse.Data?.Users ?? new List<Application.Dtos.Admin.AdminUserDto>();
            var rows = GetUserRows();

            for (var i = 0; i < rows.Length; i++)
            {
                if (i >= users.Count)
                {
                    rows[i].Panel.Visible = false;
                    continue;
                }

                var user = users[i];
                rows[i].Panel.Visible = true;
                rows[i].Name.Text = user.UserName;
                rows[i].Email.Text = user.Email;
                rows[i].Joined.Text = user.JoinedAt.ToString("MMM yyyy");
                rows[i].Delete.Tag = user.Id;
                rows[i].Delete.Click -= DeleteButton_Click!;
                rows[i].Delete.Click += DeleteButton_Click!;
            }
        }

        private void ClearUsers()
        {
            foreach (var row in GetUserRows())
            {
                row.Panel.Visible = false;
                row.Name.Text = string.Empty;
                row.Email.Text = string.Empty;
                row.Joined.Text = string.Empty;
                row.Delete.Tag = null;
            }
        }

        private (Panel Panel, Label Name, Label Email, Label Joined, Button Delete)[] GetUserRows()
        {
            return new (Panel Panel, Label Name, Label Email, Label Joined, Button Delete)[]
            {
                (panel4, label46, label38, label22, button3),
                (panel5, label48, label39, label23, button4),
                (panel13, label49, label40, label24, button5),
                (panel16, label50, label41, label25, button6),
                (panel17, label52, label43, label27, button8),
                (panel18, label53, label44, label28, button9),
                (panel19, label54, label45, label29, button10)
            };
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is Guid userId)
            {
                DeleteUser(userId);
            }
        }

        private async void buttonAddOwner_Click(object sender, EventArgs e)
        {
            using var form = new AdminAddOwner();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                await LoadUsersAsync();
            }
        }

        public async void DeleteUser(Guid userId)
        {
            var deleteResponse = await _adminService.DeleteUserAsync(new Application.Dtos.Admin.AdminDeleteUserDto { UserId = userId });
            if (!deleteResponse.IsSuccess)
            {
                ErrorShower.ShowError(deleteResponse);
                return;
            }

            MessageBox.Show("User deleted successfully.");
            await LoadUsersAsync();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var mainScreenForm = new mainscreen();
            mainScreenForm.Show();
            this.Hide();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var MyProfile = new Profile();
            MyProfile.Show();
            this.Hide();
        }
    }
}
