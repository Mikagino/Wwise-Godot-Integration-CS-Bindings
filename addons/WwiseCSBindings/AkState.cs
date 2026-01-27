#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class AkState : Node
{

	private new static readonly StringName NativeName = new StringName("AkState");

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="AkState"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="AkState"/> wrapper type,
	/// a new instance of the <see cref="AkState"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="AkState"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static AkState Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is AkState wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(AkState);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(AkState).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (AkState)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="AkState"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "AkState" type.</returns>
	public new static AkState Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName State = "state";
		public new static readonly StringName TriggerOn = "trigger_on";
	}

	public new WwiseState State
	{
		get => WwiseState.Bind(Get(GDExtensionPropertyName.State).As<Resource>());
		set => Set(GDExtensionPropertyName.State, value);
	}

	public new Variant TriggerOn
	{
		get => Get(GDExtensionPropertyName.TriggerOn).As<Variant>();
		set => Set(GDExtensionPropertyName.TriggerOn, value);
	}

	public new static class GDExtensionMethodName
	{
		public new static readonly StringName HandleGameEvent = "handle_game_event";
		public new static readonly StringName SetValue = "set_value";
	}

	public new void HandleGameEvent(AkUtils.GameEvent gameEvent) => 
		Call(GDExtensionMethodName.HandleGameEvent, [Variant.From(gameEvent)]);

	public new void SetValue() => 
		Call(GDExtensionMethodName.SetValue, []);

}
