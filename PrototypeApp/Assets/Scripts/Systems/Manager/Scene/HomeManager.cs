using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class HomeManager : Manager
{
    [SerializeField] private GameObject windowHeader;
    [SerializeField] private GameObject windowFooter;

    public override void BaseAwake()
    {
        Debug.Log("HomeManager Awake");

        // Managerに設定されているすべてのWindowを初期化
        Init(new List<GameObject> { windowHeader });

        // HeaderWindowを表示
        ShowWindow(windowHeader.name);

        //// FooterWindowを表示
        //ShowWindow(windowFooter.name);
    }

    public override void BaseStart()
    {
        Debug.Log("HomeManager Start");

        // 各ウィンドウの処理を実行
        ExecuteWindows();

        // スクロールされている場合、ウィンドウを移動
        ScrollWindows();
    }

    public override void BaseUpdate()
    {
        // 各ウィンドウの処理を実行
        ExecuteWindows();

        // 各ウィンドウの処理を実行
        ScrollWindows();
    }

    public override void BaseExit()
    {
        Debug.Log("HomeManager Exit");

        // Managerの終了処理を実行
        Destoroy();
    }
}
