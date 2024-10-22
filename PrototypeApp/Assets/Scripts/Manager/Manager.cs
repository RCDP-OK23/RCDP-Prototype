using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;


abstract public class Manager : MonoBehaviour
{
    // シーンで表示するウィンドウを格納
    private List<AppWindow> windows = null;

    // ウィンドウの名前をキーにし、リストのインデックスを取得するための変数
    private Dictionary<string, AppWindow> windowNameToIndex = null;

    // ウィンドウのスクロールによる移動量を指定。
    private float editorScrollSpeed = 400;
    private float appScrollSpeed = 1;

    // 初期位置からの移動量を保存。
    private Vector2 movedVec;

    // BaseAwake関数で最初に必ず実行する。Managerクラスの初期化を行う
    protected void Init(List<GameObject> sourceWindows)
    {
        Debug.Log("Manager Init");

        // ウィンドウを格納する変数の作成
        windows = new List<AppWindow>();

        // ウィンドウの名前をキーにし、リストのインデックスを取得するための変数の作成
        windowNameToIndex = new Dictionary<string, AppWindow>();
        for (int i = 0; i < sourceWindows.Count; i++)
        {
            // ウィンドウをリストに追加し、ウィンドウの名前をキーにし、リストのインデックスを取得するための変数に追加
            windows.Add(sourceWindows[i].GetComponent<AppWindow>());
            windowNameToIndex.Add(windows[i].name, windows[i]);

            // ウィンドウの初期化
            windows[i].Init();
        }

        movedVec = new Vector2(0, 0);
    }

    // BaseExit関数で最後に必ず実行する。Managerクラスの終了処理を行う
    protected void Destoroy()
    {
        Debug.Log("Manager Destoroy");
    }

    // 引数にウィンドウの名前を指定し、そのウィンドウを表示する
    public void ShowWindow(string wndName)
    {
        windows[windows.IndexOf(windowNameToIndex[wndName])].Show();
    }

    // 引数にウィンドウの名前を指定し、そのウィンドウを非表示にする
    public void CloseWindow(string wndName)
    {
        // ウィンドウを非表示にした場合、スクロール量をリセットする
        if
        (
            windows[windows.IndexOf(windowNameToIndex[wndName])].IsScroll &&
            !windows[windows.IndexOf(windowNameToIndex[wndName])].IsPopUp
        )
        {
            windows[windows.IndexOf(windowNameToIndex[wndName])].Move(ref movedVec);
        }

        windows[windows.IndexOf(windowNameToIndex[wndName])].Close();
    }

    // すべての開いているウィンドウのイベントが実行の必要があるなら実行する
    // BaseUpdate関数で実行する
    protected void ExecuteWindows()
    {
        for (int i = 0; i < windows.Count; i++)
        {
            if (windows[i].IsPopUp)
            {
                windows[i].Execute();
                if (Params.popUpWindowDone) return;
            }
        }


        for (int i = 0; i < windows.Count; i++)
        {
            if (!windows[i].IsPopUp) windows[i].Execute();
        }
    }

    // スクロールすることが検知された場合、ウィンドウをスクロールに合わせて移動させる
    // BaseUpdate関数でExecuteWindows関数のあとに実行する
    protected void ScrollWindows()
    {
#if UNITY_EDITOR
        // エディタ用のスクロール処理

        // スクロールによるウィンドウの移動量を取得
        Vector2 moveVec = new Vector2(0, 0);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            moveVec.y = scroll * editorScrollSpeed;
            movedVec -= moveVec;

            // スクロールする必要があるウィンドウの場合、ウィンドウをスクロールに合わせて移動させる
            for (int i = 0; i < windows.Count; i++)
            {
                if (windows[i].IsScroll && !windows[i].IsPopUp) windows[i].Move(ref moveVec);
            }
        }
#else
        // Android用のスクロール処理
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 moveVec = touch.deltaPosition * appScrollSpeed * Time.deltaTime;
                movedVec -= moveVec;

                for (int i = 0; i < windows.Count; i++)
                {
                    if (windows[i].IsScroll && !windows[i].IsPopUp) windows[i].Move(ref moveVec);
                }
            }
        }
#endif
    }

    // スクロールすることが検知された場合、ウィンドウをスクロールに合わせて移動させる。
    // BaseUpdate関数でExecuteWindows関数のあとに実行する。
    // スクロールにより移動できる最低Y値を引数に指定する。
    protected void ScrollWindows(float bottomY)
    {
#if UNITY_EDITOR
        // エディタ用のスクロール処理

        // スクロールによるウィンドウの移動量を取得
        Vector2 moveVec = new Vector2(0, 0);

        float scroll = -Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            moveVec.y = scroll * editorScrollSpeed;

            movedVec -= moveVec;
            if (movedVec.y < bottomY)
            {
                movedVec += moveVec;
                return;
            }
            else if (movedVec.y > 0)
            {
                movedVec += moveVec;
                return;
            }

            // スクロールする必要があるウィンドウの場合、ウィンドウをスクロールに合わせて移動させる
            for (int i = 0; i < windows.Count; i++)
            {
                if (windows[i].IsScroll && !windows[i].IsPopUp)
                {
                    windows[i].Move(ref moveVec);
                }
            }
        }
#else
        // Android用のスクロール処理
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 moveVec = touch.deltaPosition * appScrollSpeed * Time.deltaTime;

                movedVec -= moveVec;
                if (movedVec.y < bottomY)
                {
                    movedVec += moveVec;
                    return;
                }
                else if (movedVec.y > 0)
                {
                    movedVec += moveVec;
                    return;
                }

                for (int i = 0; i < windows.Count; i++)
                {
                    if (windows[i].IsScroll && !windows[i].IsPopUp) windows[i].Move(ref moveVec);
                }
            }
        }
#endif
    }

    // UnityのAwake関数の代わりに使用する関数
    abstract public void BaseAwake();

    // UnityのStart関数の代わりに使用する関数
    abstract public void BaseStart();

    // UnityのUpdate関数の代わりに使用する関数
    abstract public void BaseUpdate();

    // シーンが切り替わる際に呼び出される関数
    abstract public void BaseExit();
}
