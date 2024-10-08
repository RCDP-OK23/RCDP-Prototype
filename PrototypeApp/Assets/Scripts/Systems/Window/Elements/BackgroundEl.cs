using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundEl : Element
{
    public override void Init()
    {
        Debug.Log("Init BackgroundEl [" + ElName + "]");
    }

    public override void Show()
    {
        Debug.Log("Show BackgroundEl [" + ElName + "]");
    }

    public override void Close()
    {
        Debug.Log("Close BackgroundEl [" + ElName + "]");
    }

    public override void Execute()
    {
        Debug.Log("Execute BackgroundEl [" + ElName + "]");
    }

    public override void Move(ref Vector2 vec)
    {
        Debug.Log("Move BackgroundEl [" + ElName + "]");
    }
}
