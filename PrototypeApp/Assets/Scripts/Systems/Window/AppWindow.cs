using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppWindow : MonoBehaviour
{
    private bool isCreated = false;
    [SerializeField] private string wndName = "";

    private bool isOpening = false;
    [SerializeField] private bool isScroll = true;
    [SerializeField] private bool isPopUp = false;

    [SerializeField] private Canvas canvas = null;
    [SerializeField] private Image panel = null;

    [SerializeField] private GameObject backgrounds = null;
    [SerializeField] private GameObject images = null;
    [SerializeField] private GameObject inputBoxes = null;
    [SerializeField] private GameObject buttons = null;
    [SerializeField] private GameObject texts = null;

    private Dictionary<string, Element> diBackgroundEl;
    private Dictionary<string, Element> diImageEl;
    private Dictionary<string, Element> diInputBoxEl;
    private Dictionary<string, Element> diButtonEl;
    private Dictionary<string, Element> diTextEl;

    public void Init()
    {
        Debug.Log("AppWindow Init");
    }

    public void Show()
    {

    }

    public void Close()
    {

    }

    public void Execute(ref Params param)
    {

    }
}
