#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class AkEarlyReflections : Node
{

	private new static readonly StringName NativeName = new StringName("AkEarlyReflections");

	[Obsolete("Wrapper types cannot be constructed with constructors (it only instantiate the underlying AkEarlyReflections object), please use the Instantiate() method instead.")]
	protected AkEarlyReflections() { }

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="AkEarlyReflections"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="AkEarlyReflections"/> wrapper type,
	/// a new instance of the <see cref="AkEarlyReflections"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="AkEarlyReflections"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static AkEarlyReflections Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is AkEarlyReflections wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(AkEarlyReflections);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(AkEarlyReflections).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (AkEarlyReflections)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="AkEarlyReflections"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "AkEarlyReflections" type.</returns>
	public new static AkEarlyReflections Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName AuxBus = "aux_bus";
		public new static readonly StringName GameObjectPath = "game_object_path";
		public new static readonly StringName Volume = "volume";
	}

	public new WwiseAuxBus AuxBus
	{
		get => WwiseAuxBus.Bind(Get(GDExtensionPropertyName.AuxBus).As<Resource>());
		set => Set(GDExtensionPropertyName.AuxBus, value);
	}

	public new NodePath GameObjectPath
	{
		get => Get(GDExtensionPropertyName.GameObjectPath).As<NodePath>();
		set => Set(GDExtensionPropertyName.GameObjectPath, value);
	}

	public new double Volume
	{
		get => Get(GDExtensionPropertyName.Volume).As<double>();
		set => Set(GDExtensionPropertyName.Volume, value);
	}

	public new static class GDExtensionMethodName
	{
		public new static readonly StringName SetEarlyReflectionsVolume = "set_early_reflections_volume";
	}

	public new void SetEarlyReflectionsVolume(double volume) => 
		Call(GDExtensionMethodName.SetEarlyReflectionsVolume, [volume]);

}
