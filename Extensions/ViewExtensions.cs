using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace Api_exercise.Extensions;

public static class ViewExtensions
{
    public static async Task AnimatePopAsync(this VisualElement view, double scale = 2.3, uint duration = 100)
    {
        if (view == null) return;

        await view.ScaleTo(scale, duration, Easing.CubicIn); 
        await view.ScaleTo(1, duration, Easing.CubicOut); 
    }
}
