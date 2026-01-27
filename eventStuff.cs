using GDExtensionWrappers;
using Godot;
using System;

public partial class eventStuff : AkEvent2D
{
    public override void _Ready()
    {
        PostEvent();
    }
}
