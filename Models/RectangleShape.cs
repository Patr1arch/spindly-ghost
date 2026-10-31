using Avalonia;
using Avalonia.Media;

namespace AnotherGraphEditor.Models;

public class RectangleShape : IShape
{
    public void Draw(DrawingContext context)
    {
        Rect rect = new Rect(50, 50, 100, 100);
        context.DrawRectangle(
            Brushes.Blue,
            new Pen(Brushes.Black, 2),
            rect
        );
    }
}
