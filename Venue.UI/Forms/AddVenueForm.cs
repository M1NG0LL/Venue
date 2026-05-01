using System.Globalization;
using System.Linq;
using Venue.Application.Dtos.Common;
using Venue.Application.Dtos.Venue;
using Venue.UI.Helpers;

namespace Venue.UI.Forms
{
    public sealed partial class AddVenueForm : Form
    {
        public CreateVenueDto? VenueDto { get; private set; }

        public AddVenueForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void CreateButton_Click(object? sender, EventArgs e)
        {
            if (!TryBuildDto(out var dto))
            {
                return;
            }

            VenueDto = dto;
            DialogResult = DialogResult.OK;
        }

        private bool TryBuildDto(out CreateVenueDto dto)
        {
            dto = null!;

            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                ErrorShower.ShowError("Name is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                ErrorShower.ShowError("Description is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                ErrorShower.ShowError("Phone is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                ErrorShower.ShowError("Email is required.");
                return false;
            }

            if (availableDays.CheckedItems.Count == 0)
            {
                ErrorShower.ShowError("Select at least one available day.");
                return false;
            }

            var days = availableDays.CheckedItems
                .Cast<string>()
                .Select(day => Enum.Parse<DayOfWeek>(day, true))
                .ToList();

            dto = new CreateVenueDto
            {
                Name = nameTextBox.Text.Trim(),
                Description = descriptionTextBox.Text.Trim(),
                ContactInfo = new VenueContactInfoDto
                {
                    Phone = phoneTextBox.Text.Trim(),
                    Email = emailTextBox.Text.Trim(),
                    Address = string.IsNullOrWhiteSpace(addressTextBox.Text) ? null : addressTextBox.Text.Trim(),
                    Location = new LocationDto
                    {
                        X = Convert.ToDouble(locationXInput.Value, CultureInfo.InvariantCulture),
                        Y = Convert.ToDouble(locationYInput.Value, CultureInfo.InvariantCulture)
                    }
                },
                Info = new VenueConfigurationDto
                {
                    SeatingCapacity = (int)capacityInput.Value,
                    PricePerEvent = priceInput.Value,
                    AvailableDays = days
                }
            };

            return true;
        }
    }
}
