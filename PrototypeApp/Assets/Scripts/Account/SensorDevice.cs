using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.Networking;

public class SensorData
{
    // {"2024-10-16 10:56:19":3}
    private List<int> year;
    private List<int> month;
    private List<int> day;
    private List<int> hour;
    private List<int> min;

    private List<int> amount;
}

public class SensorDevice : MonoBehaviour
{
    // プロトタイプ版においてNULLかどうか
    [SerializeField] private bool isNull = false;

    // 対象のサイト
    [SerializeField] private string url;

    string jsonText;

    // データ保存変数
    private string timestamp;
    private int amount;

    // データ保存変数をここに作成。

    // シリアル通信の設定及び初期化
    public void Create()
    {
        if (isNull) return;

        // 一定間隔でGetDataメソッドを呼び出す
        //InvokeRepeating(nameof(GetDataCoroutine), 0f, 1f); // 1秒ごとにデータを取得
    }

    // シリアル通信の開始
    public void GetDataCoroutine()
    {
        StartCoroutine(GetData());
    }

    // シリアル通信からデータを取得
    public IEnumerator GetData()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        // リクエスト送信
        yield return request.SendWebRequest();

        // 通信エラーチェック
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Error: {request.error}, URL: {url}");
        }
        else
        {
            if (request.responseCode == 200)
            {
                // UTF8文字列として取得する
                jsonText = request.downloadHandler.text;
                ParseJson(jsonText);
                Debug.Log("Timestamp: " + timestamp + ", Value: " + amount.ToString());
            }
            else
            {
                Debug.LogError($"Unexpected response code: {request.responseCode}, URL: {url}");
            }
        }
    }

    // JSONデータをパースして変数に格納するメソッド
    private void ParseJson(string json)
    {
        timestamp = json.Substring(2, json.IndexOf("\"", 2) - 2);
        amount = int.Parse((json.Substring(json.IndexOf("\"", 2) + 2, json.Length - json.IndexOf("\"", 2) - 3)));
    }
}
