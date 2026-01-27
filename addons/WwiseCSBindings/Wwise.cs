#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class Wwise : GodotObject
{

	private new static readonly StringName NativeName = new StringName("Wwise");

	[Obsolete("Wrapper types cannot be constructed with constructors (it only instantiate the underlying Wwise object), please use the Instantiate() method instead.")]
	protected Wwise() { }

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="Wwise"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="Wwise"/> wrapper type,
	/// a new instance of the <see cref="Wwise"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="Wwise"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static Wwise Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is Wwise wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(Wwise);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(Wwise).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (Wwise)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="Wwise"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "Wwise" type.</returns>
	public new static Wwise Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionMethodName
	{
		public new static readonly StringName Init = "init";
		public new static readonly StringName RenderAudio = "render_audio";
		public new static readonly StringName Shutdown = "shutdown";
		public new static readonly StringName SetBanksPath = "set_banks_path";
		public new static readonly StringName SetCurrentLanguage = "set_current_language";
		public new static readonly StringName LoadBank = "load_bank";
		public new static readonly StringName LoadBankId = "load_bank_id";
		public new static readonly StringName LoadBankAsync = "load_bank_async";
		public new static readonly StringName LoadBankAsyncId = "load_bank_async_id";
		public new static readonly StringName UnloadBank = "unload_bank";
		public new static readonly StringName UnloadBankId = "unload_bank_id";
		public new static readonly StringName UnloadBankAsync = "unload_bank_async";
		public new static readonly StringName UnloadBankAsyncId = "unload_bank_async_id";
		public new static readonly StringName RegisterListener = "register_listener";
		public new static readonly StringName RegisterGameObj = "register_game_obj";
		public new static readonly StringName UnregisterGameObj = "unregister_game_obj";
		public new static readonly StringName AddListener = "add_listener";
		public new static readonly StringName RemoveListener = "remove_listener";
		public new static readonly StringName AddDefaultListener = "add_default_listener";
		public new static readonly StringName RemoveDefaultListener = "remove_default_listener";
		public new static readonly StringName SetListeners = "set_listeners";
		public new static readonly StringName SetDistanceProbe = "set_distance_probe";
		public new static readonly StringName ResetDistanceProbe = "reset_distance_probe";
		public new static readonly StringName SetRandomSeed = "set_random_seed";
		public new static readonly StringName Set3dPosition = "set_3d_position";
		public new static readonly StringName Set2dPosition = "set_2d_position";
		public new static readonly StringName SetMultiplePositions3d = "set_multiple_positions_3d";
		public new static readonly StringName SetMultiplePositions2d = "set_multiple_positions_2d";
		public new static readonly StringName SetGameObjectRadius = "set_game_object_radius";
		public new static readonly StringName PostEvent = "post_event";
		public new static readonly StringName PostEventCallback = "post_event_callback";
		public new static readonly StringName PostEventId = "post_event_id";
		public new static readonly StringName PostEventIdCallback = "post_event_id_callback";
		public new static readonly StringName PostMidiOnEventId = "post_midi_on_event_id";
		public new static readonly StringName StopEvent = "stop_event";
		public new static readonly StringName StopMidiOnEventId = "stop_midi_on_event_id";
		public new static readonly StringName ExecuteActionOnEventId = "execute_action_on_event_id";
		public new static readonly StringName SetSwitch = "set_switch";
		public new static readonly StringName SetSwitchId = "set_switch_id";
		public new static readonly StringName SetState = "set_state";
		public new static readonly StringName SetStateId = "set_state_id";
		public new static readonly StringName GetRtpcValue = "get_rtpc_value";
		public new static readonly StringName GetRtpcValueId = "get_rtpc_value_id";
		public new static readonly StringName SetRtpcValue = "set_rtpc_value";
		public new static readonly StringName SetRtpcValueId = "set_rtpc_value_id";
		public new static readonly StringName PostTrigger = "post_trigger";
		public new static readonly StringName PostTriggerId = "post_trigger_id";
		public new static readonly StringName PostExternalSource = "post_external_source";
		public new static readonly StringName PostExternalSourceId = "post_external_source_id";
		public new static readonly StringName PostExternalSources = "post_external_sources";
		public new static readonly StringName GetSourcePlayPosition = "get_source_play_position";
		public new static readonly StringName GetPlayingSegmentInfo = "get_playing_segment_info";
		public new static readonly StringName SetGameObjectOutputBusVolume = "set_game_object_output_bus_volume";
		public new static readonly StringName SetGameObjectAuxSendValues = "set_game_object_aux_send_values";
		public new static readonly StringName SetObjectObstructionAndOcclusion = "set_object_obstruction_and_occlusion";
		public new static readonly StringName SetGeometry = "set_geometry";
		public new static readonly StringName RemoveGeometry = "remove_geometry";
		public new static readonly StringName SetGeometryInstance = "set_geometry_instance";
		public new static readonly StringName RemoveGeometryInstance = "remove_geometry_instance";
		public new static readonly StringName RegisterSpatialListener = "register_spatial_listener";
		public new static readonly StringName SetRoom = "set_room";
		public new static readonly StringName RemoveRoom = "remove_room";
		public new static readonly StringName SetPortal = "set_portal";
		public new static readonly StringName RemovePortal = "remove_portal";
		public new static readonly StringName SetPortalObstructionAndOcclusion = "set_portal_obstruction_and_occlusion";
		public new static readonly StringName SetGameObjectToPortalObstruction = "set_game_object_to_portal_obstruction";
		public new static readonly StringName SetPortalToPortalObstruction = "set_portal_to_portal_obstruction";
		public new static readonly StringName SetGameObjectInRoom = "set_game_object_in_room";
		public new static readonly StringName RemoveGameObjectFromRoom = "remove_game_object_from_room";
		public new static readonly StringName SetEarlyReflectionsAuxSend = "set_early_reflections_aux_send";
		public new static readonly StringName SetEarlyReflectionsVolume = "set_early_reflections_volume";
		public new static readonly StringName AddOutput = "add_output";
		public new static readonly StringName RemoveOutput = "remove_output";
		public new static readonly StringName Suspend = "suspend";
		public new static readonly StringName WakeupFromSuspend = "wakeup_from_suspend";
		public new static readonly StringName StopAll = "stop_all";
		public new static readonly StringName GetSampleTick = "get_sample_tick";
		public new static readonly StringName GetIdFromString = "get_id_from_string";
		public new static readonly StringName IsInitialized = "is_initialized";
	}

	public new void Init() => 
		Call(GDExtensionMethodName.Init, []);

	public new void RenderAudio() => 
		Call(GDExtensionMethodName.RenderAudio, []);

	public new void Shutdown() => 
		Call(GDExtensionMethodName.Shutdown, []);

	public new void SetBanksPath(string rootOutputPath) => 
		Call(GDExtensionMethodName.SetBanksPath, [rootOutputPath]);

	public new void SetCurrentLanguage(string language) => 
		Call(GDExtensionMethodName.SetCurrentLanguage, [language]);

	public new bool LoadBank(string bankName) => 
		Call(GDExtensionMethodName.LoadBank, [bankName]).As<bool>();

	public new bool LoadBankId(long bankId) => 
		Call(GDExtensionMethodName.LoadBankId, [bankId]).As<bool>();

	public new bool LoadBankAsync(string bankName, Callable cookie) => 
		Call(GDExtensionMethodName.LoadBankAsync, [bankName, cookie]).As<bool>();

	public new bool LoadBankAsyncId(long bankId, Callable cookie) => 
		Call(GDExtensionMethodName.LoadBankAsyncId, [bankId, cookie]).As<bool>();

	public new bool UnloadBank(string bankName) => 
		Call(GDExtensionMethodName.UnloadBank, [bankName]).As<bool>();

	public new bool UnloadBankId(long bankId) => 
		Call(GDExtensionMethodName.UnloadBankId, [bankId]).As<bool>();

	public new bool UnloadBankAsync(string bankName, Callable cookie) => 
		Call(GDExtensionMethodName.UnloadBankAsync, [bankName, cookie]).As<bool>();

	public new bool UnloadBankAsyncId(long bankId, Callable cookie) => 
		Call(GDExtensionMethodName.UnloadBankAsyncId, [bankId, cookie]).As<bool>();

	public new bool RegisterListener(Node gameObject) => 
		Call(GDExtensionMethodName.RegisterListener, [gameObject]).As<bool>();

	public new bool RegisterGameObj(Node gameObject, string name) => 
		Call(GDExtensionMethodName.RegisterGameObj, [gameObject, name]).As<bool>();

	public new bool UnregisterGameObj(Node gameObject) => 
		Call(GDExtensionMethodName.UnregisterGameObj, [gameObject]).As<bool>();

	public new bool AddListener(Node emitter, Node listener) => 
		Call(GDExtensionMethodName.AddListener, [emitter, listener]).As<bool>();

	public new bool RemoveListener(Node emitter, Node listener) => 
		Call(GDExtensionMethodName.RemoveListener, [emitter, listener]).As<bool>();

	public new bool AddDefaultListener(Node gameObject) => 
		Call(GDExtensionMethodName.AddDefaultListener, [gameObject]).As<bool>();

	public new bool RemoveDefaultListener(Node gameObject) => 
		Call(GDExtensionMethodName.RemoveDefaultListener, [gameObject]).As<bool>();

	public new bool SetListeners(Node emitter, Godot.Collections.Array listeners) => 
		Call(GDExtensionMethodName.SetListeners, [emitter, listeners]).As<bool>();

	public new bool SetDistanceProbe(Node listenerGameObject, Node probeGameObject) => 
		Call(GDExtensionMethodName.SetDistanceProbe, [listenerGameObject, probeGameObject]).As<bool>();

	public new bool ResetDistanceProbe(Node listenerGameObject) => 
		Call(GDExtensionMethodName.ResetDistanceProbe, [listenerGameObject]).As<bool>();

	public new void SetRandomSeed(long seed) => 
		Call(GDExtensionMethodName.SetRandomSeed, [seed]);

	public new bool Set3dPosition(Node gameObject, Transform3D transform3d) => 
		Call(GDExtensionMethodName.Set3dPosition, [gameObject, transform3d]).As<bool>();

	public new bool Set2dPosition(Node gameObject, Transform2D transform2d, double zDepth) => 
		Call(GDExtensionMethodName.Set2dPosition, [gameObject, transform2d, zDepth]).As<bool>();

	public new bool SetMultiplePositions3d(Node gameObject, Godot.Collections.Array positions, long numPositions, AkUtils.MultiPositionType multiPositionType) => 
		Call(GDExtensionMethodName.SetMultiplePositions3d, [gameObject, positions, numPositions, Variant.From(multiPositionType)]).As<bool>();

	public new bool SetMultiplePositions2d(Node gameObject, Godot.Collections.Array positions, Godot.Collections.Array zDepths, long numPositions, AkUtils.MultiPositionType multiPositionType) => 
		Call(GDExtensionMethodName.SetMultiplePositions2d, [gameObject, positions, zDepths, numPositions, Variant.From(multiPositionType)]).As<bool>();

	public new bool SetGameObjectRadius(Node gameObject, double outerRadius, double innerRadius) => 
		Call(GDExtensionMethodName.SetGameObjectRadius, [gameObject, outerRadius, innerRadius]).As<bool>();

	public new long PostEvent(string eventName, Node gameObject) => 
		Call(GDExtensionMethodName.PostEvent, [eventName, gameObject]).As<long>();

	public new long PostEventCallback(string eventName, AkUtils.AkCallbackType flags, Node gameObject, Callable cookie) => 
		Call(GDExtensionMethodName.PostEventCallback, [eventName, Variant.From(flags), gameObject, cookie]).As<long>();

	public new long PostEventId(long eventId, Node gameObject) => 
		Call(GDExtensionMethodName.PostEventId, [eventId, gameObject]).As<long>();

	public new long PostEventIdCallback(long eventId, AkUtils.AkCallbackType flags, Node gameObject, Callable cookie) => 
		Call(GDExtensionMethodName.PostEventIdCallback, [eventId, Variant.From(flags), gameObject, cookie]).As<long>();

	public new long PostMidiOnEventId(long eventId, Node gameObject, Godot.Collections.Array midiPosts, bool absoluteOffsets) => 
		Call(GDExtensionMethodName.PostMidiOnEventId, [eventId, gameObject, midiPosts, absoluteOffsets]).As<long>();

	public new void StopEvent(long playingId, long fadeTime, AkUtils.AkCurveInterpolation interpolation) => 
		Call(GDExtensionMethodName.StopEvent, [playingId, fadeTime, Variant.From(interpolation)]);

	public new bool StopMidiOnEventId(long eventId, Node gameObject) => 
		Call(GDExtensionMethodName.StopMidiOnEventId, [eventId, gameObject]).As<bool>();

	public new bool ExecuteActionOnEventId(long eventId, AkUtils.AkActionOnEventType actionType, Node gameObject, long transitionDuration = 0, AkUtils.AkCurveInterpolation fadeCurve = AkUtils.AkCurveInterpolation.Linear, long playingId = 0) => 
		Call(GDExtensionMethodName.ExecuteActionOnEventId, [eventId, Variant.From(actionType), gameObject, transitionDuration, Variant.From(fadeCurve), playingId]).As<bool>();

	public new bool SetSwitch(string switchGroup, string switchValue, Node gameObject) => 
		Call(GDExtensionMethodName.SetSwitch, [switchGroup, switchValue, gameObject]).As<bool>();

	public new bool SetSwitchId(long switchGroupId, long switchValueId, Node gameObject) => 
		Call(GDExtensionMethodName.SetSwitchId, [switchGroupId, switchValueId, gameObject]).As<bool>();

	public new bool SetState(string stateGroup, string stateValue) => 
		Call(GDExtensionMethodName.SetState, [stateGroup, stateValue]).As<bool>();

	public new bool SetStateId(long stateGroupId, long stateValueId) => 
		Call(GDExtensionMethodName.SetStateId, [stateGroupId, stateValueId]).As<bool>();

	public new double GetRtpcValue(string name, Node gameObject) => 
		Call(GDExtensionMethodName.GetRtpcValue, [name, gameObject]).As<double>();

	public new double GetRtpcValueId(long id, Node gameObject) => 
		Call(GDExtensionMethodName.GetRtpcValueId, [id, gameObject]).As<double>();

	public new bool SetRtpcValue(string name, double value, Node gameObject) => 
		Call(GDExtensionMethodName.SetRtpcValue, [name, value, gameObject]).As<bool>();

	public new bool SetRtpcValueId(long id, double value, Node gameObject) => 
		Call(GDExtensionMethodName.SetRtpcValueId, [id, value, gameObject]).As<bool>();

	public new bool PostTrigger(string name, Node gameObject) => 
		Call(GDExtensionMethodName.PostTrigger, [name, gameObject]).As<bool>();

	public new bool PostTriggerId(long id, Node gameObject) => 
		Call(GDExtensionMethodName.PostTriggerId, [id, gameObject]).As<bool>();

	public new long PostExternalSource(string eventName, Node gameObject, string sourceObjectName, string filename, AkUtils.AkCodecId idCodec) => 
		Call(GDExtensionMethodName.PostExternalSource, [eventName, gameObject, sourceObjectName, filename, Variant.From(idCodec)]).As<long>();

	public new long PostExternalSourceId(long eventId, Node gameObject, long sourceObjectId, string filename, AkUtils.AkCodecId idCodec) => 
		Call(GDExtensionMethodName.PostExternalSourceId, [eventId, gameObject, sourceObjectId, filename, Variant.From(idCodec)]).As<long>();

	public new long PostExternalSources(long eventId, Node gameObject, Godot.Collections.Array externalSourceInfo) => 
		Call(GDExtensionMethodName.PostExternalSources, [eventId, gameObject, externalSourceInfo]).As<long>();

	public new long GetSourcePlayPosition(long playingId, bool extrapolate) => 
		Call(GDExtensionMethodName.GetSourcePlayPosition, [playingId, extrapolate]).As<long>();

	public new Godot.Collections.Dictionary GetPlayingSegmentInfo(long playingId, bool extrapolate) => 
		Call(GDExtensionMethodName.GetPlayingSegmentInfo, [playingId, extrapolate]).As<Godot.Collections.Dictionary>();

	public new bool SetGameObjectOutputBusVolume(Node gameObject, Node listener, double fControlValue) => 
		Call(GDExtensionMethodName.SetGameObjectOutputBusVolume, [gameObject, listener, fControlValue]).As<bool>();

	public new bool SetGameObjectAuxSendValues(Node gameObject, Godot.Collections.Array akAuxSendValues, long numSendValues) => 
		Call(GDExtensionMethodName.SetGameObjectAuxSendValues, [gameObject, akAuxSendValues, numSendValues]).As<bool>();

	public new bool SetObjectObstructionAndOcclusion(Node gameObject, Node listener, double calculatedObs, double calculatedOcc) => 
		Call(GDExtensionMethodName.SetObjectObstructionAndOcclusion, [gameObject, listener, calculatedObs, calculatedOcc]).As<bool>();

	public new bool SetGeometry(Godot.Collections.Array vertices, Godot.Collections.Array triangles, WwiseAcousticTexture acousticTexture, double transissionLossValue, Node gameObject, bool enableDiffraction, bool enableDiffractionOnBoundaryEdges) => 
		Call(GDExtensionMethodName.SetGeometry, [vertices, triangles, acousticTexture, transissionLossValue, gameObject, enableDiffraction, enableDiffractionOnBoundaryEdges]).As<bool>();

	public new bool RemoveGeometry(GodotObject gameObject) => 
		Call(GDExtensionMethodName.RemoveGeometry, [gameObject]).As<bool>();

	public new bool SetGeometryInstance(GodotObject associatedGeometry, Transform3D transform, bool useForReflectionAndDiffraction, bool isSolid, bool bypassPortalSubtraction, GodotObject geometryInstance) => 
		Call(GDExtensionMethodName.SetGeometryInstance, [associatedGeometry, transform, useForReflectionAndDiffraction, isSolid, bypassPortalSubtraction, geometryInstance]).As<bool>();

	public new bool RemoveGeometryInstance(GodotObject geometryInstance) => 
		Call(GDExtensionMethodName.RemoveGeometryInstance, [geometryInstance]).As<bool>();

	public new bool RegisterSpatialListener(Node gameObject) => 
		Call(GDExtensionMethodName.RegisterSpatialListener, [gameObject]).As<bool>();

	public new bool SetRoom(Node gameObject, long auxBusId, double reverbLevel, double transmissionLoss, Vector3 frontVector, Vector3 upVector, bool keepRegistered, GodotObject associatedGeometry) => 
		Call(GDExtensionMethodName.SetRoom, [gameObject, auxBusId, reverbLevel, transmissionLoss, frontVector, upVector, keepRegistered, associatedGeometry]).As<bool>();

	public new bool RemoveRoom(Node gameObject) => 
		Call(GDExtensionMethodName.RemoveRoom, [gameObject]).As<bool>();

	public new bool SetPortal(Node gameObject, Transform3D transform, Vector3 extent, Node frontRoom, Node backRoom, bool enabled) => 
		Call(GDExtensionMethodName.SetPortal, [gameObject, transform, extent, frontRoom, backRoom, enabled]).As<bool>();

	public new bool RemovePortal(Node gameObject) => 
		Call(GDExtensionMethodName.RemovePortal, [gameObject]).As<bool>();

	public new bool SetPortalObstructionAndOcclusion(Node portal, double obstructionValue, double occlusionValue) => 
		Call(GDExtensionMethodName.SetPortalObstructionAndOcclusion, [portal, obstructionValue, occlusionValue]).As<bool>();

	public new bool SetGameObjectToPortalObstruction(Node gameObject, Node portal, double obstructionValue) => 
		Call(GDExtensionMethodName.SetGameObjectToPortalObstruction, [gameObject, portal, obstructionValue]).As<bool>();

	public new bool SetPortalToPortalObstruction(Node portal0, Node portal1, double obstructionValue) => 
		Call(GDExtensionMethodName.SetPortalToPortalObstruction, [portal0, portal1, obstructionValue]).As<bool>();

	public new bool SetGameObjectInRoom(Node gameObject, Node room) => 
		Call(GDExtensionMethodName.SetGameObjectInRoom, [gameObject, room]).As<bool>();

	public new bool RemoveGameObjectFromRoom(Node gameObject) => 
		Call(GDExtensionMethodName.RemoveGameObjectFromRoom, [gameObject]).As<bool>();

	public new bool SetEarlyReflectionsAuxSend(Node gameObject, long auxId) => 
		Call(GDExtensionMethodName.SetEarlyReflectionsAuxSend, [gameObject, auxId]).As<bool>();

	public new bool SetEarlyReflectionsVolume(Node gameObject, double volume) => 
		Call(GDExtensionMethodName.SetEarlyReflectionsVolume, [gameObject, volume]).As<bool>();

	public new bool AddOutput(string shareSet, long outputId) => 
		Call(GDExtensionMethodName.AddOutput, [shareSet, outputId]).As<bool>();

	public new bool RemoveOutput(long outputId) => 
		Call(GDExtensionMethodName.RemoveOutput, [outputId]).As<bool>();

	public new bool Suspend(bool renderAnyway) => 
		Call(GDExtensionMethodName.Suspend, [renderAnyway]).As<bool>();

	public new bool WakeupFromSuspend() => 
		Call(GDExtensionMethodName.WakeupFromSuspend, []).As<bool>();

	public new void StopAll(Node gameObject = null) => 
		Call(GDExtensionMethodName.StopAll, [gameObject]);

	public new long GetSampleTick() => 
		Call(GDExtensionMethodName.GetSampleTick, []).As<long>();

	public new long GetIdFromString(string @string) => 
		Call(GDExtensionMethodName.GetIdFromString, [@string]).As<long>();

	public new bool IsInitialized() => 
		Call(GDExtensionMethodName.IsInitialized, []).As<bool>();

}
