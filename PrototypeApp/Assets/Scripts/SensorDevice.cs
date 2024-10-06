using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class SensorDevice : MonoBehaviour
{
    // シリアル通信用の変数
    private SerialPort serialPort = null;

    // シリアル通信の設定
    [SerializeField] private string portName = "";
    [SerializeField] private int baudRate = 0;

    // データ保存変数をここに作成。

    // シリアル通信の設定及び初期化
    public void Create()
    {
        serialPort = new SerialPort(portName, baudRate);
    }

    // シリアル通信の開始
    public void Open()
    {
        serialPort.Open();
    }

    // シリアル通信からデータを取得
    public void GetData()
    {

    }

}
