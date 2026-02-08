#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class AkBank : Node
{

	private new static readonly StringName NativeName = new StringName("AkBank");

	protected AkBank() { }

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="AkBank"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="AkBank"/> wrapper type,
	/// a new instance of the <see cref="AkBank"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="AkBank"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static AkBank Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is AkBank wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(AkBank);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(AkBank).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (AkBank)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="AkBank"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "AkBank" type.</returns>
	public new static AkBank Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName Bank = "bank";
		public new static readonly StringName LoadOn = "load_on";
		public new static readonly StringName UnloadOn = "unload_on";
	}

	public new WwiseBank Bank
	{
		get => WwiseBank.Bind(Get(GDExtensionPropertyName.Bank).As<Resource>());
		set => Set(GDExtensionPropertyName.Bank, value);
	}

	public new Variant LoadOn
	{
		get => Get(GDExtensionPropertyName.LoadOn).As<Variant>();
		set => Set(GDExtensionPropertyName.LoadOn, value);
	}

	public new Variant UnloadOn
	{
		get => Get(GDExtensionPropertyName.UnloadOn).As<Variant>();
		set => Set(GDExtensionPropertyName.UnloadOn, value);
	}

	public new static class GDExtensionMethodName
	{
		public new static readonly StringName HandleGameEvent = "handle_game_event";
		public new static readonly StringName LoadBank = "load_bank";
		public new static readonly StringName UnloadBank = "unload_bank";
	}

	public new void HandleGameEvent(AkUtils.GameEvent gameEvent) => 
		Call(GDExtensionMethodName.HandleGameEvent, [Variant.From(gameEvent)]);

	public new void LoadBank() => 
		Call(GDExtensionMethodName.LoadBank, []);

	public new void UnloadBank() => 
		Call(GDExtensionMethodName.UnloadBank, []);

}
