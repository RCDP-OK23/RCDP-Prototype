using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonEl : Element
{
    private bool isTapping = false;

    public UnityEvent tappedEvent = null;
    public UnityEvent tappingEvent = null;
    public UnityEvent unTappingEvent = null;

    public override void Init()
    {
        // 継承元クラスの初期化処理を実行
        BaseInit();
    }

    public override void Show()
    {
        // 画像の表示処理
        ShowImages(true, defImageGroup.name);
    }

    public override void Close()
    {
        // 画像の非表示処理
        ShowAllImages(false);
    }

    public override void Execute()
    {
#if UNITY_EDITOR
        if (IsHover() && tappingEvent != null)
        {
            isTapping = true;
            tappingEvent.Invoke();
        }
        else if (!IsHover() && isTapping)
        {
            isTapping = false;
            unTappingEvent.Invoke();
        }

        if (IsClick() && tappedEvent != null) tappedEvent.Invoke();
#else
        
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
#endif
    }
}
