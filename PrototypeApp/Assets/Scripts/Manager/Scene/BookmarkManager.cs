using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookmarkManager : Manager
{
    [SerializeField] private GameObject windowHeader;
    [SerializeField] private GameObject windowFooter;
    [SerializeField] private GameObject windowWC;
    [SerializeField] private GameObject windowElevator;
    [SerializeField] private GameObject windowRoom;
 
    // Start is called before the first frame update
    public override void BaseAwake()
    {
        // Manager�ɐݒ肳��Ă��邷�ׂĂ�Window��������
        Init(new List<GameObject> { windowHeader, windowFooter, windowWC, windowElevator, windowRoom });
        // HeaderWindow��\��
        ShowWindow(windowHeader.name);

        // FooterWindow��\��
        ShowWindow(windowFooter.name);

        //WCwindow��\��
        ShowWindow(windowWC.name);

        //Elevatorwindow��\��
        ShowWindow(windowElevator.name);

        //Roomwindow��\��
        ShowWindow(windowRoom.name);


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
