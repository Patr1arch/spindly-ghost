using Avalonia.Controls;
using AnotherGraphEditor.Models;
using Avalonia.Media;
using System;

namespace AnotherGraphEditor.Controls;

public class DrawingSurface : Control
{
    // отрисовка и перерисовка содержимого в CanvasDocument

    private CanvasDocument? _canvasDocument = null;

    public void SetDocument(CanvasDocument canvasDocument)
    {
        if (this._canvasDocument != null)
        {
            this._canvasDocument.Unsubscribe(OnDocumentChanged);
        }
        this._canvasDocument = canvasDocument;
        this._canvasDocument.Subscribe(OnDocumentChanged);
    }

    public CanvasDocument? GetDocument()
    {
        return _canvasDocument;
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        context.FillRectangle(Brushes.Aquamarine, new Avalonia.Rect(Bounds.Size));

        if (_canvasDocument == null)
        {
            return;
        }

        foreach(IShape shape in _canvasDocument.GetShapes())
        {
            shape.Draw(context);
        }
    }

    private void OnDocumentChanged(object? sender, EventArgs e)
    {
        InvalidateVisual();
    }
}
