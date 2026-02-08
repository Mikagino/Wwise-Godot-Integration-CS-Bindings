#if TOOLS
using Godot;
using System.Linq;


namespace WwiseCSBindings {

	[Tool]
	public partial class WwiseIdsConverter : EditorPlugin
	{
	#region EditorShit
		private Control _dock;

		 public override void _EnterTree()
		{
			_dock = GD.Load<PackedScene>("res://addons/WwiseCSBindings/WwiseIdsConverter/WwiseIdsConverter.tscn").Instantiate<Control>();
			AddControlToDock(DockSlot.LeftBr, _dock);
			_dock.GetChild<Button>(0).Pressed += Convert;
		}

		public override void _ExitTree()
		{
			RemoveControlFromDocks(_dock);
			_dock.Free();
		}
	#endregion EditorShit


	#region Conversion
		private int currentIndentLevel = -1;
		private static readonly string rootOutputPath = (string)ProjectSettings.GetSetting("wwise/common_user_settings/root_output_path") + "/resources/";

		/// <summary>
		/// Reads entire wwise_ids.gd and parses line by line into C#
		/// </summary>
		public void Convert() {
			string wwiseIdsPath = rootOutputPath + "wwise_ids.gd";

			if(!FileAccess.FileExists(wwiseIdsPath)) {
				GD.PrintErr("No wwise_ids.gd found. You need to add the wwise plugin and press Generate Wwise ids in the wwise browser");
				return;
			}

			FileAccess fileAccess = FileAccess.Open(wwiseIdsPath, FileAccess.ModeFlags.Read);

			// Parse all lines
			string parsedText = "";
			string readLine;
			string newLine;
			while (!fileAccess.EofReached())
			{
				readLine = fileAccess.GetLine();
				newLine = ParseLine(readLine);
				newLine = UpdateIndentLevel(newLine);
				parsedText += newLine;
			}
			parsedText += "}";

			// Writing to file
			FileAccess newFile = FileAccess.Open(rootOutputPath + "WwiseIds.cs", FileAccess.ModeFlags.Write);
			if(newFile.StoreString(parsedText))
				GD.Print("Finished conversion for wwise_ids.gd to C# for file: " + wwiseIdsPath + " succesfully! :D");
			else
				GD.Print("Unsucessful conversion of wwise_ids.gd, don't have a clue why... Probably file saving error");
			newFile.Close();
		}


		/// <summary>
		/// Replaces parts in the lines to parse into C#
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		public static string ParseLine(string line)	{
			if(line.Contains("class_name"))
				return "namespace AKCS\n{\n";
			
			if(line.Equals("") || line.Equals("\t"))
				return "\n";

			if (line.Contains("const")) {
				line = line.Replace("const", "public const long");
				return  "\t" + line.Replace(": int", "") + ";\n";
			}

			if (line.Contains("class")) {
				line = line.Replace("class", "public partial struct");
				return  "\t" + line.Replace(":", " {\n");
			}

			if(line.Contains("pass"))
				return line.Replace("pass", "}\n");

			return "\n-MEEP (This is a \"Missing Parsing\" statement!)-\n";
		}


		/// <summary>
		/// Calculate indent level and add ending brackets
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		private string UpdateIndentLevel(string line) {
			int nextIndentLevel = 0;
			if(line == "")
				return line;

			// count tabs
			for(; nextIndentLevel < line.Length && line.ElementAt(nextIndentLevel) == '\t'; nextIndentLevel++)
				continue;

			// ignore lines without code
			if (line.Length <= nextIndentLevel + 1)
				return line;

			// no } on first line
			if(currentIndentLevel == -1) {
				currentIndentLevel = nextIndentLevel;
				return line;
			}
			
			// add } retroactively
			if(currentIndentLevel > nextIndentLevel) {
				string newLine = "";
				for(int i = 0; i < currentIndentLevel - nextIndentLevel; i++) {
					for(int j = 0; j < currentIndentLevel - nextIndentLevel - i; j++)
						newLine += "\t";
					newLine += "}\n\n";
				}
				line = newLine + line;
			}
			currentIndentLevel = nextIndentLevel;
				
			return line;
		}
	}
	#endregion Conversion
}
#endif
