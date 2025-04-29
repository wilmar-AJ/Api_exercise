using Microsoft.Maui.Controls;
using System;

namespace Api_exercise.Controls;

[ContentProperty(nameof(Source))]
public partial class ZoomImageControl : ContentView
{
    public ZoomImageControl()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty SourceProperty =
        BindableProperty.Create(nameof(Source), typeof(ImageSource), typeof(ZoomImageControl), null, BindingMode.TwoWay);

    public ImageSource Source
    {
        get => (ImageSource)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    private void OnImageTapped(object sender, EventArgs e)
    {
        ZoomedFrame.IsVisible = !ZoomedFrame.IsVisible;
    }
}
