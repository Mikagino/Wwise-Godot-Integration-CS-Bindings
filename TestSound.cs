using GDExtensionWrappers;
using Godot;
using System;

public partial class TestSound : Node
{
    [Export] string eventName;

    public override void _Ready()
    {
        foreach (string s in Engine.GetSingletonList())
            GD.Print(s + ", ");
        
        GD.Print(Wwise.LoadBank("AllSounds"));
        GD.Print(Wwise.RegisterGameObj(this, Name));
        GD.Print(Wwise.PostEvent(eventName, this));
    }
}
