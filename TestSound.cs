using GDExtensionWrappers;
using Godot;
using System;

public partial class TestSound : Node
{
    [Export] string eventName;

    public override void _Ready()
    {
        Wwise.RegisterGameObj(this, Name);
        Wwise.PostEvent(eventName, this);
    }
}
