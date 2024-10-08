using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Element : MonoBehaviour
{
    [SerializeField] private string elName = "";
    public string ElName { get { return elName; } }

    [SerializeField] private string type = "";
    public string Type { get { return type; } }

    abstract public void Init();
    abstract public void Show();
    abstract public void Close();
    abstract public void Execute();
    abstract public void Move(ref Vector2 vec);
}
