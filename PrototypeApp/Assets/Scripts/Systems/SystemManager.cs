using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    // Manager関数の引数の参照元変数。SystemManagerにデータを渡すために使用。
    public static Param param;

    // アプリのFPSを設定。アプリのFPSは必ずこの値になるようにする。
    readonly int SPECIFIED_FPS = 60;

    // シーンの名前を要素に持つ変数
    [SerializeField] private List<string> SCENE_NAMES;

    // 各シーンでのManagerクラスを継承したクラスを持つGameObjectを設定。
    [SerializeField] private Manager manager;

    /* 今回のプロトタイプ版では以下の関数でのみUnityのAwake、Start、Update関数を使用する。
     * 他のスクリプトでこれらを使うことは推奨しないけど、無しではない
     */
    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // シーンが切り替わる際に呼び出される関数
    private void Exit()
    {

    }

    // 各シーンで必ず一度実行する。FPSの設定を行う。
    public Param.MSG SetFps()
    {
        return Param.MSG.SUCSESS;
    }

    // paramに格納されたシーン名を元に、シーンを変更する。
    public Param.MSG ChangeScene()
    {
        return Param.MSG.SUCSESS;
    }
}
