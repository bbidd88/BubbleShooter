using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YUIRoot : MonoBehaviour
{
    [SerializeField] private Canvas CanvasOverlay = null;

    // 일단 임시로 캐싱 해놓고 쓴다.. 나중에는 구조 변화가 필요
    public Dictionary<Type, YUIScene> Scenes { get; private set; } = new Dictionary<Type, YUIScene>();
    private void Awake()
    {
        foreach (YUIScene scene in CanvasOverlay.GetComponentsInChildren<YUIScene>(true))
        {
            if (scene)
            {
                scene.gameObject.SetActive(false);
                Scenes.Add(scene.GetType(), scene);
            }
        }
    }

}
