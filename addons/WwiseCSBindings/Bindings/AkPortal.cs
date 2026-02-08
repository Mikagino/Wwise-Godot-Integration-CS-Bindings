#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class AkPortal : Area3D
{

	private new static readonly StringName NativeName = new StringName("AkPortal");

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="AkPortal"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="AkPortal"/> wrapper type,
	/// a new instance of the <see cref="AkPortal"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="AkPortal"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static AkPortal Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is AkPortal wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(AkPortal);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(AkPortal).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (AkPortal)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="AkPortal"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "AkPortal" type.</returns>
	public new static AkPortal Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName FrontRoom = "front_room";
		public new static readonly StringName BackRoom = "back_room";
		public new static readonly StringName Enabled = "enabled";
	}

	public new NodePath FrontRoom
	{
		get => Get(GDExtensionPropertyName.FrontRoom).As<NodePath>();
		set => Set(GDExtensionPropertyName.FrontRoom, value);
	}

	public new NodePath BackRoom
	{
		get => Get(GDExtensionPropertyName.BackRoom).As<NodePath>();
		set => Set(GDExtensionPropertyName.BackRoom, value);
	}

	public new bool Enabled
	{
		get => Get(GDExtensionPropertyName.Enabled).As<bool>();
		set => Set(GDExtensionPropertyName.Enabled, value);
	}

	public new static class GDExtensionMethodName
	{
		public new static readonly StringName SetPortal = "set_portal";
	}

	public new void SetPortal() => 
		Call(GDExtensionMethodName.SetPortal, []);

}
