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

    public static readonly BindableProperty PopupBorderColorProperty = BindableProperty.Create(
        nameof(PopupBorderColor), typeof(Color), typeof(ZoomImageControl), Colors.Black);

    public static readonly BindableProperty PopupImageWidthProperty = BindableProperty.Create(
        nameof(PopupImageWidth), typeof(double), typeof(ZoomImageControl), 280.0);

    public static readonly BindableProperty PopupImageHeightProperty = BindableProperty.Create(
        nameof(PopupImageHeight), typeof(double), typeof(ZoomImageControl), 280.0);

    public static readonly BindableProperty PopupBackgroundColorProperty = BindableProperty.Create(
        nameof(PopupBackgroundColor), typeof(Color), typeof(ZoomImageControl), Colors.White);

    public Color PopupBorderColor
    {
        get => (Color)GetValue(PopupBorderColorProperty);
        set => SetValue(PopupBorderColorProperty, value);
    }

    public double PopupImageWidth
    {
        get => (double)GetValue(PopupImageWidthProperty);
        set => SetValue(PopupImageWidthProperty, value);
    }

    public double PopupImageHeight
    {
        get => (double)GetValue(PopupImageHeightProperty);
        set => SetValue(PopupImageHeightProperty, value);
    }

    public Color PopupBackgroundColor
    {
        get => (Color)GetValue(PopupBackgroundColorProperty);
        set => SetValue(PopupBackgroundColorProperty, value);
    }

    private async void OnImageTapped(object sender, EventArgs e)
    {
        var popup = new ImagePopup(Source)
        {
            BorderColor = PopupBorderColor,
            ImageWidth = PopupImageWidth,
            ImageHeight = PopupImageHeight,
            BackgroundColor = PopupBackgroundColor
        };
        await Application.Current.MainPage.ShowPopupAsync(popup);
    }
}
