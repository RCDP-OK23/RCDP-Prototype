using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchManager : Manager
{
    [SerializeField] private GameObject windowNotif;
    [SerializeField] private GameObject windowHeader;
    [SerializeField] private GameObject windowFooter;
    [SerializeField] private GameObject windowSearchBox;
    [SerializeField] private GameObject windowSearchHistory;
    [SerializeField] private GameObject windowBackground;

    [SerializeField] private float historyScrollBottom;

    private string inputText = "";
    [SerializeField] private InputField inputField = null;

    private int suggestCount = 0;
    [SerializeField] private int maxSuggestCount = 3;

    private List<SuggestParts> suggests;
    [SerializeField] private SuggestParts iputOkClass;
    [SerializeField] private SuggestParts iputOkElevator;
    [SerializeField] private SuggestParts oosakaStationWC;

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

        suggests = new List<SuggestParts> { iputOkClass, iputOkElevator, oosakaStationWC };

        iputOkClass.CloseSuggest();
        iputOkElevator.CloseSuggest();
        oosakaStationWC.CloseSuggest();
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

    private void CloseAllSuggest()
    {
        for (int i = 0; i < suggests.Count; i++)
        {
            suggests[i].CloseSuggest();
        }

        suggestCount = 0;
    }

    public void EventInputValChange()
    {
        inputText = inputField.text.ToLower();

        if (inputText == "")
        {
            for (int i = 0; i < suggests.Count; i++)
            {
                suggests[i].CloseSuggest();
            }

            suggestCount = 0;
            return;
        }

        List<int> showingSuggestI = new List<int>();
        for (int i = 0; i < suggests.Count; i++)
        {
            if (suggests[i].accountObj.GetComponent<Account>().SearchResult(inputText))
            {
                showingSuggestI.Add(i);
                suggests[i].ShowSuggest(ref suggestCount, maxSuggestCount);
            }
            else
            {
                CloseAllSuggest();
                for (int j = 0; j < showingSuggestI.Count; j++)
                {
                    suggests[showingSuggestI[j]].ShowSuggest(ref suggestCount, maxSuggestCount);
                }
            }
        }
    }
}
