using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowNotif : MonoBehaviour
{
    public void EventCloseNotif()
    {
        GetComponent<AppWindow>().Close();
    }

    public void EventBell()
    {
        GetComponent<AppWindow>().Close();
        Params.popUpWindowDone = true;
    }
}
