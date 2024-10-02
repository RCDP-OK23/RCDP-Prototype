using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Param : MonoBehaviour
{
    public enum MSG
    {
        SUCSESS,
        FAIL
    }

    public MSG msg;
    public float left;
    public float right;
}
