using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IYUIOpenParam
{
}


public class YUIScene : YUIWidget
{
    // ��Ȱ���� �Ұ��ΰ�?
    public virtual void Init() { }
    public virtual void OnOpen(IYUIOpenParam param) { }
    public virtual void OnClose() { }

}
