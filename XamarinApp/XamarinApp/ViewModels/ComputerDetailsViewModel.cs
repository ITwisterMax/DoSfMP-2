using System;
using System.Globalization;
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
    ///     Computer details view model
    /// </summary>
    public class ComputerDetailsViewModel : BaseViewModel
    {
        /// <summary>
        ///     Current computer
        /// </summary>
        public Computer Computer { get; set; }

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
        public string Id { get; set; }

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
        public ICommand ViewImage { get; }

        public ICommand UpdateImage { get; }

        public ICommand UpdateVideo { get; }

        public ICommand ViewVideo { get; }

        public ICommand Save { get; }

        /// <summary>
        ///     Default constructor
        /// </summary>
        ///
        /// <param name="id">Computer id</param>
        public ComputerDetailsViewModel(string id)
        {
            FirebaseDbService = DependencyService.Get<IFirebaseDbService>();
            FirebaseStorageService = DependencyService.Get<IFirebaseStorageService>();

            Computer = FirebaseDbService.GetComputerById(id);

            Id = id;
            Name = Computer.Name;
            Description = Computer.Description;
            ProcessorGeneration = Computer.ProcessorGeneration.ToString();
            ProcessorCores = Computer.ProcessorCores.ToString();
            ProcessorThreads = Computer.ProcessorThreads.ToString();
            RamSize = Computer.RamSize.ToString();
            SsdSize = Computer.SsdSize.ToString();
            HddSize = Computer.HddSize.ToString();
            PsuPower = Computer.PsuPower.ToString();
            Price = Computer.Price.ToString(CultureInfo.InvariantCulture);
            ImageUrl = Computer.Image.DownloadUrl;
            ImageName = Computer.Image.FileName;
            VideoUrl = Computer.Video.DownloadUrl;
            VideoName = Computer.Video.FileName;

            ViewImage = new Command(OnViewImageButtonClicked);
            UpdateImage = new Command(OnUpdateImageButtonClicked);
            UpdateVideo = new Command(OnUpdateVideoButtonClicked);
            ViewVideo = new Command(OnViewVideoButtonClicked);
            Save = new Command(OnSaveButtonClicked);
        }

        /// <summary>
        ///     On view image button click action
        /// </summary>
        private async void OnViewImageButtonClicked()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ViewImagePage(ImageUrl));
        }

        /// <summary>
        ///     On update image button click action
        /// </summary>
        private async void OnUpdateImageButtonClicked()
        {
            if (!string.IsNullOrEmpty(ImageName))
            {
                await FirebaseStorageService.RemoveImage(ImageName);
            }

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
        ///     On view video button click action
        /// </summary>
        private async void OnViewVideoButtonClicked()
        {
            if (!string.IsNullOrEmpty(VideoUrl))
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewVideoPage(VideoUrl));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(AppContentText.NotFoundTitle,
                    AppContentText.VideoNotFoundMessage, AppContentText.OkButton);
            }
        }

        /// <summary>
        ///     On update video button click action
        /// </summary>
        private async void OnUpdateVideoButtonClicked()
        {
            if (!string.IsNullOrEmpty(VideoName))
            {
                await FirebaseStorageService.RemoveVideo(VideoName);
            }

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
                    Id = Id,
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

                await FirebaseDbService.UpdateComputer(Id, computer);
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