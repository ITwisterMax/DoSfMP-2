using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.Resources;
using XamarinApp.Services;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    /// <summary>
    ///     Add computer view model
    /// </summary>
    public class AddComputerViewModel : BaseViewModel
    {
        /// <summary>
        ///     Firebase database instance
        /// </summary>
        private readonly IFirebaseDbService FirebaseDbService;

        /// <summary>
        ///     Firebase storage instance
        /// </summary>
        private readonly IFirebaseStorageService FirebaseStorageService;

        /// <summary>
        ///     Computer characteristics
        /// </summary>
        public string Name { get; set; }

        public string Description { get; set; }

        public string ProcessorGeneration { get; set; }

        public string ProcessorCores { get; set; }

        public string ProcessorThreads { get; set; }

        public string RamSize { get; set; }

        public string SsdSize { get; set; }

        public string HddSize { get; set; }

        public string PsuPower { get; set; }

        public string Price { get; set; }
        
        public string ImageUrl { get; set; }

        public string ImageName { get; set; }

        public string VideoUrl { get; set; }

        public string VideoName { get; set; }

        /// <summary>
        ///     Available commands
        /// </summary>
        public ICommand AddImage { get; }

        public ICommand AddVideo { get; }

        public ICommand Save { get; }

        /// <summary>
        ///     Default constructor
        /// </summary>
        public AddComputerViewModel()
        {
            FirebaseDbService = DependencyService.Get<IFirebaseDbService>();
            FirebaseStorageService = DependencyService.Get<IFirebaseStorageService>();

            Save = new Command(OnSaveButtonClicked);
            AddImage = new Command(OnAddImageButtonClicked);
            AddVideo = new Command(OnAddVideoButtonClicked);
        }

        /// <summary>
        ///     On add image button click action
        /// </summary>
        private async void OnAddImageButtonClicked()
        {
            var photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions { Title = "Select image" });

            if (photo is null)
            {
                return;
            }

            string extension = photo.FileName.Split('.')[1];
            var stream = await photo.OpenReadAsync();

            ImageName = Guid.NewGuid().ToString();
            ImageUrl = await FirebaseStorageService.LoadImage(stream, ImageName, extension);
        }

        /// <summary>
        ///     On add video button click action
        /// </summary>
        private async void OnAddVideoButtonClicked()
        {
            var video = await MediaPicker.PickVideoAsync(new MediaPickerOptions { Title = "Select video" });

            if (video is null)
            {
                return;
            }

            string extension = video.FileName.Split('.')[1];
            var stream = await video.OpenReadAsync();

            VideoName = Guid.NewGuid().ToString();
            VideoUrl = await FirebaseStorageService.LoadVideo(stream, VideoName, extension);
        }

        /// <summary>
        ///     On save button click action
        /// </summary>
        private async void OnSaveButtonClicked()
        {
            if (IsCorrectFields())
            {
                var computer = new Computer
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Name,
                    Description = Description,
                    ProcessorGeneration = int.Parse(ProcessorGeneration),
                    ProcessorCores = int.Parse(ProcessorCores),
                    ProcessorThreads = int.Parse(ProcessorThreads),
                    RamSize = int.Parse(RamSize),
                    SsdSize = int.Parse(SsdSize),
                    HddSize = int.Parse(HddSize),
                    PsuPower = int.Parse(PsuPower),
                    Price = float.Parse(Price),
                    Image = new CloudFileData
                    {
                        FileName = ImageName,
                        DownloadUrl = ImageUrl
                    },
                    Video = new CloudFileData
                    {
                        FileName = VideoName,
                        DownloadUrl = VideoUrl
                    }
                };

                await FirebaseDbService.AddComputer(computer);
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(AppContentText.IncorrectFieldsTitle,
                    AppContentText.IncorrectFieldsMessage, AppContentText.OkButton);
            }
        }

        /// <summary>
        ///     Check if fields are correct
        /// </summary>
        ///
        /// <returns>bool</returns>
        private bool IsCorrectFields()
        {
            if (!string.IsNullOrWhiteSpace(Name) || !string.IsNullOrWhiteSpace(Description))
            {
                try
                {
                    _ = int.Parse(ProcessorGeneration);
                    _ = int.Parse(ProcessorCores);
                    _ = int.Parse(ProcessorThreads);
                    _ = int.Parse(RamSize);
                    _ = int.Parse(SsdSize);
                    _ = int.Parse(HddSize);
                    _ = int.Parse(PsuPower);
                    _ = float.Parse(Price);

                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }
    }
}