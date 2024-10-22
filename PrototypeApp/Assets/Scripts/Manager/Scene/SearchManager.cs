using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchManager : Manager
{
    [SerializeField] private GameObject windowNotif;
    [SerializeField] private GameObject windowHeader;
    [SerializeField] private GameObject windowFooter;
    [SerializeField] private GameObject windowSearchBox;
    [SerializeField] private GameObject windowSearchHistory;
    [SerializeField] private GameObject windowBackground;

    [SerializeField] private float historyScrollBottom;
    public override void BaseAwake()
    {
        Debug.Log("SearchManagerAwake");

        // Manager�ɐݒ肳��Ă��邷�ׂĂ�Window��������
        Init(new List<GameObject> 
        { 
            windowHeader, windowFooter, windowNotif, 
            windowSearchBox, windowSearchHistory, windowBackground 
        });

        // HeaderWindow��\��
        ShowWindow(windowHeader.name);

        // FooterWindow��\��
        ShowWindow(windowFooter.name);

        // SearchBoxWindow��\��
        ShowWindow(windowSearchBox.name);

        //SearchHistory��\��
        ShowWindow(windowSearchHistory.name);

        // BackgroundWindow��\��
        ShowWindow(windowBackground.name);
    }

    public override void BaseExit()
    {
        // Manager�̏I�����������s
        Destoroy();
    }

    public override void BaseStart()
    {
        // �e�E�B���h�E�̏��������s
        ExecuteWindows();

        // �X�N���[������Ă���ꍇ�A�E�B���h�E���ړ�
        if (windowSearchHistory.GetComponent<AppWindow>().IsOpening)
        {
            ScrollWindows(historyScrollBottom);
        }
    }

    public override void BaseUpdate()
    {
        // �e�E�B���h�E�̏��������s
        ExecuteWindows();

        // �X�N���[������Ă���ꍇ�A�E�B���h�E���ړ�
        if (windowSearchHistory.GetComponent<AppWindow>().IsOpening)
        {
            ScrollWindows(historyScrollBottom);
        }
    }
}
