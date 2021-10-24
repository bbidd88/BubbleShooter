using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IYUIOpenParam
{
}


public class YUIScene : YUIWidget
{
    // 재활용을 할것인가?
    public virtual void Init() { }
    public virtual void OnOpen(IYUIOpenParam param) { }
    public virtual void OnClose() { }

}
