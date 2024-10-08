using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : Manager
{
    public override void BaseAwake()
    {
        Debug.Log("HomeManager Awake");

        // Managerに設定されているすべてのWindowを初期化
        Init();

        // HeaderWindowを表示
        ShowWindow(Constants.WND_HEADER);

        // FooterWindowを表示
        ShowWindow(Constants.WND_FOOTER);
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
