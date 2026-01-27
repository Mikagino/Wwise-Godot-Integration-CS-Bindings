#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class AkListener3D : Node3D
{

	private new static readonly StringName NativeName = new StringName("AkListener3D");

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="AkListener3D"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="AkListener3D"/> wrapper type,
	/// a new instance of the <see cref="AkListener3D"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="AkListener3D"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static AkListener3D Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is AkListener3D wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(AkListener3D);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(AkListener3D).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (AkListener3D)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="AkListener3D"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "AkListener3D" type.</returns>
	public new static AkListener3D Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName IsDefaultListener = "is_default_listener";
		public new static readonly StringName IsSpatial = "is_spatial";
		public new static readonly StringName RoomId = "room_id";
	}

	public new bool IsDefaultListener
	{
		get => Get(GDExtensionPropertyName.IsDefaultListener).As<bool>();
		set => Set(GDExtensionPropertyName.IsDefaultListener, value);
	}

	public new bool IsSpatial
	{
		get => Get(GDExtensionPropertyName.IsSpatial).As<bool>();
		set => Set(GDExtensionPropertyName.IsSpatial, value);
	}

	public new long RoomId
	{
		get => Get(GDExtensionPropertyName.RoomId).As<long>();
		set => Set(GDExtensionPropertyName.RoomId, value);
	}

}
