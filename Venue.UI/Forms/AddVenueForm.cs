using System.Globalization;
using System.Linq;
using Venue.Application.Dtos.Common;
using Venue.Application.Dtos.Venue;
using Venue.UI.Helpers;

namespace Venue.UI.Forms
{
    public sealed partial class AddVenueForm : Form
    {
        public CreateVenueDto? NewVenueDto { get; private set; }
        private VenueDto? _venueDto { get; set; }

        public AddVenueForm(VenueDto? oldVenueDto = null)
        {
            InitializeComponent();

            if (oldVenueDto != null)
            {
                _venueDto = oldVenueDto;
                PopulateFields();
            }
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

            NewVenueDto = dto;
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

        private void PopulateFields()
        {
            if (_venueDto == null)
                return;

            labelTitle.Text = "Edit Venue";
            createButton.Text = "Update";

            nameTextBox.Text = _venueDto.Name;
            descriptionTextBox.Text = _venueDto.Description;

            phoneTextBox.Text = _venueDto.ContactInfo.Phone;
            emailTextBox.Text = _venueDto.ContactInfo.Email;
            addressTextBox.Text = _venueDto.ContactInfo.Address ?? string.Empty;

            locationXInput.Value = (decimal)_venueDto.ContactInfo.Location.X;
            locationYInput.Value = (decimal)_venueDto.ContactInfo.Location.Y;
            capacityInput.Value = _venueDto.Info.SeatingCapacity;

            priceInput.Value = _venueDto.Info.PricePerEvent;

            foreach (var day in _venueDto.Info.AvailableDays)
            {
                var index = availableDays.Items.IndexOf(day.ToString());
                if (index >= 0)
                {
                    availableDays.SetItemChecked(index, true);
                }
            }
        }
    }
}
