using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.Resources;

namespace XamarinApp.ViewModels
{
    /// <summary>
    ///     Filter view model
    /// </summary>
    class FilterViewModel: BaseViewModel
    {
        /// <summary>
        ///     Available filters
        /// </summary>
        public string ProcessorGenerationMin { get; set; } = null;

        public string ProcessorGenerationMax { get; set; } = null;

        public string ProcessorCoresMin { get; set; } = null;

        public string ProcessorCoresMax { get; set; } = null;

        public string ProcessorThreadsMin { get; set; } = null;

        public string ProcessorThreadsMax { get; set; } = null;

        public string RamSizeMin { get; set; } = null;

        public string RamSizeMax { get; set; } = null;

        public string SsdSizeMin { get; set; } = null;

        public string SsdSizeMax { get; set; } = null;

        public string HddSizeMin { get; set; } = null;

        public string HddSizeMax { get; set; } = null;

        public string PsuPowerMin { get; set; } = null;

        public string PsuPowerMax { get; set; } = null;

        public string PriceMin { get; set; } = null;

        public string PriceMax { get; set; } = null;

        /// <summary>
        ///     Available commands
        /// </summary>
        public ICommand Filter { get; }

        public ICommand Clear { get; }

        /// <summary>
        ///     Default constructor
        /// </summary>
        public FilterViewModel()
        {
            Filter = new Command(OnFilterButtonClicked);
            Clear = new Command(OnClearButtonClicked);

            ProcessorGenerationMin = Filters.ProcessorGenerationMin.ToString();
            ProcessorGenerationMax = Filters.ProcessorGenerationMax.ToString();
            ProcessorCoresMin = Filters.ProcessorCoresMin.ToString();
            ProcessorCoresMax = Filters.ProcessorCoresMax.ToString();
            ProcessorThreadsMin = Filters.ProcessorThreadsMin.ToString();
            ProcessorThreadsMax = Filters.ProcessorThreadsMax.ToString();
            RamSizeMin = Filters.RamSizeMin.ToString();
            RamSizeMax = Filters.RamSizeMax.ToString();
            SsdSizeMin = Filters.SsdSizeMin.ToString();
            SsdSizeMax = Filters.SsdSizeMax.ToString();
            HddSizeMin = Filters.HddSizeMin.ToString();
            HddSizeMax = Filters.HddSizeMax.ToString();
            PsuPowerMin = Filters.PsuPowerMin.ToString();
            PsuPowerMax = Filters.PsuPowerMax.ToString();
            PriceMin = Filters.PriceMin.ToString();
            PriceMax = Filters.PriceMax.ToString();
        }

        /// <summary>
        ///     On filter button click action
        /// </summary>
        private void OnFilterButtonClicked()
        {
            ValidateAndApplyFilters();
        }

        /// <summary>
        ///     On Clear button click action
        /// </summary>
        private void OnClearButtonClicked()
        {
            ClearFilters();

            Filters.isFilter = false;
            Application.Current.MainPage = new AppShell();
        }

        /// <summary>
        ///     Clear all filters
        /// </summary>
        private void ClearFilters()
        {
            Filters.ProcessorGenerationMin = null;
            Filters.ProcessorGenerationMax = null;
            Filters.ProcessorCoresMin = null;
            Filters.ProcessorCoresMax = null;
            Filters.ProcessorThreadsMin = null;
            Filters.ProcessorThreadsMax = null;
            Filters.RamSizeMin = null;
            Filters.RamSizeMax = null;
            Filters.SsdSizeMin = null;
            Filters.SsdSizeMax = null;
            Filters.HddSizeMin = null;
            Filters.HddSizeMax = null;
            Filters.PsuPowerMin = null;
            Filters.PsuPowerMax = null;
            Filters.PriceMin = null;
            Filters.PriceMax = null;
        }

