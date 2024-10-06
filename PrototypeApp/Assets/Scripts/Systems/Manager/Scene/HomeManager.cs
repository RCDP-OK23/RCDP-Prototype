using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : Manager
{
    public override void BaseAwake(ref Params param)
    {
        Debug.Log("HomeManager Awake");

        // Managerに設定されているすべてのWindowを初期化
        Init(ref param);

        // HeaderWindowを表示
        ShowWindow(Constants.WND_HEADER, ref param);

        // FooterWindowを表示
        ShowWindow(Constants.WND_FOOTER, ref param);
    }

    public override void BaseStart(ref Params param)
    {
        Debug.Log("HomeManager Start");

        // 各ウィンドウの処理を実行
        ExecuteWindows(ref param);

        // スクロールされている場合、ウィンドウを移動
        ScrollWindows(ref param);
    }

    public override void BaseUpdate(ref Params param)
    {
        // 各ウィンドウの処理を実行
        ExecuteWindows(ref param);

        // 各ウィンドウの処理を実行
        ScrollWindows(ref param);
    }

    public override void BaseExit(ref Params param)
    {
        Debug.Log("HomeManager Exit");

        Destoroy(ref param);
    }
}
