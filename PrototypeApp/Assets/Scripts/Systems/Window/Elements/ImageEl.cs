using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ImageEl : Element
{
    public override void Init()
    {
        Debug.Log("Init ImageEl [" + name + "]");
    }

    public override void Show()
    {
        Debug.Log("Show ImageEl [" + name + "]");
    }

    public override void Close()
    {
        Debug.Log("Close ImageEl [" + name + "]");
    }

    public override void Execute()
    {
        Debug.Log("Execute ImageEl [" + name + "]");
    }
}

