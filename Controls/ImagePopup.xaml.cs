namespace Api_exercise.Controls;
using Api_exercise.Extensions;

public partial class ImagePopup : CommunityToolkit.Maui.Views.Popup
{
    public ImagePopup(ImageSource imageSource)
    {
        InitializeComponent();
        PopupImage.Source = imageSource;
         ImageBorder.AnimatePopAsync();
    }
}
