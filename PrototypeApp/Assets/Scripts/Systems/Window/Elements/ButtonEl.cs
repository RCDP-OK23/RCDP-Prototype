using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ButtonEl : Element
{
    public override void Init()
    {
        Debug.Log("Init ButtonEl [" + name + "]");
    }

    public override void Show()
    {
        Debug.Log("Show ButtonEl [" + name + "]");
    }

    public override void Close()
    {
        Debug.Log("Close ButtonEl [" + name + "]");
    }

    public override void Execute()
    {
        Debug.Log("Execute ButtonEl [" + name + "]");
    }

    public override void Move(ref Vector2 vec)
    {
        Debug.Log("Move ButtonEl [" + name + "]");
    }
}
