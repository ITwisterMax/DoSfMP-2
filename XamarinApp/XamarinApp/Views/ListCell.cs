using Xamarin.Forms;
using XamarinApp.Settings;

namespace XamarinApp.Views
{
    /// <summary>
    ///     Computers list
    /// </summary>
    public class ListCell : ViewCell
    {
        /// <summary>
        ///     Label name
        /// </summary>
        private readonly Label LblName;

        /// <summary>
        ///     Computer image
        /// </summary>
        private readonly Image ImgComputer;

        /// <summary>
        ///     Name property
        /// </summary>
        public static readonly BindableProperty NameProperty = BindableProperty.Create($"{nameof(Name)}", typeof(string), typeof(ListCell), "");

        /// <summary>
        ///     Computer id property
        /// </summary>
        public static readonly BindableProperty ComputerIdProperty = BindableProperty.Create($"{nameof(ComputerId)}", typeof(string), typeof(ListCell), "");

        /// <summary>
        ///     Image property
        /// </summary>
        public static readonly BindableProperty ImageProperty = BindableProperty.Create($"{nameof(Image)}", typeof(ImageSource), typeof(ListCell), null);

        /// <summary>
        ///     Default constructor
        /// </summary>
        public ListCell()
        {
            // Create a new label name
            LblName = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                Padding = new Thickness(5, 10, 0, 0),
            };

            // Create a new computer image item
            ImgComputer = new Image
            {
                HeightRequest = 75,
                WidthRequest = 75,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Margin = 10
            };

            // Create a new cell
            var cell = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            // Create a new cell head
            var head = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            // Create a new cell content
            var content = new StackLayout
            {
                Orientation = StackOrientation.Vertical
            };

            // Union elements
            head.Children.Add(LblName);
            content.Children.Add(head);
            cell.Children.Add(ImgComputer);
            cell.Children.Add(content);

            View = cell;
        }

        /// <summary>
        ///     Name getter/setter
        /// </summary>
        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        /// <summary>
        ///     Computer id getter/setter
        /// </summary>
        public string ComputerId
        {
            get => (string)GetValue(ComputerIdProperty);
            set => SetValue(ComputerIdProperty, value);
        }

        /// <summary>
        ///     Image getter/setter
        /// </summary>
        public ImageSource Image
        {
            get => (ImageSource)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        /// <summary>
        ///     On binding context changed action 
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                LblName.Text = Name;
                LblName.FontFamily = DefaultSettings.FontFamily;
                LblName.FontSize = DefaultSettings.FontSize;

                ImgComputer.Source = Image;
            }
        }
    }
}