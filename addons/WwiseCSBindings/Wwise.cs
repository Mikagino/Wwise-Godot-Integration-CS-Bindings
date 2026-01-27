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

	private static GodotObject _instance;

    private static GodotObject Instance
    {
        get
        {
            if (_instance == null)
            {
                if (Engine.HasSingleton("Wwise"))
                    _instance = Engine.GetSingleton("Wwise");
                else
                    GD.PrintErr("Wwise singleton not loaded!");
            }
            return _instance;
        }
    }

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
	// public new static Wwise Instantiate()
	// {
	// 	Instance = Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());
	// 	return Instance;
	// }

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

	public static new void Init() => 
		Instance.Call(GDExtensionMethodName.Init, []);

	public static new void RenderAudio() => 
		Instance.Call(GDExtensionMethodName.RenderAudio, []);

	public static  new void Shutdown() => 
		Instance.Call(GDExtensionMethodName.Shutdown, []);

	public static  new void SetBanksPath(string rootOutputPath) => 
		Instance.Call(GDExtensionMethodName.SetBanksPath, [rootOutputPath]);

	public static  new void SetCurrentLanguage(string language) => 
		Instance.Call(GDExtensionMethodName.SetCurrentLanguage, [language]);

	public static  new bool LoadBank(string bankName) => 
		Instance.Call(GDExtensionMethodName.LoadBank, [bankName]).As<bool>();

	public static  new bool LoadBankId(long bankId) => 
		Instance.Call(GDExtensionMethodName.LoadBankId, [bankId]).As<bool>();

	public static  new bool LoadBankAsync(string bankName, Callable cookie) => 
		Instance.Call(GDExtensionMethodName.LoadBankAsync, [bankName, cookie]).As<bool>();

	public static  new bool LoadBankAsyncId(long bankId, Callable cookie) => 
		Instance.Call(GDExtensionMethodName.LoadBankAsyncId, [bankId, cookie]).As<bool>();

	public static  new bool UnloadBank(string bankName) => 
		Instance.Call(GDExtensionMethodName.UnloadBank, [bankName]).As<bool>();

	public static  new bool UnloadBankId(long bankId) => 
		Instance.Call(GDExtensionMethodName.UnloadBankId, [bankId]).As<bool>();

	public static  new bool UnloadBankAsync(string bankName, Callable cookie) => 
		Instance.Call(GDExtensionMethodName.UnloadBankAsync, [bankName, cookie]).As<bool>();

	public static  new bool UnloadBankAsyncId(long bankId, Callable cookie) => 
		Instance.Call(GDExtensionMethodName.UnloadBankAsyncId, [bankId, cookie]).As<bool>();

	public static  new bool RegisterListener(Node gameObject) => 
		Instance.Call(GDExtensionMethodName.RegisterListener, [gameObject]).As<bool>();

	public static  new bool RegisterGameObj(Node gameObject, string name) => 
		Instance.Call(GDExtensionMethodName.RegisterGameObj, [gameObject, name]).As<bool>();

	public static  new bool UnregisterGameObj(Node gameObject) => 
		Instance.Call(GDExtensionMethodName.UnregisterGameObj, [gameObject]).As<bool>();

	public static  new bool AddListener(Node emitter, Node listener) => 
		Instance.Call(GDExtensionMethodName.AddListener, [emitter, listener]).As<bool>();

	public static  new bool RemoveListener(Node emitter, Node listener) => 
		Instance.Call(GDExtensionMethodName.RemoveListener, [emitter, listener]).As<bool>();

	public static  new bool AddDefaultListener(Node gameObject) => 
		Instance.Call(GDExtensionMethodName.AddDefaultListener, [gameObject]).As<bool>();

	public static  new bool RemoveDefaultListener(Node gameObject) => 
		Instance.Call(GDExtensionMethodName.RemoveDefaultListener, [gameObject]).As<bool>();

	public static  new bool SetListeners(Node emitter, Godot.Collections.Array listeners) => 
		Instance.Call(GDExtensionMethodName.SetListeners, [emitter, listeners]).As<bool>();

	public static  new bool SetDistanceProbe(Node listenerGameObject, Node probeGameObject) => 
		Instance.Call(GDExtensionMethodName.SetDistanceProbe, [listenerGameObject, probeGameObject]).As<bool>();

	public static  new bool ResetDistanceProbe(Node listenerGameObject) => 
		Instance.Call(GDExtensionMethodName.ResetDistanceProbe, [listenerGameObject]).As<bool>();

	public static  new void SetRandomSeed(long seed) => 
		Instance.Call(GDExtensionMethodName.SetRandomSeed, [seed]);

	public static  new bool Set3dPosition(Node gameObject, Transform3D transform3d) => 
		Instance.Call(GDExtensionMethodName.Set3dPosition, [gameObject, transform3d]).As<bool>();

	public static  new bool Set2dPosition(Node gameObject, Transform2D transform2d, double zDepth) => 
		Instance.Call(GDExtensionMethodName.Set2dPosition, [gameObject, transform2d, zDepth]).As<bool>();

	public static  new bool SetMultiplePositions3d(Node gameObject, Godot.Collections.Array positions, long numPositions, AkUtils.MultiPositionType multiPositionType) => 
		Instance.Call(GDExtensionMethodName.SetMultiplePositions3d, [gameObject, positions, numPositions, Variant.From(multiPositionType)]).As<bool>();

	public static  new bool SetMultiplePositions2d(Node gameObject, Godot.Collections.Array positions, Godot.Collections.Array zDepths, long numPositions, AkUtils.MultiPositionType multiPositionType) => 
		Instance.Call(GDExtensionMethodName.SetMultiplePositions2d, [gameObject, positions, zDepths, numPositions, Variant.From(multiPositionType)]).As<bool>();

	public static  new bool SetGameObjectRadius(Node gameObject, double outerRadius, double innerRadius) => 
		Instance.Call(GDExtensionMethodName.SetGameObjectRadius, [gameObject, outerRadius, innerRadius]).As<bool>();

	public static  new long PostEvent(string eventName, Node gameObject) => 
		Instance.Call(GDExtensionMethodName.PostEvent, [eventName, gameObject]).As<long>();

	public static  new long PostEventCallback(string eventName, AkUtils.AkCallbackType flags, Node gameObject, Callable cookie) => 
		Instance.Call(GDExtensionMethodName.PostEventCallback, [eventName, Variant.From(flags), gameObject, cookie]).As<long>();

	public static  new long PostEventId(long eventId, Node gameObject) => 
		Instance.Call(GDExtensionMethodName.PostEventId, [eventId, gameObject]).As<long>();

	public static  new long PostEventIdCallback(long eventId, AkUtils.AkCallbackType flags, Node gameObject, Callable cookie) => 
		Instance.Call(GDExtensionMethodName.PostEventIdCallback, [eventId, Variant.From(flags), gameObject, cookie]).As<long>();

	public static  new long PostMidiOnEventId(long eventId, Node gameObject, Godot.Collections.Array midiPosts, bool absoluteOffsets) => 
		Instance.Call(GDExtensionMethodName.PostMidiOnEventId, [eventId, gameObject, midiPosts, absoluteOffsets]).As<long>();

	public static  new void StopEvent(long playingId, long fadeTime, AkUtils.AkCurveInterpolation interpolation) => 
		Instance.Call(GDExtensionMethodName.StopEvent, [playingId, fadeTime, Variant.From(interpolation)]);

	public static  new bool StopMidiOnEventId(long eventId, Node gameObject) => 
		Instance.Call(GDExtensionMethodName.StopMidiOnEventId, [eventId, gameObject]).As<bool>();

	public static  new bool ExecuteActionOnEventId(long eventId, AkUtils.AkActionOnEventType actionType, Node gameObject, long transitionDuration = 0, AkUtils.AkCurveInterpolation fadeCurve = AkUtils.AkCurveInterpolation.Linear, long playingId = 0) => 
		Instance.Call(GDExtensionMethodName.ExecuteActionOnEventId, [eventId, Variant.From(actionType), gameObject, transitionDuration, Variant.From(fadeCurve), playingId]).As<bool>();

	public static  new bool SetSwitch(string switchGroup, string switchValue, Node gameObject) => 
		Instance.Call(GDExtensionMethodName.SetSwitch, [switchGroup, switchValue, gameObject]).As<bool>();

	public static  new bool SetSwitchId(long switchGroupId, long switchValueId, Node gameObject) => 
		Instance.Call(GDExtensionMethodName.SetSwitchId, [switchGroupId, switchValueId, gameObject]).As<bool>();

	public static  new bool SetState(string stateGroup, string stateValue) => 
		Instance.Call(GDExtensionMethodName.SetState, [stateGroup, stateValue]).As<bool>();

	public static  new bool SetStateId(long stateGroupId, long stateValueId) => 
		Instance.Call(GDExtensionMethodName.SetStateId, [stateGroupId, stateValueId]).As<bool>();

	public static  new double GetRtpcValue(string name, Node gameObject) => 
		Instance.Call(GDExtensionMethodName.GetRtpcValue, [name, gameObject]).As<double>();

	public static  new double GetRtpcValueId(long id, Node gameObject) => 
		Instance.Call(GDExtensionMethodName.GetRtpcValueId, [id, gameObject]).As<double>();

	public static  new bool SetRtpcValue(string name, double value, Node gameObject) => 
		Instance.Call(GDExtensionMethodName.SetRtpcValue, [name, value, gameObject]).As<bool>();

	public static  new bool SetRtpcValueId(long id, double value, Node gameObject) => 
		Instance.Call(GDExtensionMethodName.SetRtpcValueId, [id, value, gameObject]).As<bool>();

	public static  new bool PostTrigger(string name, Node gameObject) => 
		Instance.Call(GDExtensionMethodName.PostTrigger, [name, gameObject]).As<bool>();

	public static  new bool PostTriggerId(long id, Node gameObject) => 
		Instance.Call(GDExtensionMethodName.PostTriggerId, [id, gameObject]).As<bool>();

	public static  new long PostExternalSource(string eventName, Node gameObject, string sourceObjectName, string filename, AkUtils.AkCodecId idCodec) => 
		Instance.Call(GDExtensionMethodName.PostExternalSource, [eventName, gameObject, sourceObjectName, filename, Variant.From(idCodec)]).As<long>();

	public static  new long PostExternalSourceId(long eventId, Node gameObject, long sourceObjectId, string filename, AkUtils.AkCodecId idCodec) => 
		Instance.Call(GDExtensionMethodName.PostExternalSourceId, [eventId, gameObject, sourceObjectId, filename, Variant.From(idCodec)]).As<long>();

	public static  new long PostExternalSources(long eventId, Node gameObject, Godot.Collections.Array externalSourceInfo) => 
		Instance.Call(GDExtensionMethodName.PostExternalSources, [eventId, gameObject, externalSourceInfo]).As<long>();

	public static  new long GetSourcePlayPosition(long playingId, bool extrapolate) => 
		Instance.Call(GDExtensionMethodName.GetSourcePlayPosition, [playingId, extrapolate]).As<long>();

	public static  new Godot.Collections.Dictionary GetPlayingSegmentInfo(long playingId, bool extrapolate) => 
		Instance.Call(GDExtensionMethodName.GetPlayingSegmentInfo, [playingId, extrapolate]).As<Godot.Collections.Dictionary>();

	public static  new bool SetGameObjectOutputBusVolume(Node gameObject, Node listener, double fControlValue) => 
		Instance.Call(GDExtensionMethodName.SetGameObjectOutputBusVolume, [gameObject, listener, fControlValue]).As<bool>();

	public static  new bool SetGameObjectAuxSendValues(Node gameObject, Godot.Collections.Array akAuxSendValues, long numSendValues) => 
		Instance.Call(GDExtensionMethodName.SetGameObjectAuxSendValues, [gameObject, akAuxSendValues, numSendValues]).As<bool>();

	public static  new bool SetObjectObstructionAndOcclusion(Node gameObject, Node listener, double calculatedObs, double calculatedOcc) => 
		Instance.Call(GDExtensionMethodName.SetObjectObstructionAndOcclusion, [gameObject, listener, calculatedObs, calculatedOcc]).As<bool>();

	public static  new bool SetGeometry(Godot.Collections.Array vertices, Godot.Collections.Array triangles, WwiseAcousticTexture acousticTexture, double transissionLossValue, Node gameObject, bool enableDiffraction, bool enableDiffractionOnBoundaryEdges) => 
		Instance.Call(GDExtensionMethodName.SetGeometry, [vertices, triangles, acousticTexture, transissionLossValue, gameObject, enableDiffraction, enableDiffractionOnBoundaryEdges]).As<bool>();

	public static  new bool RemoveGeometry(GodotObject gameObject) => 
		Instance.Call(GDExtensionMethodName.RemoveGeometry, [gameObject]).As<bool>();

	public static  new bool SetGeometryInstance(GodotObject associatedGeometry, Transform3D transform, bool useForReflectionAndDiffraction, bool isSolid, bool bypassPortalSubtraction, GodotObject geometryInstance) => 
		Instance.Call(GDExtensionMethodName.SetGeometryInstance, [associatedGeometry, transform, useForReflectionAndDiffraction, isSolid, bypassPortalSubtraction, geometryInstance]).As<bool>();

	public static  new bool RemoveGeometryInstance(GodotObject geometryInstance) => 
		Instance.Call(GDExtensionMethodName.RemoveGeometryInstance, [geometryInstance]).As<bool>();

	public static  new bool RegisterSpatialListener(Node gameObject) => 
		Instance.Call(GDExtensionMethodName.RegisterSpatialListener, [gameObject]).As<bool>();

	public static  new bool SetRoom(Node gameObject, long auxBusId, double reverbLevel, double transmissionLoss, Vector3 frontVector, Vector3 upVector, bool keepRegistered, GodotObject associatedGeometry) => 
		Instance.Call(GDExtensionMethodName.SetRoom, [gameObject, auxBusId, reverbLevel, transmissionLoss, frontVector, upVector, keepRegistered, associatedGeometry]).As<bool>();

	public static  new bool RemoveRoom(Node gameObject) => 
		Instance.Call(GDExtensionMethodName.RemoveRoom, [gameObject]).As<bool>();

	public static  new bool SetPortal(Node gameObject, Transform3D transform, Vector3 extent, Node frontRoom, Node backRoom, bool enabled) => 
		Instance.Call(GDExtensionMethodName.SetPortal, [gameObject, transform, extent, frontRoom, backRoom, enabled]).As<bool>();

	public static  new bool RemovePortal(Node gameObject) => 
		Instance.Call(GDExtensionMethodName.RemovePortal, [gameObject]).As<bool>();

	public static  new bool SetPortalObstructionAndOcclusion(Node portal, double obstructionValue, double occlusionValue) => 
		Instance.Call(GDExtensionMethodName.SetPortalObstructionAndOcclusion, [portal, obstructionValue, occlusionValue]).As<bool>();

	public static  new bool SetGameObjectToPortalObstruction(Node gameObject, Node portal, double obstructionValue) => 
		Instance.Call(GDExtensionMethodName.SetGameObjectToPortalObstruction, [gameObject, portal, obstructionValue]).As<bool>();

	public static  new bool SetPortalToPortalObstruction(Node portal0, Node portal1, double obstructionValue) => 
		Instance.Call(GDExtensionMethodName.SetPortalToPortalObstruction, [portal0, portal1, obstructionValue]).As<bool>();

	public static  new bool SetGameObjectInRoom(Node gameObject, Node room) => 
		Instance.Call(GDExtensionMethodName.SetGameObjectInRoom, [gameObject, room]).As<bool>();

	public static  new bool RemoveGameObjectFromRoom(Node gameObject) => 
		Instance.Call(GDExtensionMethodName.RemoveGameObjectFromRoom, [gameObject]).As<bool>();

	public static  new bool SetEarlyReflectionsAuxSend(Node gameObject, long auxId) => 
		Instance.Call(GDExtensionMethodName.SetEarlyReflectionsAuxSend, [gameObject, auxId]).As<bool>();

	public static  new bool SetEarlyReflectionsVolume(Node gameObject, double volume) => 
		Instance.Call(GDExtensionMethodName.SetEarlyReflectionsVolume, [gameObject, volume]).As<bool>();

	public static  new bool AddOutput(string shareSet, long outputId) => 
		Instance.Call(GDExtensionMethodName.AddOutput, [shareSet, outputId]).As<bool>();

	public static  new bool RemoveOutput(long outputId) => 
		Instance.Call(GDExtensionMethodName.RemoveOutput, [outputId]).As<bool>();

	public static  new bool Suspend(bool renderAnyway) => 
		Instance.Call(GDExtensionMethodName.Suspend, [renderAnyway]).As<bool>();

	public static  new bool WakeupFromSuspend() => 
		Instance.Call(GDExtensionMethodName.WakeupFromSuspend, []).As<bool>();

	public static  new void StopAll(Node gameObject = null) => 
		Instance.Call(GDExtensionMethodName.StopAll, [gameObject]);

	public static  new long GetSampleTick() => 
		Instance.Call(GDExtensionMethodName.GetSampleTick, []).As<long>();

	public static  new long GetIdFromString(string @string) => 
		Instance.Call(GDExtensionMethodName.GetIdFromString, [@string]).As<long>();

	public static  new bool IsInitialized() => 
		Instance.Call(GDExtensionMethodName.IsInitialized, []).As<bool>();

}
