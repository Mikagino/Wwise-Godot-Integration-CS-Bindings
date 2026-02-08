using GDExtensionWrappers;
using Godot;
using System;
using System.Threading.Tasks;

public partial class TestSound : Node
{
    [Export] string eventName;

    public override void _Ready()
    {
        Wwise.RegisterGameObj(this, Name);
        SceneTreeTimer timer = GetTree().CreateTimer(1.0);
        timer.Timeout += () => Wwise.PostEventId(AKCS.EVENTS.CARLO_START, this);
    }
}
