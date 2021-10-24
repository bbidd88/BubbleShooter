using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class YGame : MonoBehaviour
{
    static private bool IsAwake = false;
    static private bool GetIsAwake() { return IsAwake; }

    static private Dictionary<System.Type, YManger> Managers = null;
    

    private void Awake()
    {
        if (Managers == null)
        {
            Managers = new Dictionary<System.Type, YManger>();
        }

        var types = System.AppDomain.CurrentDomain.GetAllDerivedTypes(typeof(YManger));

        foreach (System.Type type in types)
        {
            YManger manager = (YManger)System.Activator.CreateInstance(type);
            manager.OnAwake();
            Managers.Add(type, manager);
        }

        IsAwake = true;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        foreach(YManger manger in Managers.Values)
        {
            manger.OnStart();
        }
        
    }

    public static T Get<T>()
    {
        if (!GetIsAwake())
        {
            GameObject gameInstanceObj = GameObject.Find("@GameInstance");
            if (gameInstanceObj == null)
                gameInstanceObj = new GameObject("@GameInstance");

            gameInstanceObj.AddComponent<YGame>();

            //new YGame().InitManager();
        }

        if (Managers.ContainsKey(typeof(T)))
            return (T)System.Convert.ChangeType(Managers[typeof(T)], typeof(T));

        return default(T);
    }

    // 업데이트 따로 돌려야하나?
}
