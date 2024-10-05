using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Element : MonoBehaviour
{
    [SerializeField] private string elName = "";
    [SerializeField] private string type = "";

    abstract public void Init();
    abstract public void Execute(ref Params param);
}
