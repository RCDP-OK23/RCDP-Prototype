using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextParts : MonoBehaviour
{
    // テキストがタップされたときに実行されるイベント
    public UnityEvent<string> tappedEvent = null;

    // テキストの要素を取得
    [SerializeField] private TextEl textEl = null;

    // タップ中の画像、テキストグループ
    [SerializeField] private GameObject tappingImageGroup = null;
    [SerializeField] private GameObject tappingText = null;

    public void TappingEvent()
    {
        textEl.ShowImages(false, textEl.defImageGroup.name);
        textEl.ShowText(false, textEl.defText.name);

        textEl.ShowImages(true, tappingImageGroup.name);
        textEl.ShowText(true, tappingText.name);
    }

    public void UnTappingEvent()
    {
        textEl.ShowImages(false, tappingImageGroup.name);
        textEl.ShowText(false, tappingText.name);

        textEl.ShowImages(true, textEl.defImageGroup.name);
        textEl.ShowText(true, textEl.defText.name);
    }

    public void TappedEvent()
    {
        tappedEvent.Invoke("");
    }
}
