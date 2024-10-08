using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;


abstract public class Manager : MonoBehaviour
{
    // シーンで表示するウィンドウを格納
    private List<AppWindow> windows = null;

    // ウィンドウの名前をキーにし、リストのインデックスを取得するための変数
    private Dictionary<string, AppWindow> windowNameToIndex = null;

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
    }

    // BaseExit関数で最後に必ず実行する。Managerクラスの終了処理を行う
    protected void Destoroy()
    {
        Debug.Log("Manager Destoroy");
    }

    // 引数にウィンドウの名前を指定し、そのウィンドウを表示する
    protected void ShowWindow(string wndName)
    {
        windows[windows.IndexOf(windowNameToIndex[wndName])].Show();
    }

    // 引数にウィンドウの名前を指定し、そのウィンドウを非表示にする
    protected void CloseWindow(string wndName)
    {
        windows[windows.IndexOf(windowNameToIndex[wndName])].Close();
    }

    // すべての開いているウィンドウのイベントが実行の必要があるなら実行する
    // BaseUpdate関数で実行する
    protected void ExecuteWindows()
    {
        for (int i = 0; i < windows.Count; i++)
        {
            windows[i].Execute();
        }
    }

    // スクロールすることが検知された場合、ウィンドウをスクロールに合わせて移動させる
    // BaseUpdate関数でExecuteWindows関数のあとに実行する
    protected void ScrollWindows()
    {
        // スクロールによるウィンドウの移動量を取得
        Vector2 moveVec = new Vector2(0, 0);

        // スクロールする必要があるウィンドウの場合、ウィンドウをスクロールに合わせて移動させる
        for (int i = 0; i < windows.Count; i++)
        {
            if (windows[i].IsScroll) windows[i].Move(ref moveVec);
        }
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
