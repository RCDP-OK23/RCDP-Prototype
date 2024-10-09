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

        IsShow = true;
    }

    public override void Close()
    {
        Debug.Log("Close ButtonEl [" + name + "]");

        IsShow = false;
    }

    public override void Execute()
    {
        if (IsTapped())
        {
            Debug.Log("Tapped ButtonEl [" + name + "]");
        }
    }
}
