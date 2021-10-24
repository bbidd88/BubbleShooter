using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YUIManager : YManger
{
    private YUIRoot Root = null;
    private YUIScene UIScene { get; set; } = null;
    public override void OnAwake()
    {
        GameObject uiRootObj = GameObject.Find("@UIRoot");
        if (uiRootObj == null)
            uiRootObj = new GameObject("@UIRoot");
        Root = uiRootObj.SetComponent<YUIRoot>();
        Object.DontDestroyOnLoad(Root);
    }

    public override void OnStart()
    {
        ChangeUIScene<YUISceneLobby>();
    }

    public void ChangeUIScene<T>(IYUIOpenParam param = default) where T : YUIScene
    {
        System.Type inType = typeof(T);
        if (!Root.Scenes.ContainsKey(inType))
        {
            Debug.LogError("ChangeUIScene : No Form Type : " + inType.Name);
            return;
        }

        if(UIScene)
        {
            if (UIScene.GetType() == inType)
            {
                Debug.LogError("ChangeUIScene : Same Form Type : " + inType.Name);
                return;
            }

            UIScene.OnClose();
            UIScene.gameObject.SetActive(false);
            UIScene = null;
        }

        UIScene = Root.Scenes[inType];
        UIScene.Init();
        UIScene.gameObject.SetActive(true);
        UIScene.OnOpen(param);
    }

}
