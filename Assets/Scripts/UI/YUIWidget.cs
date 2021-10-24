using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YUIWidget : MonoBehaviour
{
    private void Awake()
    {
        BindEvent();
    }

    protected virtual void BindEvent() { }
    
}
