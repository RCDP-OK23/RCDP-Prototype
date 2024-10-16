using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowHeader : MonoBehaviour
{
    [SerializeField] private Manager sceneManager;
    [SerializeField] private GameObject windowNotif;

    public void EventOpenNotif()
    {
        sceneManager.ShowWindow(windowNotif.name);
    }

    public void EventCloseNotif()
    {
        sceneManager.CloseWindow(windowNotif.name);
    }

    public void EventGoMyPage()
    {
        Params.msg = Constants.MSG_CHANGE_SCENE;
        Params.strPar = Constants.SCENE_MYPAGE;
    }

}
