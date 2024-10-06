using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : Manager
{
    public override void BaseAwake(ref Params param)
    {
        Debug.Log("HomeManager Awake");

        // Manager�ɐݒ肳��Ă��邷�ׂĂ�Window��������
        Init(ref param);

        // HeaderWindow��\��
        ShowWindow(Constants.WND_HEADER, ref param);

        // FooterWindow��\��
        ShowWindow(Constants.WND_FOOTER, ref param);
    }

    public override void BaseStart(ref Params param)
    {
        Debug.Log("HomeManager Start");

        // �e�E�B���h�E�̏��������s
        ExecuteWindows(ref param);

        // �X�N���[������Ă���ꍇ�A�E�B���h�E���ړ�
        ScrollWindows(ref param);
    }

    public override void BaseUpdate(ref Params param)
    {
        // �e�E�B���h�E�̏��������s
        ExecuteWindows(ref param);

        // �e�E�B���h�E�̏��������s
        ScrollWindows(ref param);
    }

    public override void BaseExit(ref Params param)
    {
        Debug.Log("HomeManager Exit");

        Destoroy(ref param);
    }
}
