using Microsoft.Extensions.DependencyInjection;
using Venue.Application.Dtos.Venue;
using Venue.Application.Services.Venue;
using Venue.Domain.Interfaces;
using Venue.UI.Helpers;

namespace Venue.UI.Forms
{
    public partial class MyVenues : Form
    {
        private const int PageSize = 7;
        private const int DescriptionLimit = 60;
        private const int LocationLimit = 40;
        private readonly IVenueService _venueService;
        private readonly ICurrentUserService _currentUserService;
        private int _currentPage = 1;
        private int _totalPages = 1;

        public MyVenues()
        {
            InitializeComponent();

            _venueService = Program.Services.GetService<IVenueService>() ?? throw new Exception("Venue service not configured");
            _currentUserService = Program.Services.GetService<ICurrentUserService>() ?? throw new Exception("Current User service not configured");

            Load += LoadData!;

            if (_currentUserService.UserId == null)
            {
                ErrorShower.ShowError("No user is currently logged in. Please log in to continue.");
                this.Close();
            }

            if (_currentUserService.Role != Domain.Enums.UserRole.Owner)
            {
                ErrorShower.ShowError("Invalid Credentials!");
                this.Close();
            }
        }

        private async void LoadData(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var searchDto = new VenueSearchDto
                {
                    PageNumber = _currentPage,
                    PageSize = PageSize,
                    SortByType = Application.Common.SortByType.Descending
                };

                var result = await _venueService.GetMyVenuesAsync(searchDto);

                if (result.IsSuccess && result.Data != null)
                {
                    _totalPages = result.TotalPages;
                    PopulateVenueRows(result.Data);
                    UpdatePaginationInfo();
                }
                else
                {
                    ErrorShower.ShowError(result.Message);
                }
            }
            catch (Exception ex)
            {
                ErrorShower.ShowError($"Error loading venues: {ex.Message}");
            }
        }

        private void PopulateVenueRows(List<BasicOwnerVenueDto> venues)
        {
            ClearAllVenueRows();

            var panels = new[] { panel4, panel5, panel13, panel14, panel16, panel17, panel18, panel19 };
            var venuePanels = new[]
            {
                new { Panel = panel4, NameLabel = label46, DescLabel = label47, LocationLabel = label38, CapacityLabel = label30, PriceLabel = label22, EditButton = button11, DeleteButton = button3 },
                new { Panel = panel5, NameLabel = label48, DescLabel = label55, LocationLabel = label39, CapacityLabel = label31, PriceLabel = label23, EditButton = button12, DeleteButton = button4 },
                new { Panel = panel13, NameLabel = label49, DescLabel = label56, LocationLabel = label40, CapacityLabel = label32, PriceLabel = label24, EditButton = button13, DeleteButton = button5 },
                new { Panel = panel16, NameLabel = label50, DescLabel = label57, LocationLabel = label41, CapacityLabel = label33, PriceLabel = label25, EditButton = button14, DeleteButton = button6 },
                new { Panel = panel14, NameLabel = label51, DescLabel = label58, LocationLabel = label42, CapacityLabel = label34, PriceLabel = label26, EditButton = button15, DeleteButton = button7 },
                new { Panel = panel17, NameLabel = label52, DescLabel = label59, LocationLabel = label43, CapacityLabel = label35, PriceLabel = label27, EditButton = button16, DeleteButton = button8 },
                new { Panel = panel18, NameLabel = label53, DescLabel = label60, LocationLabel = label44, CapacityLabel = label36, PriceLabel = label28, EditButton = button17, DeleteButton = button9 },
                new { Panel = panel19, NameLabel = label54, DescLabel = label61, LocationLabel = label45, CapacityLabel = label37, PriceLabel = label29, EditButton = button18, DeleteButton = button10 }
            };

            for (int i = 0; i < venues.Count && i < venuePanels.Length; i++)
            {
                var venue = venues[i];
                var venuePanel = venuePanels[i];

                venuePanel.NameLabel.Text = $" {venue.Name}";
                venuePanel.DescLabel.Text = $" {TruncateText(venue.Description, DescriptionLimit)}";
                venuePanel.LocationLabel.Text = $" {TruncateText(venue.Address, LocationLimit)}";
                venuePanel.CapacityLabel.Text = venue.SeatingCapacity.ToString();
                venuePanel.PriceLabel.Text = venue.PricePerEvent.ToString();
                venuePanel.EditButton.Tag = venue.Id;
                venuePanel.DeleteButton.Tag = venue.Id;

                venuePanel.Panel.Visible = true;
            }
        }

        private void ClearAllVenueRows()
        {
            var panels = new[] { panel4, panel5, panel13, panel14, panel16, panel17, panel18, panel19 };
            foreach (var panel in panels)
            {
                panel.Visible = false;
            }
        }

        private void UpdatePaginationInfo()
        {
            labelPageInfo.Text = $"Page {_currentPage} of {_totalPages}";
            buttonPreviousPage.Enabled = _currentPage > 1;
            buttonNextPage.Enabled = _currentPage < _totalPages;
        }

        private async void DeleteVenue_Click(object sender, EventArgs e)
        {
            if (sender is not Button button || button.Tag is not Guid venueId)
            {
                return;
            }

            var result = await _venueService.DeleteAsync(venueId);

            if (!result.IsSuccess)
            {
                ErrorShower.ShowError(result.Message);
                return;
            }

            await LoadDataAsync();
        }

        private async void EditVenue_Click(object sender, EventArgs e)
        {
            if (sender is not Button button || button.Tag is not Guid venueId)
                return;
            
            var venueDtoResponse = await _venueService.GetByIdAsync(venueId);
            if (!venueDtoResponse.IsSuccess)
                ErrorShower.ShowError(venueDtoResponse);

            using var addVenueForm = new AddVenueForm(venueDtoResponse.Data);

            if (addVenueForm.ShowDialog(this) != DialogResult.OK || addVenueForm.NewVenueDto == null)
                return;
            
            var dto = new UpdateVenueDto()
            {
                Id = venueId,

                Name  = addVenueForm.NewVenueDto.Name,
                Description = addVenueForm.NewVenueDto.Description,
                ImagePath = addVenueForm.NewVenueDto.ImagePath,

                ContactInfo = addVenueForm.NewVenueDto.ContactInfo,
                Info = addVenueForm.NewVenueDto.Info,
            };

            var result = await _venueService.UpdateAsync(dto);

            if (!result.IsSuccess)
            {
                ErrorShower.ShowError(result.Message);
                return;
            }

            await LoadDataAsync();
        }

        private async void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (_currentPage >= _totalPages)
            {
                return;
            }

            _currentPage++;
            await LoadDataAsync();
        }

        private async void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            if (_currentPage <= 1)
            {
                return;
            }

            _currentPage--;
            await LoadDataAsync();
        }

        private async void buttonAddVenue_Click(object sender, EventArgs e)
        {
            using var addVenueForm = new AddVenueForm();

            if (addVenueForm.ShowDialog(this) != DialogResult.OK || addVenueForm.NewVenueDto == null)
            {
                return;
            }

            var result = await _venueService.CreateAsync(addVenueForm.NewVenueDto);

            if (!result.IsSuccess)
            {
                ErrorShower.ShowError(result.Message);
                return;
            }

            await LoadDataAsync();
        }

        private static string TruncateText(string value, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length <= maxLength)
            {
                return value;
            }

            return value[..(maxLength - 1)] + "…";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var mainScreenForm = new Home();
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
