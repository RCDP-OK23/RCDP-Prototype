using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI;

public class TextEl : Element
{
    [SerializeField] public Text defText;
    [SerializeField] private GameObject texts;

    private bool isTapping = false;

    public UnityEvent<string> tappedEvent = null;
    public UnityEvent<string> tappingEvent = null;
    public UnityEvent<string> unTappingEvent = null;

    public override void Init()
    {
        // 継承元クラスの初期化処理を実行
        BaseInit();

        // テキストの初期化処理
        List<GameObject> textList = GetAllChildren(texts);

        for (int i = 0; i < textList.Count; i++)
        {
            textList[i].GetComponent<Text>().enabled = false;
            if (!diTexts.TryAdd(textList[i].name, textList[i].GetComponent<Text>()))
            {
                Debug.LogError("Failed to add " + textList[i].name + " to diTexts.");
            }
        }
    }

    public override void Show()
    {
        // 画像の表示処理
        ShowImages(true, defImageGroup.name);

        // テキストの表示処理
        ShowText(true, defText.name);
    }

    public override void Close()
    {
        // 画像の非表示処理
        ShowAllImages(false);

        // テキストの非表示処理
        ShowAllTexts(false);
    }

    public override void Execute()
    {
#if UNITY_EDITOR
        if (IsHover() && tappingEvent != null)
        {
            isTapping = true;
            tappingEvent.Invoke("");
        }
        else if (!IsHover() && isTapping)
        {
            isTapping = false;
            unTappingEvent.Invoke("");
        }

        if (IsClick() && tappedEvent != null) tappedEvent.Invoke("");
#else
        
        if (IsTapping() && tappingEvent != null)
        {
            isTapping = true;
            tappingEvent.Invoke("");
        }
        else if (!IsTapping() && isTapping)
        {
            isTapping = false;
            unTappingEvent.Invoke("");
        }

        if (IsTapped() && tappedEvent != null) tappedEvent.Invoke("");
#endif
    }
}
