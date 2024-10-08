using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEl : Element
{
    public override void Init()
    {
        Debug.Log("Init ButtonEl [" + ElName + "]");
    }

    public override void Show()
    {
        Debug.Log("Show ButtonEl [" + ElName + "]");
    }

    public override void Close()
    {
        Debug.Log("Close ButtonEl [" + ElName + "]");
    }

    public override void Execute()
    {
        Debug.Log("Execute ButtonEl [" + ElName + "]");
    }

    public override void Move(ref Vector2 vec)
    {
        Debug.Log("Move ButtonEl [" + ElName + "]");
    }
}
