namespace Api_exercise.Controls;
using Api_exercise.Extensions;

public partial class ImagePopup : CommunityToolkit.Maui.Views.Popup
{
public Color BorderColor { get; set; } = Colors.Black;
    public float BorderThickness { get; set; } = 1;
    public double ImageWidth { get; set; } = 280;
    public double ImageHeight { get; set; } = 280;
    public Color BackgroundColor { get; set; } = Colors.White;

    public ImagePopup(ImageSource imageSource)
    {
        InitializeComponent();
        PopupImage.Source = imageSource;
        ImageBorder.AnimatePopAsync();
    }
}
