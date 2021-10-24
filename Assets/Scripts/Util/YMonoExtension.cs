using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class YMonoExtension 
{
    public static T SetComponent<T>(this GameObject gameObject) where T : MonoBehaviour
    {
        T component = gameObject.GetComponent<T>();
        if(!component)
            gameObject.AddComponent<T>();

        return component;
    }
}
