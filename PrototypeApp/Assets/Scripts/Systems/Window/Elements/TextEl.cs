using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEl : Element
{
    public override void Init()
    {
        Debug.Log("Init TextEl [" + ElName + "]");
    }

    public override void Show()
    {
        Debug.Log("Show TextEl [" + ElName + "]");
    }

    public override void Close()
    {
        Debug.Log("Close TextEl [" + ElName + "]");
    }

    public override void Execute()
    {
        Debug.Log("Execute TextEl [" + ElName + "]");
    }

    public override void Move(ref Vector2 vec)
    {
        Debug.Log("Move TextEl [" + ElName + "]");
    }
}
