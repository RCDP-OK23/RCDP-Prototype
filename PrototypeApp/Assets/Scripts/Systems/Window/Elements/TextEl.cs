using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TextEl : Element
{
    public override void Init()
    {
        Debug.Log("Init TextEl [" + name + "]");
    }

    public override void Show()
    {
        Debug.Log("Show TextEl [" + name + "]");
    }

    public override void Close()
    {
        Debug.Log("Close TextEl [" + name + "]");
    }

    public override void Execute()
    {
        Debug.Log("Execute TextEl [" + name + "]");
    }

    public override void Move(ref Vector2 vec)
    {
        Debug.Log("Move TextEl [" + name + "]");
    }
}
