using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Controls.Shapes;

namespace AnotherGraphEditor;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Rectangle rectangle = new Rectangle();
        rectangle.Fill = Brushes.Blue;
        rectangle.Width = 100;
        rectangle.Height = 100;

        myCanvas.Children.Add(rectangle);
    }
}