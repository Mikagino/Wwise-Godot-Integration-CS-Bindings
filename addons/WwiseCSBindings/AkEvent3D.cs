#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class AkEvent3D : Node3D
{

	private new static readonly StringName NativeName = new StringName("AkEvent3D");

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="AkEvent3D"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="AkEvent3D"/> wrapper type,
	/// a new instance of the <see cref="AkEvent3D"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="AkEvent3D"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static AkEvent3D Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is AkEvent3D wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(AkEvent3D);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(AkEvent3D).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (AkEvent3D)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="AkEvent3D"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "AkEvent3D" type.</returns>
	public new static AkEvent3D Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionSignalName
	{
		public new static readonly StringName EndOfEvent = "end_of_event";
		public new static readonly StringName EndOfDynamicSequenceItem = "end_of_dynamic_sequence_item";
		public new static readonly StringName AudioMarker = "audio_marker";
		public new static readonly StringName Duration = "duration";
		public new static readonly StringName SpeakerVolumeMatrix = "speaker_volume_matrix";
		public new static readonly StringName AudioStarvation = "audio_starvation";
		public new static readonly StringName MusicPlaylistSelect = "music_playlist_select";
		public new static readonly StringName MusicPlayStarted = "music_play_started";
		public new static readonly StringName MusicSyncBeat = "music_sync_beat";
		public new static readonly StringName MusicSyncBar = "music_sync_bar";
		public new static readonly StringName MusicSyncEntry = "music_sync_entry";
		public new static readonly StringName MusicSyncExit = "music_sync_exit";
		public new static readonly StringName MusicSyncGrid = "music_sync_grid";
		public new static readonly StringName MusicSyncUserCue = "music_sync_user_cue";
		public new static readonly StringName MusicSyncPoint = "music_sync_point";
		public new static readonly StringName MusicSyncAll = "music_sync_all";
		public new static readonly StringName MidiEvent = "midi_event";
		public new static readonly StringName CallbackBits = "callback_bits";
		public new static readonly StringName EnableGetMusicPlayPosition = "enable_get_music_play_position";
		public new static readonly StringName EnableGetSourceStreamBuffering = "enable_get_source_stream_buffering";
	}

	public new delegate void EndOfEventSignalHandler(Godot.Collections.Dictionary data);
	private EndOfEventSignalHandler _endOfEventSignal;
	private Callable _endOfEventSignalCallable;
	public event EndOfEventSignalHandler EndOfEventSignal
	{
		add
		{
			if (_endOfEventSignal is null)
			{
				_endOfEventSignalCallable = Callable.From((Variant data) => 
					_endOfEventSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.EndOfEvent, _endOfEventSignalCallable);
			}
			_endOfEventSignal += value;
		}
		remove
		{
			_endOfEventSignal -= value;
			if (_endOfEventSignal is not null) return;
			Disconnect(GDExtensionSignalName.EndOfEvent, _endOfEventSignalCallable);
			_endOfEventSignalCallable = default;
		}
	}

	public new delegate void EndOfDynamicSequenceItemSignalHandler(Godot.Collections.Dictionary data);
	private EndOfDynamicSequenceItemSignalHandler _endOfDynamicSequenceItemSignal;
	private Callable _endOfDynamicSequenceItemSignalCallable;
	public event EndOfDynamicSequenceItemSignalHandler EndOfDynamicSequenceItemSignal
	{
		add
		{
			if (_endOfDynamicSequenceItemSignal is null)
			{
				_endOfDynamicSequenceItemSignalCallable = Callable.From((Variant data) => 
					_endOfDynamicSequenceItemSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.EndOfDynamicSequenceItem, _endOfDynamicSequenceItemSignalCallable);
			}
			_endOfDynamicSequenceItemSignal += value;
		}
		remove
		{
			_endOfDynamicSequenceItemSignal -= value;
			if (_endOfDynamicSequenceItemSignal is not null) return;
			Disconnect(GDExtensionSignalName.EndOfDynamicSequenceItem, _endOfDynamicSequenceItemSignalCallable);
			_endOfDynamicSequenceItemSignalCallable = default;
		}
	}

	public new delegate void AudioMarkerSignalHandler(Godot.Collections.Dictionary data);
	private AudioMarkerSignalHandler _audioMarkerSignal;
	private Callable _audioMarkerSignalCallable;
	public event AudioMarkerSignalHandler AudioMarkerSignal
	{
		add
		{
			if (_audioMarkerSignal is null)
			{
				_audioMarkerSignalCallable = Callable.From((Variant data) => 
					_audioMarkerSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.AudioMarker, _audioMarkerSignalCallable);
			}
			_audioMarkerSignal += value;
		}
		remove
		{
			_audioMarkerSignal -= value;
			if (_audioMarkerSignal is not null) return;
			Disconnect(GDExtensionSignalName.AudioMarker, _audioMarkerSignalCallable);
			_audioMarkerSignalCallable = default;
		}
	}

	public new delegate void DurationSignalHandler(Godot.Collections.Dictionary data);
	private DurationSignalHandler _durationSignal;
	private Callable _durationSignalCallable;
	public event DurationSignalHandler DurationSignal
	{
		add
		{
			if (_durationSignal is null)
			{
				_durationSignalCallable = Callable.From((Variant data) => 
					_durationSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.Duration, _durationSignalCallable);
			}
			_durationSignal += value;
		}
		remove
		{
			_durationSignal -= value;
			if (_durationSignal is not null) return;
			Disconnect(GDExtensionSignalName.Duration, _durationSignalCallable);
			_durationSignalCallable = default;
		}
	}

	public new delegate void SpeakerVolumeMatrixSignalHandler(Godot.Collections.Dictionary data);
	private SpeakerVolumeMatrixSignalHandler _speakerVolumeMatrixSignal;
	private Callable _speakerVolumeMatrixSignalCallable;
	public event SpeakerVolumeMatrixSignalHandler SpeakerVolumeMatrixSignal
	{
		add
		{
			if (_speakerVolumeMatrixSignal is null)
			{
				_speakerVolumeMatrixSignalCallable = Callable.From((Variant data) => 
					_speakerVolumeMatrixSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.SpeakerVolumeMatrix, _speakerVolumeMatrixSignalCallable);
			}
			_speakerVolumeMatrixSignal += value;
		}
		remove
		{
			_speakerVolumeMatrixSignal -= value;
			if (_speakerVolumeMatrixSignal is not null) return;
			Disconnect(GDExtensionSignalName.SpeakerVolumeMatrix, _speakerVolumeMatrixSignalCallable);
			_speakerVolumeMatrixSignalCallable = default;
		}
	}

	public new delegate void AudioStarvationSignalHandler(Godot.Collections.Dictionary data);
	private AudioStarvationSignalHandler _audioStarvationSignal;
	private Callable _audioStarvationSignalCallable;
	public event AudioStarvationSignalHandler AudioStarvationSignal
	{
		add
		{
			if (_audioStarvationSignal is null)
			{
				_audioStarvationSignalCallable = Callable.From((Variant data) => 
					_audioStarvationSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.AudioStarvation, _audioStarvationSignalCallable);
			}
			_audioStarvationSignal += value;
		}
		remove
		{
			_audioStarvationSignal -= value;
			if (_audioStarvationSignal is not null) return;
			Disconnect(GDExtensionSignalName.AudioStarvation, _audioStarvationSignalCallable);
			_audioStarvationSignalCallable = default;
		}
	}

	public new delegate void MusicPlaylistSelectSignalHandler(Godot.Collections.Dictionary data);
	private MusicPlaylistSelectSignalHandler _musicPlaylistSelectSignal;
	private Callable _musicPlaylistSelectSignalCallable;
	public event MusicPlaylistSelectSignalHandler MusicPlaylistSelectSignal
	{
		add
		{
			if (_musicPlaylistSelectSignal is null)
			{
				_musicPlaylistSelectSignalCallable = Callable.From((Variant data) => 
					_musicPlaylistSelectSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.MusicPlaylistSelect, _musicPlaylistSelectSignalCallable);
			}
			_musicPlaylistSelectSignal += value;
		}
		remove
		{
			_musicPlaylistSelectSignal -= value;
			if (_musicPlaylistSelectSignal is not null) return;
			Disconnect(GDExtensionSignalName.MusicPlaylistSelect, _musicPlaylistSelectSignalCallable);
			_musicPlaylistSelectSignalCallable = default;
		}
	}

	public new delegate void MusicPlayStartedSignalHandler(Godot.Collections.Dictionary data);
	private MusicPlayStartedSignalHandler _musicPlayStartedSignal;
	private Callable _musicPlayStartedSignalCallable;
	public event MusicPlayStartedSignalHandler MusicPlayStartedSignal
	{
		add
		{
			if (_musicPlayStartedSignal is null)
			{
				_musicPlayStartedSignalCallable = Callable.From((Variant data) => 
					_musicPlayStartedSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.MusicPlayStarted, _musicPlayStartedSignalCallable);
			}
			_musicPlayStartedSignal += value;
		}
		remove
		{
			_musicPlayStartedSignal -= value;
			if (_musicPlayStartedSignal is not null) return;
			Disconnect(GDExtensionSignalName.MusicPlayStarted, _musicPlayStartedSignalCallable);
			_musicPlayStartedSignalCallable = default;
		}
	}

	public new delegate void MusicSyncBeatSignalHandler(Godot.Collections.Dictionary data);
	private MusicSyncBeatSignalHandler _musicSyncBeatSignal;
	private Callable _musicSyncBeatSignalCallable;
	public event MusicSyncBeatSignalHandler MusicSyncBeatSignal
	{
		add
		{
			if (_musicSyncBeatSignal is null)
			{
				_musicSyncBeatSignalCallable = Callable.From((Variant data) => 
					_musicSyncBeatSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.MusicSyncBeat, _musicSyncBeatSignalCallable);
			}
			_musicSyncBeatSignal += value;
		}
		remove
		{
			_musicSyncBeatSignal -= value;
			if (_musicSyncBeatSignal is not null) return;
			Disconnect(GDExtensionSignalName.MusicSyncBeat, _musicSyncBeatSignalCallable);
			_musicSyncBeatSignalCallable = default;
		}
	}

	public new delegate void MusicSyncBarSignalHandler(Godot.Collections.Dictionary data);
	private MusicSyncBarSignalHandler _musicSyncBarSignal;
	private Callable _musicSyncBarSignalCallable;
	public event MusicSyncBarSignalHandler MusicSyncBarSignal
	{
		add
		{
			if (_musicSyncBarSignal is null)
			{
				_musicSyncBarSignalCallable = Callable.From((Variant data) => 
					_musicSyncBarSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.MusicSyncBar, _musicSyncBarSignalCallable);
			}
			_musicSyncBarSignal += value;
		}
		remove
		{
			_musicSyncBarSignal -= value;
			if (_musicSyncBarSignal is not null) return;
			Disconnect(GDExtensionSignalName.MusicSyncBar, _musicSyncBarSignalCallable);
			_musicSyncBarSignalCallable = default;
		}
	}

	public new delegate void MusicSyncEntrySignalHandler(Godot.Collections.Dictionary data);
	private MusicSyncEntrySignalHandler _musicSyncEntrySignal;
	private Callable _musicSyncEntrySignalCallable;
	public event MusicSyncEntrySignalHandler MusicSyncEntrySignal
	{
		add
		{
			if (_musicSyncEntrySignal is null)
			{
				_musicSyncEntrySignalCallable = Callable.From((Variant data) => 
					_musicSyncEntrySignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.MusicSyncEntry, _musicSyncEntrySignalCallable);
			}
			_musicSyncEntrySignal += value;
		}
		remove
		{
			_musicSyncEntrySignal -= value;
			if (_musicSyncEntrySignal is not null) return;
			Disconnect(GDExtensionSignalName.MusicSyncEntry, _musicSyncEntrySignalCallable);
			_musicSyncEntrySignalCallable = default;
		}
	}

	public new delegate void MusicSyncExitSignalHandler(Godot.Collections.Dictionary data);
	private MusicSyncExitSignalHandler _musicSyncExitSignal;
	private Callable _musicSyncExitSignalCallable;
	public event MusicSyncExitSignalHandler MusicSyncExitSignal
	{
		add
		{
			if (_musicSyncExitSignal is null)
			{
				_musicSyncExitSignalCallable = Callable.From((Variant data) => 
					_musicSyncExitSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.MusicSyncExit, _musicSyncExitSignalCallable);
			}
			_musicSyncExitSignal += value;
		}
		remove
		{
			_musicSyncExitSignal -= value;
			if (_musicSyncExitSignal is not null) return;
			Disconnect(GDExtensionSignalName.MusicSyncExit, _musicSyncExitSignalCallable);
			_musicSyncExitSignalCallable = default;
		}
	}

	public new delegate void MusicSyncGridSignalHandler(Godot.Collections.Dictionary data);
	private MusicSyncGridSignalHandler _musicSyncGridSignal;
	private Callable _musicSyncGridSignalCallable;
	public event MusicSyncGridSignalHandler MusicSyncGridSignal
	{
		add
		{
			if (_musicSyncGridSignal is null)
			{
				_musicSyncGridSignalCallable = Callable.From((Variant data) => 
					_musicSyncGridSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.MusicSyncGrid, _musicSyncGridSignalCallable);
			}
			_musicSyncGridSignal += value;
		}
		remove
		{
			_musicSyncGridSignal -= value;
			if (_musicSyncGridSignal is not null) return;
			Disconnect(GDExtensionSignalName.MusicSyncGrid, _musicSyncGridSignalCallable);
			_musicSyncGridSignalCallable = default;
		}
	}

	public new delegate void MusicSyncUserCueSignalHandler(Godot.Collections.Dictionary data);
	private MusicSyncUserCueSignalHandler _musicSyncUserCueSignal;
	private Callable _musicSyncUserCueSignalCallable;
	public event MusicSyncUserCueSignalHandler MusicSyncUserCueSignal
	{
		add
		{
			if (_musicSyncUserCueSignal is null)
			{
				_musicSyncUserCueSignalCallable = Callable.From((Variant data) => 
					_musicSyncUserCueSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.MusicSyncUserCue, _musicSyncUserCueSignalCallable);
			}
			_musicSyncUserCueSignal += value;
		}
		remove
		{
			_musicSyncUserCueSignal -= value;
			if (_musicSyncUserCueSignal is not null) return;
			Disconnect(GDExtensionSignalName.MusicSyncUserCue, _musicSyncUserCueSignalCallable);
			_musicSyncUserCueSignalCallable = default;
		}
	}

	public new delegate void MusicSyncPointSignalHandler(Godot.Collections.Dictionary data);
	private MusicSyncPointSignalHandler _musicSyncPointSignal;
	private Callable _musicSyncPointSignalCallable;
	public event MusicSyncPointSignalHandler MusicSyncPointSignal
	{
		add
		{
			if (_musicSyncPointSignal is null)
			{
				_musicSyncPointSignalCallable = Callable.From((Variant data) => 
					_musicSyncPointSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.MusicSyncPoint, _musicSyncPointSignalCallable);
			}
			_musicSyncPointSignal += value;
		}
		remove
		{
			_musicSyncPointSignal -= value;
			if (_musicSyncPointSignal is not null) return;
			Disconnect(GDExtensionSignalName.MusicSyncPoint, _musicSyncPointSignalCallable);
			_musicSyncPointSignalCallable = default;
		}
	}

	public new delegate void MusicSyncAllSignalHandler(Godot.Collections.Dictionary data);
	private MusicSyncAllSignalHandler _musicSyncAllSignal;
	private Callable _musicSyncAllSignalCallable;
	public event MusicSyncAllSignalHandler MusicSyncAllSignal
	{
		add
		{
			if (_musicSyncAllSignal is null)
			{
				_musicSyncAllSignalCallable = Callable.From((Variant data) => 
					_musicSyncAllSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.MusicSyncAll, _musicSyncAllSignalCallable);
			}
			_musicSyncAllSignal += value;
		}
		remove
		{
			_musicSyncAllSignal -= value;
			if (_musicSyncAllSignal is not null) return;
			Disconnect(GDExtensionSignalName.MusicSyncAll, _musicSyncAllSignalCallable);
			_musicSyncAllSignalCallable = default;
		}
	}

	public new delegate void MidiEventSignalHandler(Godot.Collections.Dictionary data);
	private MidiEventSignalHandler _midiEventSignal;
	private Callable _midiEventSignalCallable;
	public event MidiEventSignalHandler MidiEventSignal
	{
		add
		{
			if (_midiEventSignal is null)
			{
				_midiEventSignalCallable = Callable.From((Variant data) => 
					_midiEventSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.MidiEvent, _midiEventSignalCallable);
			}
			_midiEventSignal += value;
		}
		remove
		{
			_midiEventSignal -= value;
			if (_midiEventSignal is not null) return;
			Disconnect(GDExtensionSignalName.MidiEvent, _midiEventSignalCallable);
			_midiEventSignalCallable = default;
		}
	}

	public new delegate void CallbackBitsSignalHandler(Godot.Collections.Dictionary data);
	private CallbackBitsSignalHandler _callbackBitsSignal;
	private Callable _callbackBitsSignalCallable;
	public event CallbackBitsSignalHandler CallbackBitsSignal
	{
		add
		{
			if (_callbackBitsSignal is null)
			{
				_callbackBitsSignalCallable = Callable.From((Variant data) => 
					_callbackBitsSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.CallbackBits, _callbackBitsSignalCallable);
			}
			_callbackBitsSignal += value;
		}
		remove
		{
			_callbackBitsSignal -= value;
			if (_callbackBitsSignal is not null) return;
			Disconnect(GDExtensionSignalName.CallbackBits, _callbackBitsSignalCallable);
			_callbackBitsSignalCallable = default;
		}
	}

	public new delegate void EnableGetMusicPlayPositionSignalHandler(Godot.Collections.Dictionary data);
	private EnableGetMusicPlayPositionSignalHandler _enableGetMusicPlayPositionSignal;
	private Callable _enableGetMusicPlayPositionSignalCallable;
	public event EnableGetMusicPlayPositionSignalHandler EnableGetMusicPlayPositionSignal
	{
		add
		{
			if (_enableGetMusicPlayPositionSignal is null)
			{
				_enableGetMusicPlayPositionSignalCallable = Callable.From((Variant data) => 
					_enableGetMusicPlayPositionSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.EnableGetMusicPlayPosition, _enableGetMusicPlayPositionSignalCallable);
			}
			_enableGetMusicPlayPositionSignal += value;
		}
		remove
		{
			_enableGetMusicPlayPositionSignal -= value;
			if (_enableGetMusicPlayPositionSignal is not null) return;
			Disconnect(GDExtensionSignalName.EnableGetMusicPlayPosition, _enableGetMusicPlayPositionSignalCallable);
			_enableGetMusicPlayPositionSignalCallable = default;
		}
	}

	public new delegate void EnableGetSourceStreamBufferingSignalHandler(Godot.Collections.Dictionary data);
	private EnableGetSourceStreamBufferingSignalHandler _enableGetSourceStreamBufferingSignal;
	private Callable _enableGetSourceStreamBufferingSignalCallable;
	public event EnableGetSourceStreamBufferingSignalHandler EnableGetSourceStreamBufferingSignal
	{
		add
		{
			if (_enableGetSourceStreamBufferingSignal is null)
			{
				_enableGetSourceStreamBufferingSignalCallable = Callable.From((Variant data) => 
					_enableGetSourceStreamBufferingSignal?.Invoke(data.As<Godot.Collections.Dictionary>()));
				Connect(GDExtensionSignalName.EnableGetSourceStreamBuffering, _enableGetSourceStreamBufferingSignalCallable);
			}
			_enableGetSourceStreamBufferingSignal += value;
		}
		remove
		{
			_enableGetSourceStreamBufferingSignal -= value;
			if (_enableGetSourceStreamBufferingSignal is not null) return;
			Disconnect(GDExtensionSignalName.EnableGetSourceStreamBuffering, _enableGetSourceStreamBufferingSignalCallable);
			_enableGetSourceStreamBufferingSignalCallable = default;
		}
	}

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName Event = "event";
		public new static readonly StringName TriggerOn = "trigger_on";
		public new static readonly StringName StopOn = "stop_on";
		public new static readonly StringName StopFadeTime = "stop_fade_time";
		public new static readonly StringName InterpolationMode = "interpolation_mode";
		public new static readonly StringName IsEnvironmentAware = "is_environment_aware";
		public new static readonly StringName RoomId = "room_id";
	}

	public new WwiseEvent Event
	{
		get => WwiseEvent.Bind(Get(GDExtensionPropertyName.Event).As<Resource>());
		set => Set(GDExtensionPropertyName.Event, value);
	}

	public new Variant TriggerOn
	{
		get => Get(GDExtensionPropertyName.TriggerOn).As<Variant>();
		set => Set(GDExtensionPropertyName.TriggerOn, value);
	}

	public new Variant StopOn
	{
		get => Get(GDExtensionPropertyName.StopOn).As<Variant>();
		set => Set(GDExtensionPropertyName.StopOn, value);
	}

	public new long StopFadeTime
	{
		get => Get(GDExtensionPropertyName.StopFadeTime).As<long>();
		set => Set(GDExtensionPropertyName.StopFadeTime, value);
	}

	public new AkUtils.AkCurveInterpolation InterpolationMode
	{
		get => Get(GDExtensionPropertyName.InterpolationMode).As<AkUtils.AkCurveInterpolation>();
		set => Set(GDExtensionPropertyName.InterpolationMode, Variant.From(value));
	}

	public new bool IsEnvironmentAware
	{
		get => Get(GDExtensionPropertyName.IsEnvironmentAware).As<bool>();
		set => Set(GDExtensionPropertyName.IsEnvironmentAware, value);
	}

	public new long RoomId
	{
		get => Get(GDExtensionPropertyName.RoomId).As<long>();
		set => Set(GDExtensionPropertyName.RoomId, value);
	}

	public new static class GDExtensionMethodName
	{
		public new static readonly StringName HandleGameEvent = "handle_game_event";
		public new static readonly StringName PostEvent = "post_event";
		public new static readonly StringName StopEvent = "stop_event";
		public new static readonly StringName CallbackEmitter = "callback_emitter";
		public new static readonly StringName GetPlayingId = "get_playing_id";
	}

	public new void HandleGameEvent(AkUtils.GameEvent gameEvent) => 
		Call(GDExtensionMethodName.HandleGameEvent, [Variant.From(gameEvent)]);

	public new void PostEvent() => 
		Call(GDExtensionMethodName.PostEvent, []);

	public new void StopEvent() => 
		Call(GDExtensionMethodName.StopEvent, []);

	public new void CallbackEmitter(Godot.Collections.Dictionary data) => 
		Call(GDExtensionMethodName.CallbackEmitter, [data]);

	public new long GetPlayingId() => 
		Call(GDExtensionMethodName.GetPlayingId, []).As<long>();

}
