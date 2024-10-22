using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputBoxParts : MonoBehaviour
{
    // テキストがタップされたときに実行されるイベント
    public UnityEvent tappedEvent = null;

    // テキストの要素を取得
    [SerializeField] private InputBoxEl inputBoxEl = null;

    // タップ中の画像、テキストグループ
    [SerializeField] private GameObject typingImageGroup = null;

    private bool isTyping = false;

    public void TappedEvent()
    {
        inputBoxEl.ShowImages(false, inputBoxEl.defImageGroup.name);
        inputBoxEl.ShowImages(true, typingImageGroup.name);

        tappedEvent.Invoke();
    }
}
