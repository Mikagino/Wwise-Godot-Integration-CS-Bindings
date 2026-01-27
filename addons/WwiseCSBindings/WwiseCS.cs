using System.Collections.Generic;
using Godot;
using Godot.Collections;

public partial class WwiseCS : GodotObject
{
    private static GodotObject Wwise => Engine.GetSingleton("Wwise");

    static public bool AddDefaultListener(Node gameObject)
    {
        return (bool)Wwise.Call("add_default_listener", gameObject);
    }

    static public bool AddListener(Node emitter, Node listener)
    {
        return (bool)Wwise.Call("add_listener", emitter, listener);
    }

    static public bool AddOutput(string shareSet, int outputId)
    {
        return (bool)Wwise.Call("add_output", shareSet, outputId);
    }

    // TODO
    // static public bool ExecuteActionOnEventId(int event_id, AkUtils.AkActionOnEventType action_type, Node game_object, int transition_duration = 0, AkUtils.AkCurveInterpolation fade_curve = 4, int playing_id = 0)
    // {
    //     return (bool)Wwise.Call("execute_action_on_event_id", shareSet, outputId);
    // }

    static public int GetIdFromString(string _string)
    {
        return (int)Wwise.Call("get_id_from_string", _string);
    }

    static public Dictionary GetPlayingSegmentInfo(int playingId, bool extrapolate)
    {
        return (Dictionary)Wwise.Call("get_playing_segment_info", playingId, extrapolate);
    }

    static public float GetRTPCValue(string name, Node gameObject)
    {
        return (float)Wwise.Call("get_rtpc_value", name, gameObject);
    }
    

    static public bool LoadBank(string bankName)
    {
        return (bool)Wwise.Call("load_bank", bankName);
    }

    static public bool LoadBankId(int bankId)
    {
        return (bool)Wwise.Call("load_bank_id", bankId);
    }

    static public bool LoadBankAsync(string bankName,  Callable cookie)
    {
        return (bool)Wwise.Call("load_bank_async", bankName, cookie);
    }

    static public bool LoadBankAsyncId(int bankId, Callable cookie)
    {
        return (bool)Wwise.Call("load_bank_async_id", bankId, cookie);
    }

    static public bool UnloadBank(string bankName)
    {
        return (bool)Wwise.Call("unload_bank", bankName);
    }

    static public bool UnloadBankId(int bankId)
    {
        return (bool)Wwise.Call("unload_bank_id", bankId);
    }

    static public bool UnloadBankAsync(string bankName, Callable cookie)
    {
        return (bool)Wwise.Call("unload_bank_async", bankName, cookie);
    }

    static public bool UnloadBankAsyncId(int bankId, Callable cookie)
    {
        return (bool)Wwise.Call("unload_bank_async_id", bankId, cookie);
    }

    static public bool RegisterListener(Node gameObject)
    {
        return (bool)Wwise.Call("unload_bank_async_id", gameObject);
    }

    static public bool RegisterGameObj(Node gameObject, string name)
    {
        return (bool)Wwise.Call("register_game_obj", gameObject, name);
    }

    static public bool UnregisterGameObj(Node gameObject)
    {
        return (bool)Wwise.Call("unregister_game_obj", gameObject);
    }

    static public bool SetListeners(Node emitter, Node gameObject)
    {
        return (bool)Wwise.Call("set_listeners", emitter, gameObject);
    }

    static public void SetRandomSeed(int seed)
    {
        Wwise.Call("set_listeners", seed);
    }




    static public int PostEvent(string eventName, Node gameObject)
    {
        if(Wwise == null) GD.PrintErr("No event posted! Waiting for Wwise...");
        return (int)Wwise.Call("post_event", eventName, gameObject);
    }

    static public int PostEventid(int eventid, Node gameObject)
    {
        if(Wwise == null) GD.PrintErr("No event posted! Waiting for Wwise...");
        return (int)Wwise.Call("post_event_id", eventid, gameObject);
    }

    static public void StopEvent(int playingid, int fadeTimeMillis)
    {
        Wwise.Call("stop_event", playingid, fadeTimeMillis, 6);
    }

    static public void SetRTPCValue(string rtpcName, float value, Node gameObject)
    {
        Wwise.Call("set_rtpc_value", rtpcName, value, gameObject);
    }

    static public void StopAll(Node gameObject = null)
    {
        Wwise.Call("stop_all", gameObject);
    }

    static public bool PostTrigger(string name, Node gameObject)
    {
        return (bool)Wwise.Call("post_trigger", name, gameObject);
    }
}