namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        Label header = new Label
        {
            Text = "ListView",
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            HorizontalOptions = LayoutOptions.Center
        };

        ListView listView = new ListView
        {
            ItemsSource = MauiProgram.Items,
            ItemTemplate = new DataTemplate(() =>
            {
                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "data");

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                                {
                                   nameLabel,
                                }
                    }
                };
            })
        };

        this.Content = new StackLayout
        {
            Children =
                {
                    header,
                    listView
                }
        };
    }
}
