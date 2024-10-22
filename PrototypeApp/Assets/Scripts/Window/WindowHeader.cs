using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowHeader : MonoBehaviour
{
    [SerializeField] private Manager sceneManager;
    [SerializeField] private GameObject windowNotif;

    private bool isNotifOpening = false;

    public void EventNotifAction()
    {
        if (windowNotif.GetComponent<AppWindow>().IsOpening)
        {
            sceneManager.CloseWindow(windowNotif.name);
            isNotifOpening = false;
        }
        else if (!windowNotif.GetComponent<AppWindow>().IsOpening)
        {
            sceneManager.ShowWindow(windowNotif.name);
            isNotifOpening = true;
        }
        else if (!windowNotif.GetComponent<AppWindow>().IsOpening && isNotifOpening)
        {
            sceneManager.ShowWindow(windowNotif.name);
        }
    }

    public void EventGoMyPage()
    {
        Params.msg = Constants.MSG_CHANGE_SCENE;
        Params.strPar = Constants.SCENE_MYPAGE;
    }

}
