using CommunityToolkit.Maui.Views;

namespace Api_exercise.Controls;

public partial class ZoomImageControl : ContentView
{
    public ZoomImageControl()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty SourceProperty = BindableProperty.Create(
        nameof(Source),
        typeof(ImageSource),
        typeof(ZoomImageControl),
        default(ImageSource),
        BindingMode.TwoWay);

    public ImageSource Source
    {
        get => (ImageSource)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    private async void OnImageTapped(object sender, EventArgs e)
    {
        var popup = new ImagePopup(Source);
        await Application.Current.MainPage.ShowPopupAsync(popup);
    }
}
