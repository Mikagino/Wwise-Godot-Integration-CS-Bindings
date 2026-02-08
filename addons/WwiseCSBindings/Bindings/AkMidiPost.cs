#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class AkMidiPost : RefCounted
{

	private new static readonly StringName NativeName = new StringName("AkMidiPost");

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="AkMidiPost"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="AkMidiPost"/> wrapper type,
	/// a new instance of the <see cref="AkMidiPost"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="AkMidiPost"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static AkMidiPost Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is AkMidiPost wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(AkMidiPost);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(AkMidiPost).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (AkMidiPost)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="AkMidiPost"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "AkMidiPost" type.</returns>
	public new static AkMidiPost Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public enum MidiEventType
	{
		Invalid = 0,
		NoteOff = 128,
		NoteOn = 144,
		NoteAftertouch = 160,
		Controller = 176,
		ProgramChange = 192,
		ChannelAftertouch = 208,
		PitchBend = 224,
		Sysex = 240,
		Escape = 247,
		WwiseCmd = 254,
	}

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName ByType = "by_type";
		public new static readonly StringName ByChan = "by_chan";
		public new static readonly StringName ByParam1 = "by_param1";
		public new static readonly StringName ByParam2 = "by_param2";
		public new static readonly StringName ByVelocity = "by_velocity";
		public new static readonly StringName ByCc = "by_cc";
		public new static readonly StringName ByValue = "by_value";
		public new static readonly StringName ByNote = "by_note";
		public new static readonly StringName ByValueLsb = "by_value_lsb";
		public new static readonly StringName ByValueMsb = "by_value_msb";
		public new static readonly StringName ByProgramNum = "by_program_num";
		public new static readonly StringName UCmd = "u_cmd";
		public new static readonly StringName UArg = "u_arg";
		public new static readonly StringName UOffset = "u_offset";
	}

	public new long ByType
	{
		get => Get(GDExtensionPropertyName.ByType).As<long>();
		set => Set(GDExtensionPropertyName.ByType, value);
	}

	public new long ByChan
	{
		get => Get(GDExtensionPropertyName.ByChan).As<long>();
		set => Set(GDExtensionPropertyName.ByChan, value);
	}

	public new long ByParam1
	{
		get => Get(GDExtensionPropertyName.ByParam1).As<long>();
		set => Set(GDExtensionPropertyName.ByParam1, value);
	}

	public new long ByParam2
	{
		get => Get(GDExtensionPropertyName.ByParam2).As<long>();
		set => Set(GDExtensionPropertyName.ByParam2, value);
	}

	public new long ByVelocity
	{
		get => Get(GDExtensionPropertyName.ByVelocity).As<long>();
		set => Set(GDExtensionPropertyName.ByVelocity, value);
	}

	public new long ByCc
	{
		get => Get(GDExtensionPropertyName.ByCc).As<long>();
		set => Set(GDExtensionPropertyName.ByCc, value);
	}

	public new long ByValue
	{
		get => Get(GDExtensionPropertyName.ByValue).As<long>();
		set => Set(GDExtensionPropertyName.ByValue, value);
	}

	public new long ByNote
	{
		get => Get(GDExtensionPropertyName.ByNote).As<long>();
		set => Set(GDExtensionPropertyName.ByNote, value);
	}

	public new long ByValueLsb
	{
		get => Get(GDExtensionPropertyName.ByValueLsb).As<long>();
		set => Set(GDExtensionPropertyName.ByValueLsb, value);
	}

	public new long ByValueMsb
	{
		get => Get(GDExtensionPropertyName.ByValueMsb).As<long>();
		set => Set(GDExtensionPropertyName.ByValueMsb, value);
	}

	public new long ByProgramNum
	{
		get => Get(GDExtensionPropertyName.ByProgramNum).As<long>();
		set => Set(GDExtensionPropertyName.ByProgramNum, value);
	}

	public new long UCmd
	{
		get => Get(GDExtensionPropertyName.UCmd).As<long>();
		set => Set(GDExtensionPropertyName.UCmd, value);
	}

	public new long UArg
	{
		get => Get(GDExtensionPropertyName.UArg).As<long>();
		set => Set(GDExtensionPropertyName.UArg, value);
	}

	public new long UOffset
	{
		get => Get(GDExtensionPropertyName.UOffset).As<long>();
		set => Set(GDExtensionPropertyName.UOffset, value);
	}

}
