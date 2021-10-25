using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YUIWidget : YPrefab
{
    private void Awake()
    {
        BindEvent();
    }

    protected virtual void BindEvent() { }
    
}
