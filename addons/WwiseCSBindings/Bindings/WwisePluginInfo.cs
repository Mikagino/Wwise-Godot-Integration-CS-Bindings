#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class WwisePluginInfo : Resource
{

	private new static readonly StringName NativeName = new StringName("WwisePluginInfo");

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="WwisePluginInfo"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="WwisePluginInfo"/> wrapper type,
	/// a new instance of the <see cref="WwisePluginInfo"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="WwisePluginInfo"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static WwisePluginInfo Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is WwisePluginInfo wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(WwisePluginInfo);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(WwisePluginInfo).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (WwisePluginInfo)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="WwisePluginInfo"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "WwisePluginInfo" type.</returns>
	public new static WwisePluginInfo Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName PluginName = "plugin_name";
		public new static readonly StringName PluginId = "plugin_id";
		public new static readonly StringName DllName = "dll_name";
		public new static readonly StringName StaticLibName = "static_lib_name";
	}

	public new string PluginName
	{
		get => Get(GDExtensionPropertyName.PluginName).As<string>();
		set => Set(GDExtensionPropertyName.PluginName, value);
	}

	public new long PluginId
	{
		get => Get(GDExtensionPropertyName.PluginId).As<long>();
		set => Set(GDExtensionPropertyName.PluginId, value);
	}

	public new string DllName
	{
		get => Get(GDExtensionPropertyName.DllName).As<string>();
		set => Set(GDExtensionPropertyName.DllName, value);
	}

	public new string StaticLibName
	{
		get => Get(GDExtensionPropertyName.StaticLibName).As<string>();
		set => Set(GDExtensionPropertyName.StaticLibName, value);
	}

}
