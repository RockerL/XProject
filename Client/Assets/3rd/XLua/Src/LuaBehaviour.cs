using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System;

[System.Serializable]
public class Injection
{
    public string name;
    public GameObject value;
}

[LuaCallCSharp]
public class LuaBehaviour : MonoBehaviour
{
    public string luaScript;
    public Injection[] injections;

    internal static LuaEnv luaEnv = new LuaEnv(); //all lua behaviour shared one luaenv only!
    internal static bool isAddLoader = false;
    internal static float lastGCTime = 0;
    internal const float GCInterval = 1;//1 second 

    private Action luaStart;
    private Action luaUpdate;
    private Action luaOnDestroy;

    private LuaTable scriptEnv;

    public static LuaEnv GetEnv()
    {
        CheckAddLoader();

        return luaEnv;
    }

    static void CheckAddLoader()
    {
        if (isAddLoader)
            return;

        luaEnv.AddBuildin("rapidjson", XLua.LuaDLL.Lua.LoadRapidJson);
        luaEnv.AddBuildin("pb", XLua.LuaDLL.Lua.LoadPB);

        luaEnv.AddLoader((ref string fileName) =>
        {
            return U3DUtility.ResManager.Singleton.GetLuaBytes(fileName);
        });

        isAddLoader = true;
    }

    void Awake()
    {
        CheckAddLoader();

        scriptEnv = luaEnv.NewTable();

        LuaTable meta = luaEnv.NewTable();
        meta.Set("__index", luaEnv.Global);
        scriptEnv.SetMetaTable(meta);
        meta.Dispose();

        scriptEnv.Set("self", this);
        foreach (var injection in injections)
        {
            scriptEnv.Set(injection.name, injection.value);
        }

        if (!string.IsNullOrEmpty(luaScript))
        {
            byte[] buff = U3DUtility.ResManager.Singleton.GetLuaBytes(luaScript);
            luaEnv.DoString(buff, "LuaBehaviour", scriptEnv);
        }

        Action luaAwake = scriptEnv.Get<Action>("awake");
        scriptEnv.Get("start", out luaStart);
        scriptEnv.Get("update", out luaUpdate);
        scriptEnv.Get("ondestroy", out luaOnDestroy);

        if (luaAwake != null)
        {
            luaAwake();
        }
    }

    // Use this for initialization
    void Start()
    {
        if (luaStart != null)
        {
            luaStart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (luaUpdate != null)
        {
            luaUpdate();
        }
        if (Time.time - LuaBehaviour.lastGCTime > GCInterval)
        {
            luaEnv.Tick();
            LuaBehaviour.lastGCTime = Time.time;
        }
    }

    void OnDestroy()
    {
        if (luaOnDestroy != null)
        {
            luaOnDestroy();
        }
        luaOnDestroy = null;
        luaUpdate = null;
        luaStart = null;
        scriptEnv.Dispose();
        injections = null;
    }
}
