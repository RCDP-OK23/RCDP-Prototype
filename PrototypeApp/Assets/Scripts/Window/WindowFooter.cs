using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowFooter : MonoBehaviour
{
    public void EventGoHome()
    {
        Params.msg = Constants.MSG_CHANGE_SCENE;
        Params.strPar = Constants.SCENE_HOME;
    }

    public void EventGoSearch()
    {
        Params.msg = Constants.MSG_CHANGE_SCENE;
        Params.strPar = Constants.SCENE_SEARCH;
    }

    public void EventGoBookmark()
    {
        Params.msg = Constants.MSG_CHANGE_SCENE;
        Params.strPar = Constants.SCENE_BOOKMARK;
    }

    public void EventGoTopic()
    {
        Params.msg = Constants.MSG_CHANGE_SCENE;
        Params.strPar = Constants.SCENE_TOPIC;
    }
}
