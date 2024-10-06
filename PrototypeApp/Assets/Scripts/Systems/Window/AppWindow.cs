using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppWindow : MonoBehaviour
{
    private bool isCreated = false;
    [SerializeField] private string wndName = "";

    private bool isOpening = false;
    public bool IsOpening
    {
        get { return isOpening; }
    }

    [SerializeField] private bool isScroll = true;
    public bool IsScroll
    {
        get { return isScroll; }
    }

    [SerializeField] private bool isPopUp = false;
    public bool IsPopUp
    {
        get { return isPopUp; }
    }

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

    private void GetElements(ref GameObject parent, ref Dictionary<string, Element> diEl)
    {
        Element[] elements = parent.GetComponentsInChildren<Element>();

        for (int i = 0; i < elements.Length; i++)
        {
            diEl.Add(elements[i].name, elements[i]);
        }
    }

    private void ElementsInit(ref Dictionary<string, Element> diEl)
    {
        foreach (KeyValuePair<string, Element> pair in diEl)
        {
            pair.Value.Init();
        }
    }

    public int Init()
    {
        // 各辞書変数を初期化
        diBackgroundEl = new Dictionary<string, Element>();
        diImageEl = new Dictionary<string, Element>();
        diInputBoxEl = new Dictionary<string, Element>();
        diButtonEl = new Dictionary<string, Element>();
        diTextEl = new Dictionary<string, Element>();

        // 各要素を取得
        GetElements(ref backgrounds, ref diBackgroundEl);
        GetElements(ref images, ref diImageEl);
        GetElements(ref inputBoxes, ref diInputBoxEl);
        GetElements(ref buttons, ref diButtonEl);
        GetElements(ref texts, ref diTextEl);

        // 各要素を初期化
        ElementsInit(ref diBackgroundEl);
        ElementsInit(ref diImageEl);
        ElementsInit(ref diInputBoxEl);
        ElementsInit(ref diButtonEl);
        ElementsInit(ref diTextEl);

        return Constants.MSG_SUCSESS;
    }

    private void ElementsShow(ref Dictionary<string, Element> diEl)
    {
        foreach (KeyValuePair<string, Element> pair in diEl)
        {
            pair.Value.Show();
        }
    }

    public int Show()
    {
        // 開いている場合は処理しない
        if (isOpening) return Constants.MSG_FAILED;
        isOpening = true;

        canvas.enabled = true;
        panel.enabled = true;

        // 各要素を表示
        ElementsShow(ref diBackgroundEl);
        ElementsShow(ref diImageEl);
        ElementsShow(ref diInputBoxEl);
        ElementsShow(ref diButtonEl);
        ElementsShow(ref diTextEl);

        return Constants.MSG_SUCSESS;
    }

    private void ElementsClose(ref Dictionary<string, Element> diEl)
    {
        foreach (KeyValuePair<string, Element> pair in diEl)
        {
            pair.Value.Close();
        }
    }

    public int Close()
    {
        // 開いていない場合は処理しない
        if (!isOpening) return Constants.MSG_FAILED;
        isOpening = false;

        canvas.enabled = false;
        panel.enabled = false;

        // 各要素を非表示
        ElementsClose(ref diBackgroundEl);
        ElementsClose(ref diImageEl);
        ElementsClose(ref diInputBoxEl);
        ElementsClose(ref diButtonEl);
        ElementsClose(ref diTextEl);

        return Constants.MSG_SUCSESS;
    }

    private void ElementsExecute(ref Dictionary<string, Element> diEl, ref Params param)
    {
        foreach (KeyValuePair<string, Element> pair in diEl)
        {
            pair.Value.Execute(ref param);
        }
    }

    public void Execute(ref Params param)
    {
        // 開いていない場合は処理しない
        if (!isOpening) return;

        // 各要素を実行
        ElementsExecute(ref diBackgroundEl, ref param);
        ElementsExecute(ref diImageEl, ref param);
        ElementsExecute(ref diInputBoxEl, ref param);
        ElementsExecute(ref diButtonEl, ref param);
        ElementsExecute(ref diTextEl, ref param);
    }

    private void ElementsMove(ref Dictionary<string, Element> diEl, ref Vector2 vec, ref Params param)
    {
        foreach (KeyValuePair<string, Element> pair in diEl)
        {
            pair.Value.Move(ref vec, ref param);
        }
    }

    public void Move(ref Vector2 moveVec,ref Params param)
    {
        if (!isOpening) return;

        // 各要素を移動
        ElementsMove(ref diBackgroundEl, ref moveVec, ref param);
        ElementsMove(ref diImageEl, ref moveVec, ref param);
        ElementsMove(ref diInputBoxEl, ref moveVec, ref param);
        ElementsMove(ref diButtonEl, ref moveVec, ref param);
        ElementsMove(ref diTextEl, ref moveVec, ref param);
    }
}
