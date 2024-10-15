using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI;

public class TextEl : Element
{
    [SerializeField] public Text defText;
    [SerializeField] private GameObject texts;
    private Dictionary<string, Text> diTexts;

    private bool isTapping = false;

    public UnityEvent tappedEvent = null;
    public UnityEvent tappingEvent = null;
    public UnityEvent unTappingEvent = null;

    public override void Init()
    {
        // �p�����N���X�̏��������������s
        BaseInit();

        // �e�L�X�g�̏���������
        List<GameObject> textList = GetAllChildren(texts);

        diTexts = new Dictionary<string, Text>();
        for (int i = 0; i < textList.Count; i++)
        {
            textList[i].GetComponent<Text>().enabled = false;
            if (!diTexts.TryAdd(textList[i].name, textList[i].GetComponent<Text>()))
            {
                Debug.LogError("Failed to add " + textList[i].name + " to diTexts.");
            }
        }
    }

    public void ShowText(bool val, string name)
    {
        if (diTexts.ContainsKey(name))
        {
            diTexts[name].enabled = val;
        }
    }

    private void ShowAllTexts(bool val)
    {
        foreach (KeyValuePair<string, Text> pair in diTexts)
        {
            pair.Value.enabled = val;
        }
    }

    public override void Show()
    {
        // �摜�̕\������
        ShowImages(true, defImageGroup.name);

        // �e�L�X�g�̕\������
        ShowText(true, defText.name);
    }

    public override void Close()
    {
        // �摜�̔�\������
        ShowAllImages(false);

        // �e�L�X�g�̔�\������
        ShowAllTexts(false);
    }

    public override void Execute()
    {
        if (IsTapping() && tappingEvent != null)
        {
            isTapping = true;
            tappingEvent.Invoke();
        }
        else if (!IsTapping() && isTapping)
        {
            isTapping = false;
            unTappingEvent.Invoke();
        }

        if (IsTapped() && tappedEvent != null) tappedEvent.Invoke();
    }
}
