using Godot;
using System;
using System.IO;

public partial class WwiseIdParser : Node
{
    private void ParseWwiseIds()
    {
        GD.Print("Parsind wwise_ids.gd to C#");

        string wwiseIdPath = (string)ProjectSettings.GetSetting("wwise/common_user_settings/root_output_path", "");
        //var lines = File.ReadAllLines()
    }
}
