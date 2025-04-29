namespace Api_exercise.Controls;

public partial class CustomLoaderControl : ContentView
{
	public CustomLoaderControl()
	{
		InitializeComponent();
	}
	public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(CustomLoaderControl), "Cargando ...", BindingMode.TwoWay, null);
	public string Message
	{
		get => (string)GetValue(MessageProperty);
		set => SetValue(MessageProperty, value);
	}

	public static readonly BindableProperty MessageSizeProperty = BindableProperty.Create(nameof(MessageSize), typeof(double), typeof(CustomLoaderControl), 10.0, BindingMode.TwoWay, null);
	public double MessageSize
	{
		get => (double)GetValue(MessageSizeProperty);
		set => SetValue(MessageSizeProperty, value);
	}
}