using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YUISceneLobby : YUIScene
{
    [SerializeField] private Button GameStart = null;

    protected override void BindEvent()
    {
        base.BindEvent();
        GameStart.onClick.AddListener(OnClickGameStart);
    }
    private void OnClickGameStart()
    {
        YGame.Get<YUIManager>().ChangeUIScene<YUISceneMainGame>();
    }
}
