using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBoxEl : Element
{
    public override void Init()
    {
        Debug.Log("Init InputBoxEl [" + name + "]");
    }

    public override void Show()
    {
        Debug.Log("Show InputBoxEl [" + name + "]");
    }

    public override void Close()
    {
        Debug.Log("Close InputBoxEl [" + name + "]");
    }

    public override void Execute()
    {
        Debug.Log("Execute InputBoxEl [" + name + "]");
    }

    public override void Move(ref Vector2 vec)
    {
        Debug.Log("Move InputBoxEl [" + name + "]");
    }
}