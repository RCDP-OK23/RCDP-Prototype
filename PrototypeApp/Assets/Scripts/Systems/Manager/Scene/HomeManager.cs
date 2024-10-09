using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class HomeManager : Manager
{
    [SerializeField] GameObject windowHeader;
    [SerializeField] GameObject windowFooter;

    public override void BaseAwake()
    {
        Debug.Log("HomeManager Awake");

        // Manager�ɐݒ肳��Ă��邷�ׂĂ�Window��������
        Init(new List<GameObject> { windowHeader, windowFooter});

        // HeaderWindow��\��
        ShowWindow(windowHeader.name);

        // FooterWindow��\��
        ShowWindow(windowFooter.name);
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
