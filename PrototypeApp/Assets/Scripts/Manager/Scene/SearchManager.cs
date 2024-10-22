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

        // Managerに設定されているすべてのWindowを初期化
        Init(new List<GameObject> 
        { 
            windowHeader, windowFooter, windowNotif, 
            windowSearchBox, windowSearchHistory, windowBackground 
        });

        // HeaderWindowを表示
        ShowWindow(windowHeader.name);

        // FooterWindowを表示
        ShowWindow(windowFooter.name);

        // SearchBoxWindowを表示
        ShowWindow(windowSearchBox.name);

        //SearchHistoryを表示
        ShowWindow(windowSearchHistory.name);

        // BackgroundWindowを表示
        ShowWindow(windowBackground.name);
    }

    public override void BaseExit()
    {
        // Managerの終了処理を実行
        Destoroy();
    }

    public override void BaseStart()
    {
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

        // スクロールされている場合、ウィンドウを移動
        if (windowSearchHistory.GetComponent<AppWindow>().IsOpening)
        {
            ScrollWindows(historyScrollBottom);
        }
    }
}
