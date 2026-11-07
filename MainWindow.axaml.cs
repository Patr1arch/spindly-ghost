using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Controls.Shapes;
using AnotherGraphEditor.Models;

namespace AnotherGraphEditor;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DrawingSurfaceControl.SetDocument(new CanvasDocument());
    }

    public void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var document = DrawingSurfaceControl.GetDocument();

        document?.AddShape(new RectangleShape());
    }
}