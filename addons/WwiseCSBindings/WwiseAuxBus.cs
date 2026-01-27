#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class WwiseAuxBus : WwiseBaseType
{

	private new static readonly StringName NativeName = new StringName("WwiseAuxBus");

	[Obsolete("Wrapper types cannot be constructed with constructors (it only instantiate the underlying WwiseAuxBus object), please use the Instantiate() method instead.")]
	protected WwiseAuxBus() { }

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="WwiseAuxBus"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="WwiseAuxBus"/> wrapper type,
	/// a new instance of the <see cref="WwiseAuxBus"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="WwiseAuxBus"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static WwiseAuxBus Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is WwiseAuxBus wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(WwiseAuxBus);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(WwiseAuxBus).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (WwiseAuxBus)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="WwiseAuxBus"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "WwiseAuxBus" type.</returns>
	public new static WwiseAuxBus Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName IsInUserDefinedSoundBank = "is_in_user_defined_sound_bank";
		public new static readonly StringName BankId = "bank_id";
		public new static readonly StringName IsAutoBankLoaded = "is_auto_bank_loaded";
	}

	public new bool IsInUserDefinedSoundBank
	{
		get => Get(GDExtensionPropertyName.IsInUserDefinedSoundBank).As<bool>();
		set => Set(GDExtensionPropertyName.IsInUserDefinedSoundBank, value);
	}

	public new long BankId
	{
		get => Get(GDExtensionPropertyName.BankId).As<long>();
		set => Set(GDExtensionPropertyName.BankId, value);
	}

	public new bool IsAutoBankLoaded
	{
		get => Get(GDExtensionPropertyName.IsAutoBankLoaded).As<bool>();
		set => Set(GDExtensionPropertyName.IsAutoBankLoaded, value);
	}

}
