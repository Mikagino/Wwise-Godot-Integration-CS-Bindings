#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class WwisePlatformInfo : Resource
{

	private new static readonly StringName NativeName = new StringName("WwisePlatformInfo");

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="WwisePlatformInfo"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="WwisePlatformInfo"/> wrapper type,
	/// a new instance of the <see cref="WwisePlatformInfo"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="WwisePlatformInfo"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static WwisePlatformInfo Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is WwisePlatformInfo wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(WwisePlatformInfo);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(WwisePlatformInfo).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (WwisePlatformInfo)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="WwisePlatformInfo"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "WwisePlatformInfo" type.</returns>
	public new static WwisePlatformInfo Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName PlatformName = "platform_name";
		public new static readonly StringName PlatformPath = "platform_path";
		public new static readonly StringName PluginInfo = "plugin_info";
	}

	public new string PlatformName
	{
		get => Get(GDExtensionPropertyName.PlatformName).As<string>();
		set => Set(GDExtensionPropertyName.PlatformName, value);
	}

	public new string PlatformPath
	{
		get => Get(GDExtensionPropertyName.PlatformPath).As<string>();
		set => Set(GDExtensionPropertyName.PlatformPath, value);
	}

	public new Godot.Collections.Array PluginInfo
	{
		get => Get(GDExtensionPropertyName.PluginInfo).As<Godot.Collections.Array>();
		set => Set(GDExtensionPropertyName.PluginInfo, value);
	}

}
