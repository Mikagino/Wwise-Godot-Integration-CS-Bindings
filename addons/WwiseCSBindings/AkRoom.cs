#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class AkRoom : Area3D
{

	private new static readonly StringName NativeName = new StringName("AkRoom");

	[Obsolete("Wrapper types cannot be constructed with constructors (it only instantiate the underlying AkRoom object), please use the Instantiate() method instead.")]
	protected AkRoom() { }

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="AkRoom"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="AkRoom"/> wrapper type,
	/// a new instance of the <see cref="AkRoom"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="AkRoom"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static AkRoom Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is AkRoom wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(AkRoom);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(AkRoom).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (AkRoom)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="AkRoom"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "AkRoom" type.</returns>
	public new static AkRoom Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName AuxBus = "aux_bus";
		public new static readonly StringName ReverbLevel = "reverb_level";
		public new static readonly StringName TransmissionLoss = "transmission_loss";
		public new static readonly StringName AssociatedGeometry = "associated_geometry";
		public new static readonly StringName KeepRegistered = "keep_registered";
	}

	public new WwiseAuxBus AuxBus
	{
		get => WwiseAuxBus.Bind(Get(GDExtensionPropertyName.AuxBus).As<Resource>());
		set => Set(GDExtensionPropertyName.AuxBus, value);
	}

	public new double ReverbLevel
	{
		get => Get(GDExtensionPropertyName.ReverbLevel).As<double>();
		set => Set(GDExtensionPropertyName.ReverbLevel, value);
	}

	public new double TransmissionLoss
	{
		get => Get(GDExtensionPropertyName.TransmissionLoss).As<double>();
		set => Set(GDExtensionPropertyName.TransmissionLoss, value);
	}

	public new NodePath AssociatedGeometry
	{
		get => Get(GDExtensionPropertyName.AssociatedGeometry).As<NodePath>();
		set => Set(GDExtensionPropertyName.AssociatedGeometry, value);
	}

	public new bool KeepRegistered
	{
		get => Get(GDExtensionPropertyName.KeepRegistered).As<bool>();
		set => Set(GDExtensionPropertyName.KeepRegistered, value);
	}

}
