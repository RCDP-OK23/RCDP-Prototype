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

        // Manager�ɐݒ肳��Ă��邷�ׂĂ�Window��������
        Init(new List<GameObject> 
        { 
            windowHeader, windowFooter, windowNotif, 
            windowSearchBox, windowSearchHistory, windowBackground 
        });

        // HeaderWindow��\��
        ShowWindow(windowHeader.name);

        // FooterWindow��\��
        ShowWindow(windowFooter.name);

        // SearchBoxWindow��\��
        ShowWindow(windowSearchBox.name);

        //SearchHistory��\��
        ShowWindow(windowSearchHistory.name);

        // BackgroundWindow��\��
        ShowWindow(windowBackground.name);

        suggests = new List<SuggestParts> { iputOkClass, iputOkElevator, oosakaStationWC };

        iputOkClass.CloseSuggest();
        iputOkElevator.CloseSuggest();
        oosakaStationWC.CloseSuggest();
    }

    public override void BaseExit()
    {
        // Manager�̏I�����������s
        Destoroy();
    }

    public override void BaseStart()
    {
        // �e�E�B���h�E�̏��������s
        ExecuteWindows();

        // �X�N���[������Ă���ꍇ�A�E�B���h�E���ړ�
        if (windowSearchHistory.GetComponent<AppWindow>().IsOpening)
        {
            ScrollWindows(historyScrollBottom);
        }
    }

    public override void BaseUpdate()
    {
        // �e�E�B���h�E�̏��������s
        ExecuteWindows();

        // �X�N���[������Ă���ꍇ�A�E�B���h�E���ړ�
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
