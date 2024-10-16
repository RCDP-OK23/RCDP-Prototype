using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class HomeManager : Manager
{
    [SerializeField] private GameObject windowHeader;
    [SerializeField] private GameObject windowFooter;
    [SerializeField] private GameObject windowMap;
    [SerializeField] private GameObject windowApp;

    public override void BaseAwake()
    {
        Debug.Log("HomeManager Awake");

        // Managerに設定されているすべてのWindowを初期化
        Init(new List<GameObject> { windowHeader, windowFooter, windowMap, windowApp});

        // HeaderWindowを表示
        ShowWindow(windowHeader.name);

        // FooterWindowを表示
        ShowWindow(windowFooter.name);

        // MapWindowを表示
        ShowWindow(windowMap.name);

        //AppWindowを表示
        ShowWindow(windowApp.name);
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

    public void FooterHome()
    {
        Debug.Log("Tap Footer Home");
    }
}
