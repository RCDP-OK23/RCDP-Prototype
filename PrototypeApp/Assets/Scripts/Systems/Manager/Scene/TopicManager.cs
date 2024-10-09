using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicManager : Manager
{
    [SerializeField] private GameObject windowHeader;
    [SerializeField] private GameObject windowFooter;
    [SerializeField] private GameObject windowUdonya;
    [SerializeField] private GameObject windowOsakaWC;
    // Start is called before the first frame update
    public override void BaseAwake()
    {
        // Manager�ɐݒ肳��Ă��邷�ׂĂ�Window��������
        Init(new List<GameObject> { windowHeader, windowFooter, windowUdonya, windowOsakaWC });

        // HeaderWindow��\��
        ShowWindow(windowHeader.name);

        // FooterWindow��\��
        ShowWindow(windowFooter.name);

        //UdonWindow��\��
        ShowWindow(windowUdonya.name);

        //OsakaWCWindow��\��
        ShowWindow(windowOsakaWC.name);

    }

    public override void BaseExit()
    {
        Debug.Log("HomeManager Exit");

        // Manager�̏I�����������s
        Destoroy();
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
}
