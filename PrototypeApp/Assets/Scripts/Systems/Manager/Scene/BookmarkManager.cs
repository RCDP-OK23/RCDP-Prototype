using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookmarkManager : Manager
{
    [SerializeField] private GameObject windowHeader;
    [SerializeField] private GameObject windowFooter;
    [SerializeField] private GameObject windowWC;
    [SerializeField] private GameObject windowElevator;
    [SerializeField] private GameObject windowRoom;
 
    // Start is called before the first frame update
    public override void BaseAwake()
    {
        // Managerに設定されているすべてのWindowを初期化
        Init(new List<GameObject> { windowHeader, windowFooter, windowWC, windowElevator, windowRoom });
        // HeaderWindowを表示
        ShowWindow(windowHeader.name);

        // FooterWindowを表示
        ShowWindow(windowFooter.name);

        //WCwindowを表示
        ShowWindow(windowWC.name);

        //Elevatorwindowを表示
        ShowWindow(windowElevator.name);

        //Roomwindowを表示
        ShowWindow(windowRoom.name);


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
        ScrollWindows();
    }

    public override void BaseUpdate()
    {
        // 各ウィンドウの処理を実行
        ExecuteWindows();

        // 各ウィンドウの処理を実行
        ScrollWindows();
    }
}
