#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class AkUtils : GodotObject
{

	private new static readonly StringName NativeName = new StringName("AkUtils");

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="AkUtils"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="AkUtils"/> wrapper type,
	/// a new instance of the <see cref="AkUtils"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="AkUtils"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static AkUtils Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is AkUtils wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(AkUtils);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(AkUtils).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (AkUtils)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="AkUtils"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "AkUtils" type.</returns>
	public new static AkUtils Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public enum GameEvent
	{
		GameeventNone = 0,
		GameeventEnterTree = 1,
		GameeventReady = 2,
		GameeventExitTree = 3,
	}

	public enum AkCurveInterpolation
	{
		Log3 = 0,
		Sine = 1,
		Log1 = 2,
		Invscurve = 3,
		Linear = 4,
		Scurve = 5,
		Exp1 = 6,
		Sinerecip = 7,
		Exp3 = 8,
		Lastfadecurve = 8,
		Constant = 9,
	}

	public enum AkCallbackType
	{
		EndOfEvent = 1,
		EndOfDynamicSequenceItem = 2,
		Marker = 4,
		Duration = 8,
		SpeakerVolumeMatrix = 16,
		Starvation = 32,
		MusicPlaylistSelect = 64,
		MusicPlayStarted = 128,
		MusicSyncBeat = 256,
		MusicSyncBar = 512,
		MusicSyncEntry = 1024,
		MusicSyncExit = 2048,
		MusicSyncGrid = 4096,
		MusicSyncUserCue = 8192,
		MusicSyncPoint = 16384,
		MusicSyncAll = 32512,
		MidiEvent = 32768,
		Bits = 1048575,
		EnableGetMusicPlayPosition = 2097152,
		EnableGetSourceStreamBuffering = 4194304,
	}

	public enum AkActionOnEventType
	{
		Stop = 0,
		Pause = 1,
		Resume = 2,
		Break = 3,
		ReleaseEnvelope = 4,
	}

	public enum MultiPositionType
	{
		SingleSource = 0,
		TypeMultiSources = 1,
		TypeMultiDirections = 2,
	}

	public enum AkCodecId
	{
		CodecidBank = 0,
		CodecidPcm = 1,
		CodecidAdpcm = 2,
		CodecidXma = 3,
		CodecidVorbis = 4,
		CodecidWiiadpcm = 5,
		CodecidPcmex = 7,
		CodecidExternalSource = 8,
		CodecidXwma = 9,
		CodecidAac = 10,
		CodecidFilePackage = 11,
		CodecidAtrac9 = 12,
		CodecidVag = 13,
		CodecidProfilercapture = 14,
		CodecidAnalysisfile = 15,
		CodecidMidi = 16,
		CodecidOpusnx = 17,
		CodecidCaf = 18,
		CodecidAkopus = 19,
		CodecidAkopusWem = 20,
		CodecidMemorymgrDump = 21,
		CodecidSony360 = 22,
		CodecidBankEvent = 30,
		CodecidBankBus = 31,
	}

}
