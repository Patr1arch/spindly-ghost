using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AnotherGraphEditor.Models;

namespace AnotherGraphEditor;

public class CanvasDocument
{
    // Хранения фигур и работа с его состоянием

    private List<IShape> _shapes;

    private event EventHandler? _changed = null;

    public CanvasDocument()
    {
        this._shapes = new List<IShape>();
    }

    public void AddShape(IShape shape)
    {
        this._shapes.Add(shape);
        this._changed?.Invoke(this, EventArgs.Empty);
    }

    public ReadOnlyCollection<IShape> GetShapes()
    {
        return this._shapes.AsReadOnly();
    }

    public void Subscribe(EventHandler eventHandler)
    {
        this._changed += eventHandler;
    }

    public void Unsubscribe(EventHandler eventHandler)
    {
        this._changed -= eventHandler;
    }
}