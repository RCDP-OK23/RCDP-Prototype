using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : Manager
{
    public override void BaseAwake()
    {
        Debug.Log("HomeManager Awake");

        // Manager�ɐݒ肳��Ă��邷�ׂĂ�Window��������
        Init();

        // HeaderWindow��\��
        ShowWindow(Constants.WND_HEADER);

        // FooterWindow��\��
        ShowWindow(Constants.WND_FOOTER);
    }

    public override void BaseStart()
    {
        Debug.Log("HomeManager Start");

        // �e�E�B���h�E�̏��������s
        ExecuteWindows();

        // �X�N���[������Ă���ꍇ�A�E�B���h�E���ړ�
        ScrollWindows();
    }

    public override void BaseUpdate()
    {
        // �e�E�B���h�E�̏��������s
        ExecuteWindows();

        // �e�E�B���h�E�̏��������s
        ScrollWindows();
    }

    public override void BaseExit()
    {
        Debug.Log("HomeManager Exit");

        // Manager�̏I�����������s
        Destoroy();
    }
}
