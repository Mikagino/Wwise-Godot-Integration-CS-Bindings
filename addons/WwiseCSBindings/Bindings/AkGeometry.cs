#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class AkGeometry : Node3D
{

	private new static readonly StringName NativeName = new StringName("AkGeometry");

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="AkGeometry"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="AkGeometry"/> wrapper type,
	/// a new instance of the <see cref="AkGeometry"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="AkGeometry"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static AkGeometry Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is AkGeometry wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(AkGeometry);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(AkGeometry).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (AkGeometry)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="AkGeometry"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "AkGeometry" type.</returns>
	public new static AkGeometry Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName IsStatic = "is_static";
		public new static readonly StringName EnableDiffraction = "enable_diffraction";
		public new static readonly StringName EnableDiffractionOnBoundaryEdges = "enable_diffraction_on_boundary_edges";
		public new static readonly StringName IsSolid = "is_solid";
		public new static readonly StringName BypassPortalSubtraction = "bypass_portal_subtraction";
		public new static readonly StringName AcousticTexture = "acoustic_texture";
		public new static readonly StringName TransmissionLossValue = "transmission_loss_value";
	}

	public new bool IsStatic
	{
		get => Get(GDExtensionPropertyName.IsStatic).As<bool>();
		set => Set(GDExtensionPropertyName.IsStatic, value);
	}

	public new bool EnableDiffraction
	{
		get => Get(GDExtensionPropertyName.EnableDiffraction).As<bool>();
		set => Set(GDExtensionPropertyName.EnableDiffraction, value);
	}

	public new bool EnableDiffractionOnBoundaryEdges
	{
		get => Get(GDExtensionPropertyName.EnableDiffractionOnBoundaryEdges).As<bool>();
		set => Set(GDExtensionPropertyName.EnableDiffractionOnBoundaryEdges, value);
	}

	public new bool IsSolid
	{
		get => Get(GDExtensionPropertyName.IsSolid).As<bool>();
		set => Set(GDExtensionPropertyName.IsSolid, value);
	}

	public new bool BypassPortalSubtraction
	{
		get => Get(GDExtensionPropertyName.BypassPortalSubtraction).As<bool>();
		set => Set(GDExtensionPropertyName.BypassPortalSubtraction, value);
	}

	public new WwiseAcousticTexture AcousticTexture
	{
		get => WwiseAcousticTexture.Bind(Get(GDExtensionPropertyName.AcousticTexture).As<Resource>());
		set => Set(GDExtensionPropertyName.AcousticTexture, value);
	}

	public new double TransmissionLossValue
	{
		get => Get(GDExtensionPropertyName.TransmissionLossValue).As<double>();
		set => Set(GDExtensionPropertyName.TransmissionLossValue, value);
	}

}
