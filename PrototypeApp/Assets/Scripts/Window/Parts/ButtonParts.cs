using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonParts : MonoBehaviour
{
    // ボタンがタップされたときに実行されるイベント
    public UnityEvent tappedEvent = null;

    // ボタンの要素を取得
    [SerializeField] private ButtonEl buttonEl = null;

    // タップ中の画像グループ
    [SerializeField] private GameObject tappingImageGroup = null;

    public void TappingEvent()
    {
        // ボタンの画像を変更
        buttonEl.ShowImages(false, buttonEl.defImageGroup.name);
        buttonEl.ShowImages(true, tappingImageGroup.name);
    }

    public void UnTappingEvent()
    {
        // ボタンの画像を戻す
        buttonEl.ShowImages(false, tappingImageGroup.name);
        buttonEl.ShowImages(true, buttonEl.defImageGroup.name);
    }

    public void TappedEvent()
    {
        tappedEvent.Invoke();
    }
}