        /// <summary>
        ///     Validate and apply filters
        /// </summary>
        private async void ValidateAndApplyFilters()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(ProcessorGenerationMin))
                {
                    Filters.ProcessorGenerationMin = int.Parse(ProcessorGenerationMin);
                }
                else
                {
                    Filters.ProcessorGenerationMin = null;
                }
                if (!string.IsNullOrWhiteSpace(ProcessorGenerationMax))
                {
                    Filters.ProcessorGenerationMax = int.Parse(ProcessorGenerationMax);
                }
                else
                {
                    Filters.ProcessorGenerationMax = null;
                }
                if (!string.IsNullOrWhiteSpace(ProcessorCoresMin))
                {
                    Filters.ProcessorCoresMin = int.Parse(ProcessorCoresMin);
                }
                else
                {
                    Filters.ProcessorCoresMin = null;
                }
                if (!string.IsNullOrWhiteSpace(ProcessorCoresMax))
                {
                    Filters.ProcessorCoresMax = int.Parse(ProcessorCoresMax);
                }
                else
                {
                    Filters.ProcessorCoresMax = null;
                }
                if (!string.IsNullOrWhiteSpace(ProcessorThreadsMin))
                {
                    Filters.ProcessorThreadsMin = int.Parse(ProcessorThreadsMin);
                }
                else
                {
                    Filters.ProcessorThreadsMin = null;
                }
                if (!string.IsNullOrWhiteSpace(ProcessorThreadsMax))
                {
                    Filters.ProcessorThreadsMax = int.Parse(ProcessorThreadsMax);
                }
                else
                {
                    Filters.ProcessorThreadsMax = null;
                }
                if (!string.IsNullOrWhiteSpace(RamSizeMin))
                {
                    Filters.RamSizeMin = int.Parse(RamSizeMin);
                }
                else
                {
                    Filters.RamSizeMin = null;
                }
                if (!string.IsNullOrWhiteSpace(RamSizeMax))
                {
                    Filters.RamSizeMax = int.Parse(RamSizeMax);
                }
                else
                {
                    Filters.RamSizeMax = null;
                }
                if (!string.IsNullOrWhiteSpace(SsdSizeMin))
                {
                    Filters.SsdSizeMin = int.Parse(SsdSizeMin);
                }
                else
                {
                    Filters.SsdSizeMin = null;
                }
                if (!string.IsNullOrWhiteSpace(SsdSizeMax))
                {
                    Filters.SsdSizeMax = int.Parse(SsdSizeMax);
                }
                else
                {
                    Filters.SsdSizeMax = null;
                }
                if (!string.IsNullOrWhiteSpace(HddSizeMin))
                {
                    Filters.HddSizeMin = int.Parse(HddSizeMin);
                }
                else
                {
                    Filters.HddSizeMin = null;
                }
                if (!string.IsNullOrWhiteSpace(HddSizeMax))
                {
                    Filters.HddSizeMax = int.Parse(HddSizeMax);
                }
                else
                {
                    Filters.HddSizeMax = null;
                }
                if (!string.IsNullOrWhiteSpace(PsuPowerMin))
                {
                    Filters.PsuPowerMin = int.Parse(PsuPowerMin);
                }
                else
                {
                    Filters.PsuPowerMin = null;
                }
                if (!string.IsNullOrWhiteSpace(PsuPowerMax))
                {
                    Filters.PsuPowerMax = int.Parse(PsuPowerMax);
                }
                else
                {
                    Filters.PsuPowerMax = null;
                }
                if (!string.IsNullOrWhiteSpace(PriceMin))
                {
                    Filters.PriceMin = float.Parse(PriceMin);
                }
                else
                {
                    Filters.PriceMin = null;
                }
                if (!string.IsNullOrWhiteSpace(PriceMax))
                {
                    Filters.PriceMax = float.Parse(PriceMax);
                }
                else
                {
                    Filters.PriceMax = null;
                }

                Filters.isFilter = true;
                Application.Current.MainPage = new AppShell();
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert(AppContentText.IncorrectFieldsTitle,
                    AppContentText.IncorrectFieldsMessage, AppContentText.OkButton);
            }
        }
    }
}
