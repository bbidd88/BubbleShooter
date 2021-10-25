using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YUISceneMainGame : YUIScene
{
    [SerializeField] private Button GoToLobby = null;

    protected override void BindEvent()
    {
        base.BindEvent();
        GoToLobby.onClick.AddListener(OnClickGoToLobby);
    }
    private void OnClickGoToLobby()
    {
        YGame.Get<YUIManager>().ChangeUIScene<YUISceneLobby>();
    }
}
