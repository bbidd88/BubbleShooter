using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPrefabHolder : MonoBehaviour
{
    [SerializeField] private EPrefabType PrefabType = EPrefabType.Invalid;
    [SerializeField] private List<YPrefab> Prefabs = new List<YPrefab>();
    
}
