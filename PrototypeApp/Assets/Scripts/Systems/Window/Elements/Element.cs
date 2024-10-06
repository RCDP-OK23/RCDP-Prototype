using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Element : MonoBehaviour
{
    [SerializeField] private string elName = "";
    [SerializeField] private string type = "";

    abstract public void Init();
    abstract public void Show();
    abstract public void Close();
    abstract public void Execute(ref Params param);
    abstract public void Move(ref Vector2 vec, ref Params param);
}
