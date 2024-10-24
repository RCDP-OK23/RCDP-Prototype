using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailManager : Manager
{
    [SerializeField] private GameObject windowHeader;
    [SerializeField] private GameObject windowFooter;
    [SerializeField] private GameObject windowNotif;
    [SerializeField] private GameObject windowWC;
    [SerializeField] private GameObject windowElevator;
    [SerializeField] private GameObject windowClass;

    [SerializeField] private BaseManager baseMg;

    [SerializeField] private GameObject accoutIputOk;
    [SerializeField] private GameObject accoutOosakaStation;

    [SerializeField] private GameObject deviceClass;
    [SerializeField] private GameObject deviceElevator;

    [SerializeField] private float historyScrollBottom;

    public override void BaseAwake()
    {
        // Manager�ɐݒ肳��Ă��邷�ׂĂ�Window��������
        Init(new List<GameObject> { windowHeader, windowFooter, windowNotif, windowWC, windowElevator, windowClass });

        // HeaderWindow��\��
        ShowWindow(windowHeader.name);

        // FooterWindow��\��
        ShowWindow(windowFooter.name);

        if (baseMg.accounts[(int)Params.floPar].name == accoutIputOk.name)
        {
            for (int i = 0; i < accoutIputOk.gameObject.GetComponent<Account>().devices.Count; i++)
            {
                if (Params.strPar2 == deviceClass.name)
                {
                    ShowWindow(windowClass.name);
                }
                else if (Params.strPar2 == deviceElevator.name)
                {
                    ShowWindow(windowElevator.name);
                }
            }
        }
        else if (baseMg.accounts[(int)Params.floPar].name == accoutOosakaStation.name)
        {
            ShowWindow(windowWC.name);
        }

        Params.goingDetail = false;
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
        ScrollWindows(historyScrollBottom);
    }

    public override void BaseUpdate()
    {
        // �e�E�B���h�E�̏��������s
        ExecuteWindows();

        // �e�E�B���h�E�̏��������s
        ScrollWindows(historyScrollBottom);
    }
}
