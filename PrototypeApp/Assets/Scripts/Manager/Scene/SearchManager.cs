using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchManager : Manager
{
    [SerializeField] private GameObject windowHeader;
    [SerializeField] private GameObject windowFooter;
    [SerializeField] private GameObject windowSearchBox;
    [SerializeField] private GameObject windowSearchHistory;

    [SerializeField] private float historyScrollBottom;
    public override void BaseAwake()
    {
        Debug.Log("SearchManagerAwake");

        // Managerに設定されているすべてのWindowを初期化
        Init(new List<GameObject> { windowHeader, windowFooter, windowSearchBox, windowSearchHistory });

        // HeaderWindowを表示
        ShowWindow(windowHeader.name);

        // FooterWindowを表示
        ShowWindow(windowFooter.name);

        // SearchBoxWindowを表示
        ShowWindow(windowSearchBox.name);

        //SearchHistoryを表示
        ShowWindow(windowSearchHistory.name);
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
        if (windowSearchHistory.GetComponent<AppWindow>().IsOpening)
        {
            ScrollWindows(historyScrollBottom);
        }
    }

    public override void BaseUpdate()
    {
        // 各ウィンドウの処理を実行
        ExecuteWindows();

        // 各ウィンドウの処理を実行
        ScrollWindows();
    }
}
