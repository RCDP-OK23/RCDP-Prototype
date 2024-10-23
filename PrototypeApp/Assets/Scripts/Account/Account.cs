using System;
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

    // 検索候補文字列
    [SerializeField] private string searchJapaneseStr;
    [SerializeField] private string searchKanaStr;
    [SerializeField] private string searchEnglishStr;
    [SerializeField] private string searchRomanStr;

    public void Init()
    {
        foreach (SensorDevice device in devices)
        {
            // シリアル通信スクリプトを持つゲームオブジェクトを生成
            device.Create();
        }
    }

    public bool SearchResult(string inputText)
    {
        // スペースが含まれるかを判定
        if (inputText.Contains(" ") || inputText.Contains("　"))
        {
            // スペースが含まれる場合、単語ごとに分割
            string[] words = inputText.Split(new char[] { ' ', '　' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if
                (
                    searchJapaneseStr.Contains(word) || searchKanaStr.Contains(word) ||
                    searchEnglishStr.Contains(word) || searchRomanStr.Contains(word)
                )
                {
                    return true;
                }
            }

            return false;
        }
        else
        {
            // スペースが含まれないため、そのまま検索
            if
            (
                searchJapaneseStr.Contains(inputText) || searchKanaStr.Contains(inputText) ||
                searchEnglishStr.Contains(inputText) || searchRomanStr.Contains(inputText)
            )
            {
                return true;
            }

            return false;
        }
    }
}
