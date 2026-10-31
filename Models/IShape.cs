using Avalonia.Media;

namespace AnotherGraphEditor.Models;

public interface IShape
{
    public void Draw(DrawingContext context);
}
