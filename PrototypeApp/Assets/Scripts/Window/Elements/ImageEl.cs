using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI;

public class ImageEl : Element
{
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

    }
}

