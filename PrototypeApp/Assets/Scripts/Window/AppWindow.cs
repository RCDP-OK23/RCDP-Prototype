using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppWindow : MonoBehaviour
{
    private bool isCreated = false;
    public bool IsCreated
        { get { return isCreated; } }

    private bool isOpening = false;
    public bool IsOpening
        { get { return isOpening; } }

    [SerializeField] private bool isScroll = true;
    public bool IsScroll
        { get { return isScroll; } }

    [SerializeField] private bool isPopUp = false;
    public bool IsPopUp
        { get { return isPopUp; } }

    [SerializeField] private Canvas canvas = null;
    [SerializeField] private Image background = null;

    [SerializeField] private GameObject images = null;
    [SerializeField] private GameObject inputBoxes = null;
    [SerializeField] private GameObject buttons = null;
    [SerializeField] private GameObject texts = null;

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
        Debug.Log("Window Init [" + name + "]");

        canvas.enabled = false;
        background.enabled = false;

        // �e�����ϐ���������
        diImageEl = new Dictionary<string, Element>();
        diInputBoxEl = new Dictionary<string, Element>();
        diButtonEl = new Dictionary<string, Element>();
        diTextEl = new Dictionary<string, Element>();

        // �e�v�f���擾
        GetElements(ref images, ref diImageEl);
        GetElements(ref inputBoxes, ref diInputBoxEl);
        GetElements(ref buttons, ref diButtonEl);
        GetElements(ref texts, ref diTextEl);

        // �e�v�f��������
        ElementsInit(ref diImageEl);
        ElementsInit(ref diInputBoxEl);
        ElementsInit(ref diButtonEl);
        ElementsInit(ref diTextEl);

        return Constants.MSG_SUCCESS;
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
        // �J���Ă���ꍇ�͏������Ȃ�
        if (isOpening) return Constants.MSG_FAILED;
        isOpening = true;

        Debug.Log("Window Show [" + name + "]");

        canvas.enabled = true;
        background.enabled = true;

        // �e�v�f��\��
        ElementsShow(ref diImageEl);
        ElementsShow(ref diInputBoxEl);
        ElementsShow(ref diButtonEl);
        ElementsShow(ref diTextEl);

        return Constants.MSG_SUCCESS;
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
        // �J���Ă��Ȃ��ꍇ�͏������Ȃ�
        if (!isOpening) return Constants.MSG_FAILED;
        isOpening = false;

        Debug.Log("Window Close [" + name + "]");

        canvas.enabled = false;
        background.enabled = false;

        // �e�v�f���\��
        ElementsClose(ref diImageEl);
        ElementsClose(ref diInputBoxEl);
        ElementsClose(ref diButtonEl);
        ElementsClose(ref diTextEl);

        return Constants.MSG_SUCCESS;
    }

    private void ElementsExecute(ref Dictionary<string, Element> diEl)
    {
        foreach (KeyValuePair<string, Element> pair in diEl)
        {
            pair.Value.Execute();
        }
    }

    public void Execute()
    {
        // �J���Ă��Ȃ��ꍇ�͏������Ȃ�
        if (!isOpening) return;

        // �e�v�f�����s
        ElementsExecute(ref diImageEl);
        ElementsExecute(ref diInputBoxEl);
        ElementsExecute(ref diButtonEl);
        ElementsExecute(ref diTextEl);
    }

    private void ElementsMove(ref Dictionary<string, Element> diEl, ref Vector2 vec)
    {
        foreach (KeyValuePair<string, Element> pair in diEl)
        {
            pair.Value.Move(ref vec);
        }
    }

    public void Move(ref Vector2 moveVec)
    {
        if (!isOpening) return;

        // �e�v�f���ړ�
        ElementsMove(ref diImageEl, ref moveVec);
        ElementsMove(ref diInputBoxEl, ref moveVec);
        ElementsMove(ref diButtonEl, ref moveVec);
        ElementsMove(ref diTextEl, ref moveVec);
    }
}
