using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YGameObjectManager : YManager
{
    private YPrefabHolder PrefabHolder = null;
    public override void OnAwake()
    {
        
    }


    public void OnInitInstance(YGame InGame)
    {
        if (!InGame)
        {
            Debug.LogAssertion("InGame == null");
            return;
        }


        GameObject prefab = Resources.Load<GameObject>("Prefabs/GameObject/@PrefabHolder");;
        if(!prefab)
        {
            Debug.LogAssertion("prefab == null");
            return;
        }
        GameObject clone = GameObject.Instantiate(prefab);
        if(!clone)
        {
            Debug.LogAssertion("clone == null");
            return;
        }
        PrefabHolder = clone.GetComponent<YPrefabHolder>();
        if(!PrefabHolder)
        {
            Debug.LogAssertion("PrefabHolder == null");
        }

        PrefabHolder.transform.SetParent(InGame.transform);
        PrefabHolder.name = prefab.name;
    }


    public override void OnStart()
    {
    }


}
