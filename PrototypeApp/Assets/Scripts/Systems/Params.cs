using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Params : MonoBehaviour
{
    [HideInInspector] public static int msg = Constants.MSG_NULL;
    [HideInInspector] public static float floPar = 0;
    [HideInInspector] public static string strPar = "";

    public void Init()
    {
        msg = Constants.MSG_NULL;
        floPar = 0;
        strPar = "";
    }
}
