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
        // �p�����N���X�̏��������������s
        BaseInit();

        inputField.gameObject.SetActive(false);
    }

    public override void Show()
    {
        // �摜�̕\������
        ShowImages(true, defImageGroup.name);

        // InputField�̕\������
        inputField.gameObject.SetActive(true);
    }

    public override void Close()
    {
        // �摜�̔�\������
        ShowAllImages(false);

        // InputField�̔�\������
        inputField.gameObject.SetActive(false);
    }

    public void InputText()
    {
        //�e�L�X�g��inputField�̓��e�𔽉f
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