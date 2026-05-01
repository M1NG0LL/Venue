using Microsoft.Extensions.DependencyInjection;
using Venue.Application.Dtos.Venue;
using Venue.Application.Services.Venue;
using Venue.Domain.Interfaces;
using Venue.UI;
using Venue.UI.Forms;
using Venue.UI.Helpers;

namespace Loginmenu
{
    public partial class mainscreen : Form
    {
        private readonly IVenueService _venueService;
        private readonly ICurrentUserService _currentUserService;

        public mainscreen()
        {
            InitializeComponent();
            _venueService = Program.Services.GetService<IVenueService>() ?? throw new Exception("Venue service not configured");
            _currentUserService = Program.Services.GetService<ICurrentUserService>() ?? throw new Exception("Current User service not configured");

            Load += mainscreen_Load!;

            if (_currentUserService.UserId == null) 
            {
                ErrorShower.ShowError("No user is currently logged in. Please log in to continue.");
                this.Close();
            }

            if (_currentUserService.Role == Venue.Domain.Enums.UserRole.User)
                label4.Hide();
            if (_currentUserService.Role == Venue.Domain.Enums.UserRole.Admin)
                linkLabel4.Show();
            else if (_currentUserService.Role == Venue.Domain.Enums.UserRole.Owner)
                linkLabel3.Show();
            
            ClearVenueCards();
        }

        private async void mainscreen_Load(object sender, EventArgs e)
        {
            await LoadVenuesAsync();
        }

        private async Task LoadVenuesAsync()
        {
            var response = await _venueService.SearchAsync(new VenueSearchDto
            {
                PageNumber = 1,
                PageSize = 6
            });

            if (!response.IsSuccess || response.Data == null)
            {
                ErrorShower.ShowError(response.Message);
                ClearVenueCards();
                return;
            }

            var venues = response.Data;
            var cards = new (Panel Panel, Label Name, Label Description, Label Rating, Label Reviews, PictureBox Picture)[]
            {
                (panel3, label7, label8, label9, label10, pictureBox1),
                (panel4, label14, label13, label12, label11, pictureBox2),
                (panel5, label18, label17, label16, label15, pictureBox3),
                (panel6, label22, label21, label20, label19, pictureBox4),
                (panel7, label26, label25, label24, label23, pictureBox5),
                (panel8, label30, label29, label28, label27, pictureBox6)
            };

            for (var i = 0; i < cards.Length; i++)
            {
                if (i >= venues.Count)
                {
                    cards[i].Panel.Visible = false;
                    continue;
                }

                var venue = venues[i];
                cards[i].Panel.Visible = true;
                cards[i].Name.Text = venue.Name;
                cards[i].Description.Text = venue.Description;
                cards[i].Rating.Text = $"Rating: {venue.Rating:0.0}";
                cards[i].Reviews.Text = $"Reviews: {venue.TotalRating}";

                if (!string.IsNullOrWhiteSpace(venue.ImagePath))
                {
                    cards[i].Picture.ImageLocation = venue.ImagePath;
                    cards[i].Picture.Visible = true;
                }
                else
                {
                    cards[i].Picture.ImageLocation = null;
                    cards[i].Picture.Image = null;
                    cards[i].Picture.Visible = false;
                }
            }
        }

        private void ClearVenueCards()
        {
            var cards = new (Panel Panel, Label Name, Label Description, Label Rating, Label Reviews, PictureBox Picture)[]
            {
                (panel3, label7, label8, label9, label10, pictureBox1),
                (panel4, label14, label13, label12, label11, pictureBox2),
                (panel5, label18, label17, label16, label15, pictureBox3),
                (panel6, label22, label21, label20, label19, pictureBox4),
                (panel7, label26, label25, label24, label23, pictureBox5),
                (panel8, label30, label29, label28, label27, pictureBox6)
            };

            foreach (var card in cards)
            {
                card.Panel.Visible = false;
                card.Name.Text = string.Empty;
                card.Description.Text = string.Empty;
                card.Rating.Text = string.Empty;
                card.Reviews.Text = string.Empty;
                card.Picture.ImageLocation = null;
                card.Picture.Image = null;
                card.Picture.Visible = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var myvenues = new myvenues();
            myvenues.Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var UsersPage = new Users();
            UsersPage.Show();
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
