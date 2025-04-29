namespace Api_exercise.Controls;

public partial class ImagePopup : CommunityToolkit.Maui.Views.Popup
{
    public ImagePopup(ImageSource imageSource)
    {
        InitializeComponent();
        PopupImage.Source = imageSource;
    }
}
