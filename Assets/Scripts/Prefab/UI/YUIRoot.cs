using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YUIRoot : MonoBehaviour
{
    [SerializeField] private Canvas CanvasOverlay = null;

    // �ϴ� �ӽ÷� ĳ�� �س��� ����.. ���߿��� ���� ��ȭ�� �ʿ�
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
