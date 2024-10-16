using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseManager : MonoBehaviour
{
    // シリアル通信スクリプトを持つのゲームオブジェクトを設定
    [SerializeField] private SensorDevice sensorDevice;

    // Managerクラスを継承したクラスを持つゲームオブジェクトを設定
    [SerializeField] private GameObject managerObject;
    private Manager manager;

    /* 
     * 今回のプロトタイプ版では以下の関数でのみUnityのAwake、Start、Update関数を使用する
     * 他のスクリプトでこれらを使うことは推奨はしないが、作業時間上許容する場合もある
     */
    private void Awake()
    {
        Debug.Log("BaseManager Awake");

        // FPSを設定
        SetFps();

        // メッセージ処理のためのパラメータを初期化
        Params.Init();

        // シリアル通信スクリプトを持つゲームオブジェクトを生成
        sensorDevice.Create();

        // Managerクラスを継承したクラスを持つゲームオブジェクトからManagerクラスを取得
        manager = managerObject.GetComponent<Manager>();

        // Managerクラスを継承したクラスのAwake関数を実行
        manager.BaseAwake();
    }

    void Start()
    {
        Debug.Log("BaseManager Start");

        // メッセージ処理のためのパラメータを初期化
        Params.Init();

        // FPSを設定
        SetFps();

        // Managerクラスを継承したクラスのStart関数を実行
        manager.BaseStart();
    }

    void Update()
    {
        // メッセージを処理
        ProsessParam();

        // メッセージ処理のためのパラメータを初期化
        Params.Init();

        // Managerクラスを継承したクラスのUpdate関数を実行
        manager.BaseUpdate();
    }

    // シーンが切り替わる際に呼び出される関数
    private void Exit()
    {
        Debug.Log("BaseManager Exit");

        // Managerクラスを継承したクラスのExit関数を実行
        manager.BaseExit();
    }

    // 各シーンで必ず一度実行する。FPSの設定を行う。
    public void SetFps()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = Constants.SPECIFIED_FPS;
    }

    // Param処理
    public void ProsessParam()
    {
        switch (Params.msg)
        {
            case Constants.MSG_CHANGE_SCENE:
                ChangeScene();
                break;
            default:
                break;
        }
    }

    // Paramに格納されたシーン名を元に、シーンを変更する。
    public void ChangeScene()
    {
        if (
            Params.strPar == Constants.SCENE_HOME ||
            Params.strPar == Constants.SCENE_SEARCH ||
            Params.strPar == Constants.SCENE_TOPIC ||
            Params.strPar == Constants.SCENE_MYPAGE ||
            Params.strPar == Constants.SCENE_BOOKMARK
        ){
            Exit();

            // シーン名を取得（例としてParams.sceneNameを使用）
            string sceneName = Params.strPar;

            // シーンを読み込む
            SceneManager.LoadScene(sceneName);
        }
    }
}
