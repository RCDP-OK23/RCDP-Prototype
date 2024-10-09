using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BackgroundEl : Element
{
    public override void Init()
    {
        Debug.Log("Init BackgroundEl [" + name + "]");
    }

    public override void Show()
    {
        Debug.Log("Show BackgroundEl [" + name + "]");
    }

    public override void Close()
    {
        Debug.Log("Close BackgroundEl [" + name + "]");
    }

    public override void Execute()
    {
        Debug.Log("Execute BackgroundEl [" + name + "]");
    }

    public override void Move(ref Vector2 vec)
    {
        Debug.Log("Move BackgroundEl [" + name + "]");
    }
}
