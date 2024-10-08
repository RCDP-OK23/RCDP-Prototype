using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageEl : Element
{
    public override void Init()
    {
        Debug.Log("Init ImageEl [" + ElName + "]");
    }

    public override void Show()
    {
        Debug.Log("Show ImageEl [" + ElName + "]");
    }

    public override void Close()
    {
        Debug.Log("Close ImageEl [" + ElName + "]");
    }

    public override void Execute()
    {
        Debug.Log("Execute ImageEl [" + ElName + "]");
    }

    public override void Move(ref Vector2 vec)
    {
        Debug.Log("Move ImageEl [" + ElName + "]");
    }
}

