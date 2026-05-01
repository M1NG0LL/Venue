using Microsoft.Extensions.DependencyInjection;
using Venue.Application.Dtos.Review;
using Venue.Application.Services.Review;
using Venue.Application.Services.Venue;
using Venue.Domain.Interfaces;
using Venue.UI.Helpers;

namespace Venue.UI.Forms
{
    public partial class VenueDetails : Form
    {
        private readonly IVenueService _venueService;
        private readonly IReviewService _reviewService;
        private readonly ICurrentUserService _currentUserService;
        private readonly Guid _venueId;
        private string _venueName = string.Empty;

        public VenueDetails(Guid venueId)
        {
            InitializeComponent();
            _venueId = venueId;
            _venueService = Program.Services.GetService<IVenueService>() ?? throw new Exception("Venue service not configured");
            _reviewService = Program.Services.GetService<IReviewService>() ?? throw new Exception("Review service not configured");
            _currentUserService = Program.Services.GetService<ICurrentUserService>() ?? throw new Exception("Current User service not configured");

            if (_currentUserService.UserId == null)
            {
                ErrorShower.ShowError("No user is currently logged in. Please log in to continue.");
                Close();
                return;
            }

            if (_currentUserService.Role == Venue.Domain.Enums.UserRole.User)
                label4.Hide();
            if (_currentUserService.Role == Venue.Domain.Enums.UserRole.Admin)
                linkLabel4.Show();
            else if (_currentUserService.Role == Venue.Domain.Enums.UserRole.Owner)
                linkLabel3.Show();

            Load += VenueDetails_Load!;
        }

        private async void VenueDetails_Load(object sender, EventArgs e)
        {
            await LoadVenueDetailsAsync();
        }

        private async Task LoadVenueDetailsAsync()
        {
            var response = await _venueService.GetByIdAsync(_venueId);

            if (!response.IsSuccess || response.Data == null)
            {
                ErrorShower.ShowError(response);
                Close();
                return;
            }

            var venue = response.Data;
            _venueName = venue.Name;

            labelVenueName.Text = venue.Name;
            labelVenueDescription.Text = venue.Description;
            labelVenueRating.Text = $"Rating: {venue.Rating:0.0}";
            labelVenueReviews.Text = $"Reviews: {venue.TotalRating}";
            labelVenueCapacity.Text = $"Capacity: {venue.Info.SeatingCapacity}";
            labelVenuePrice.Text = $"Price: {venue.Info.PricePerEvent:C}";
            labelVenueDays.Text = $"Available days: {string.Join(", ", venue.Info.AvailableDays)}";
            labelVenuePhone.Text = $"Phone: {venue.ContactInfo.Phone}";
            labelVenueEmail.Text = $"Email: {venue.ContactInfo.Email}";
            labelVenueAddress.Text = $"Address: {venue.ContactInfo.Address ?? "N/A"}";
            labelVenueLocation.Text = $"Location: {venue.ContactInfo.Location.X:0.####}, {venue.ContactInfo.Location.Y:0.####}";

            if (!string.IsNullOrWhiteSpace(venue.ImagePath))
            {
                pictureBoxVenue.ImageLocation = venue.ImagePath;
                pictureBoxVenue.Visible = true;
            }
            else
            {
                pictureBoxVenue.ImageLocation = null;
                pictureBoxVenue.Image = null;
                pictureBoxVenue.Visible = false;
            }

            listBoxReviews.Items.Clear();
            if (venue.Reviews.Count == 0)
            {
                listBoxReviews.Items.Add("No reviews yet.");
                return;
            }

            foreach (var review in venue.Reviews.OrderByDescending(r => r.CreatedAt))
            {
                var comment = string.IsNullOrWhiteSpace(review.Comment) ? "No comment" : review.Comment;
                listBoxReviews.Items.Add($"{review.Rate}/5 - {comment} ({review.CreatedAt:yyyy-MM-dd})");
            }
        }

        private async void buttonAddReview_Click(object sender, EventArgs e)
        {
            using var dialog = new AddReviewForm();
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            var dto = new CreateReviewDto
            {
                VenueId = _venueId,
                Rate = dialog.Rate,
                Comment = dialog.Comment
            };

            var response = await _reviewService.CreateAsync(dto);
            if (!response.IsSuccess)
            {
                ErrorShower.ShowError(response);
                return;
            }

            await LoadVenueDetailsAsync();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var home = new Home();
            home.Show();
            Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var myvenues = new MyVenues();
            myvenues.Show();
            Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var usersPage = new Users();
            usersPage.Show();
            Hide();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var myProfile = new Profile();
            myProfile.Show();
            Hide();
        }

        private sealed class AddReviewForm : Form
        {
            private readonly NumericUpDown _rateInput;
            private readonly TextBox _commentInput;

            public int Rate => (int)_rateInput.Value;
            public string? Comment => string.IsNullOrWhiteSpace(_commentInput.Text) ? null : _commentInput.Text.Trim();

            public AddReviewForm()
            {
                Text = "Add Review";
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;
                StartPosition = FormStartPosition.CenterParent;
                ClientSize = new Size(420, 220);

                var labelRate = new Label
                {
                    Text = "Rating (1-5)",
                    Location = new Point(20, 20),
                    AutoSize = true
                };

                _rateInput = new NumericUpDown
                {
                    Minimum = 1,
                    Maximum = 5,
                    Value = 5,
                    Location = new Point(140, 18),
                    Size = new Size(80, 27)
                };

                var labelComment = new Label
                {
                    Text = "Comment",
                    Location = new Point(20, 60),
                    AutoSize = true
                };

                _commentInput = new TextBox
                {
                    Location = new Point(20, 85),
                    Size = new Size(380, 60),
                    Multiline = true
                };

                var buttonOk = new Button
                {
                    Text = "Save",
                    DialogResult = DialogResult.OK,
                    Location = new Point(220, 165),
                    Size = new Size(85, 30)
                };

                var buttonCancel = new Button
                {
                    Text = "Cancel",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(315, 165),
                    Size = new Size(85, 30)
                };

                Controls.Add(labelRate);
                Controls.Add(_rateInput);
                Controls.Add(labelComment);
                Controls.Add(_commentInput);
                Controls.Add(buttonOk);
                Controls.Add(buttonCancel);

                AcceptButton = buttonOk;
                CancelButton = buttonCancel;
            }
        }
    }
}
