using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI;

public class InputBoxEl : Element
{
    public override void Init()
    {
        // �p�����N���X�̏��������������s
        BaseInit();
    }

    public override void Show()
    {
        // �摜�̕\������
        ShowImages(true, defImageGroup.name);
    }

    public override void Close()
    {
        // �摜�̔�\������
        ShowAllImages(false);
    }

    public override void Execute()
    {

    }
}