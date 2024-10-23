using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account : MonoBehaviour
{
    [SerializeField] private int id = -1;
    public int ID
    { get { return id; } }

    [SerializeField] private string pass = "";
    public string Pass
    { get { return pass; } }

    [SerializeField] private string mail = "";
    public string Mail
    { get { return mail; } }

    // シリアル通信スクリプトを持つのゲームオブジェクトを設定
    [SerializeField] private List<SensorDevice> devices = null;

    public void Init()
    {
        foreach (SensorDevice device in devices)
        {
            // シリアル通信スクリプトを持つゲームオブジェクトを生成
            device.Create();
        }
    }
}
