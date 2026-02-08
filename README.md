# Wwise Godot Integration C# Bindings
Call Wwise functions in C# without the use of GodotObject.Call, simply call the bound C# functions.

Bindings generated with [C# GDExtension Bindgen](https://github.com/gilzoide/godot-csharp-gdextension-bindgen)

# Supported Versions
Wwise 2024.1.8
Godot 4.3, 4.4, 4.5

# Installation
1. Follow the installation instructions for the [Wwise Godot Integration](https://github.com/alessandrofama/wwise-godot-integration) by Alessandro Fama
2. Add all files from the according versions in the [Releases](https://github.com/Mikagino/Wwise-Godot-Integration-CS-Bindings/releases) anywhere into your project.
3. Build your project
4. Works!

# Usage
You can use most of the features described in the [Wwise Godot Integration](https://github.com/alessandrofama/wwise-godot-integration/wiki). Some features are still not working (like WwiseIds) but I might add them in the future.

# To-Do's
- [x] Check if update to Wwise 2025.1.3 with Godot 4.3, 4.4, 4.5 requires any changes
- [ ] Copy Alessandro's documentation
- [ ] Parse wwise_ids.gd
- [ ] Parse various Wwise Objects for usage in Editor
