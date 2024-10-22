using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class InputBoxEl : Element
{
    private bool isTapping = false;
    [SerializeField] private InputField inputField = null;

    private string inputText = "";

    public override void Init()
    {
        // 継承元クラスの初期化処理を実行
        BaseInit();

        inputField.gameObject.SetActive(false);
    }

    public override void Show()
    {
        // 画像の表示処理
        ShowImages(true, defImageGroup.name);

        // InputFieldの表示処理
        inputField.gameObject.SetActive(true);
    }

    public override void Close()
    {
        // 画像の非表示処理
        ShowAllImages(false);

        // InputFieldの非表示処理
        inputField.gameObject.SetActive(false);
    }

    public void InputText()
    {
        //テキストにinputFieldの内容を反映
        inputText = inputField.text;
        Debug.Log(inputText);
    }

    public override void Execute()
    {
#if UNITY_EDITOR
        
#else
        
#endif
    }
}