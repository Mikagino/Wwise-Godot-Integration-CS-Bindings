#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class WwiseEvent : WwiseBaseType
{

	private new static readonly StringName NativeName = new StringName("WwiseEvent");

	[Obsolete("Wrapper types cannot be constructed with constructors (it only instantiate the underlying WwiseEvent object), please use the Instantiate() method instead.")]
	protected WwiseEvent() { }

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="WwiseEvent"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="WwiseEvent"/> wrapper type,
	/// a new instance of the <see cref="WwiseEvent"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="WwiseEvent"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static WwiseEvent Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is WwiseEvent wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(WwiseEvent);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(WwiseEvent).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (WwiseEvent)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="WwiseEvent"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "WwiseEvent" type.</returns>
	public new static WwiseEvent Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName IsInUserDefinedSoundBank = "is_in_user_defined_sound_bank";
		public new static readonly StringName BankId = "bank_id";
		public new static readonly StringName IsAutoBankLoaded = "is_auto_bank_loaded";
		public new static readonly StringName PlayingId = "playing_id";
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

	public new long PlayingId
	{
		get => Get(GDExtensionPropertyName.PlayingId).As<long>();
		set => Set(GDExtensionPropertyName.PlayingId, value);
	}

	public new static class GDExtensionMethodName
	{
		public new static readonly StringName Post = "post";
		public new static readonly StringName PostCallback = "post_callback";
		public new static readonly StringName Stop = "stop";
		public new static readonly StringName ExecuteAction = "execute_action";
		public new static readonly StringName PostMidi = "post_midi";
		public new static readonly StringName StopMidi = "stop_midi";
	}

	public new long Post(Node gameObject) => 
		Call(GDExtensionMethodName.Post, [gameObject]).As<long>();

	public new long PostCallback(Node gameObject, AkUtils.AkCallbackType flags, Callable cookie) => 
		Call(GDExtensionMethodName.PostCallback, [gameObject, Variant.From(flags), cookie]).As<long>();

	public new void Stop(Node gameObject, long transitionDuration = 0, AkUtils.AkCurveInterpolation fadeCurve = AkUtils.AkCurveInterpolation.Linear) => 
		Call(GDExtensionMethodName.Stop, [gameObject, transitionDuration, Variant.From(fadeCurve)]);

	public new void ExecuteAction(Node gameObject, AkUtils.AkActionOnEventType actionOnEventType, long transitionDuration, AkUtils.AkCurveInterpolation fadeCurve) => 
		Call(GDExtensionMethodName.ExecuteAction, [gameObject, Variant.From(actionOnEventType), transitionDuration, Variant.From(fadeCurve)]);

	public new void PostMidi(Node gameObject, Godot.Collections.Array midiPosts) => 
		Call(GDExtensionMethodName.PostMidi, [gameObject, midiPosts]);

	public new void StopMidi(Node gameObject) => 
		Call(GDExtensionMethodName.StopMidi, [gameObject]);

}
