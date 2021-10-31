using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPrefabHolder : MonoBehaviour
{
    
    //[SerializeField] private EPrefabType PrefabType = EPrefabType.Invalid;
    [SerializeField] private List<YPrefab> Prefabs = new List<YPrefab>();

    // 활성화된 인스턴스
    private Dictionary<int, YPrefab> ActiveInstances = new Dictionary<int, YPrefab>();
    // 인스턴스 풀
    private Dictionary<int, Queue<YPrefab>> InstancePools = new Dictionary<int, Queue<YPrefab>>();
    private Dictionary<int, YPrefab> PrefabDic = new Dictionary<int, YPrefab>();

    private void Awake()
    {
        foreach(YPrefab prefab in Prefabs)
        {
            PrefabDic.Add(prefab.GetInstanceID(), prefab);
            InstancePools.Add(prefab.GetInstanceID(), new Queue<YPrefab>());
        }
    }

    public YPrefab GetClone(int PrefabId)
    {
        if (!InstancePools.ContainsKey(PrefabId))
        {
            Debug.LogErrorFormat("Can not find Prefab from Pools (PrefabId : {0})", PrefabId);
            return null;
        }
        YPrefab clone = null;
        if (InstancePools[PrefabId].Count > 0)
        {
            clone = InstancePools[PrefabId].Dequeue();
        }
        else
        {
            if (!PrefabDic.TryGetValue(PrefabId, out YPrefab prefab))
            {
                Debug.LogErrorFormat("Can not find Prefab from Prefabs (PrefabId : {0})", PrefabId);
                return null;
            }

            
            clone = GameObject.Instantiate<YPrefab>(prefab);
            clone.name = prefab.name;
            System.Reflection.PropertyInfo propertyInfo = clone.GetType().GetProperty("ID", System.Reflection.BindingFlags.SetProperty);
            propertyInfo.SetValue(clone, PrefabId);
            //Pools[Id].Enqueue(clone);
        }

        ActiveInstances.Add(clone.GetInstanceID(), clone);

        return clone;
    }

    public void ReleaseInstance(YPrefab Instance)
    {
        ReleaseInstance(Instance?.GetInstanceID() ?? 0);
    }

    public void ReleaseInstance(int InstanceId)
    {
        if (ActiveInstances.ContainsKey(InstanceId))
        {
            Debug.LogErrorFormat("Can not find Active from Actives (InstanceId : {0})", InstanceId);
            return;
        }
        InstancePools[ActiveInstances[InstanceId].ID].Enqueue(ActiveInstances[InstanceId]);
        ActiveInstances.Remove(InstanceId);
    }
}
