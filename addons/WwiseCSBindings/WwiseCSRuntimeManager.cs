#if TOOLS
using GDExtensionWrappers;
using Godot;
using System;

[Tool]
public partial class WwiseCSRuntimeManager : EditorPlugin
{
	public override void _EnterTree()
	{
		Wwise wwise = Wwise.Instantiate();
		// Initialization of the plugin goes here.
	}

	public override void _ExitTree()
	{
		// Clean-up of the plugin goes here.
	}
}
#endif
