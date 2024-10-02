using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Manager : MonoBehaviour
{
    abstract public void UserAwake();
    abstract public void UserStart();
    abstract public void UserUpdate();
    abstract public void UserExit();
}
