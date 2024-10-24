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
        // Managerに設定されているすべてのWindowを初期化
        Init(new List<GameObject> { windowHeader, windowFooter, windowNotif, windowWC, windowElevator, windowClass });

        // HeaderWindowを表示
        ShowWindow(windowHeader.name);

        // FooterWindowを表示
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

        // Managerの終了処理を実行
        Destoroy();
    }

    public override void BaseStart()
    {
        Debug.Log("HomeManager Start");

        // 各ウィンドウの処理を実行
        ExecuteWindows();

        // スクロールされている場合、ウィンドウを移動
        ScrollWindows(historyScrollBottom);
    }

    public override void BaseUpdate()
    {
        // 各ウィンドウの処理を実行
        ExecuteWindows();

        // 各ウィンドウの処理を実行
        ScrollWindows(historyScrollBottom);
    }
}
