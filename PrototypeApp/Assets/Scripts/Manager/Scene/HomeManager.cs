using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class HomeManager : Manager
{
    [SerializeField] private GameObject windowHeader;
    [SerializeField] private GameObject windowFooter;
    [SerializeField] private GameObject windowMap;
    [SerializeField] private GameObject windowPop;
    [SerializeField] private GameObject windowNotif;
    

    public override void BaseAwake()
    {
        Debug.Log("HomeManager Awake");

        // Managerに設定されているすべてのWindowを初期化
        Init(new List<GameObject> { windowHeader, windowFooter, windowMap, windowPop, windowNotif });

        // HeaderWindowを表示
        ShowWindow(windowHeader.name);

        // FooterWindowを表示
        ShowWindow(windowFooter.name);

        // MapWindowを表示
        ShowWindow(windowMap.name);
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

        Params.msg = Constants.MSG_CHANGE_SCENE;
        Params.strPar = Constants.SCENE_MYPAGE;
    }

    public void MapPoint()
    {
        Debug.Log("Tap MapPoint");

        //ポップアップウィンドウを表示
        ShowWindow(windowPop.name);
    }

    public void CloseStep()
    {
        Debug.Log("Tap CloseStep");

        //ポップアップウィンドウを非表示
        CloseWindow(windowPop.name);
    }

    public void EventMypage()
    {
        Debug.Log("Tap Mypage");
        //Mypageに移動
        Params.msg = Constants.MSG_CHANGE_SCENE;
        Params.strPar = Constants.SCENE_MYPAGE;
    }


}

