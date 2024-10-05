using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : Manager
{
    public override void BaseAwake(ref Params param)
    {
        Init();

        Debug.Log("HomeManager Awake");
    }

    public override void BaseStart(ref Params param)
    {
        Debug.Log("HomeManager Start");
    }

    public override void BaseUpdate(ref Params param)
    {
        ExecuteWindows(ref param);
        ScrollWindows(ref param);
    }

    public override void BaseExit(ref Params param)
    {
        Debug.Log("HomeManager Exit");

        Destoroy();
    }
}
