#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class AkEnvironment : Area3D
{

	private new static readonly StringName NativeName = new StringName("AkEnvironment");

	[Obsolete("Wrapper types cannot be constructed with constructors (it only instantiate the underlying AkEnvironment object), please use the Instantiate() method instead.")]
	protected AkEnvironment() { }

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="AkEnvironment"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="AkEnvironment"/> wrapper type,
	/// a new instance of the <see cref="AkEnvironment"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="AkEnvironment"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static AkEnvironment Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is AkEnvironment wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(AkEnvironment);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(AkEnvironment).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (AkEnvironment)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="AkEnvironment"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "AkEnvironment" type.</returns>
	public new static AkEnvironment Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName AuxBus = "aux_bus";
		public new static readonly StringName Priority = "priority";
	}

	public new WwiseAuxBus AuxBus
	{
		get => WwiseAuxBus.Bind(Get(GDExtensionPropertyName.AuxBus).As<Resource>());
		set => Set(GDExtensionPropertyName.AuxBus, value);
	}

	public new long Priority
	{
		get => Get(GDExtensionPropertyName.Priority).As<long>();
		set => Set(GDExtensionPropertyName.Priority, value);
	}

}
