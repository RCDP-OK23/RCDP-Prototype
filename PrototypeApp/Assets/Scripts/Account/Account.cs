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

    // �V���A���ʐM�X�N���v�g�����̃Q�[���I�u�W�F�N�g��ݒ�
    [SerializeField] private List<SensorDevice> devices = null;

    // ������╶����
    [SerializeField] private string searchJapaneseStr;
    [SerializeField] private string searchKanaStr;
    [SerializeField] private string searchEnglishStr;
    [SerializeField] private string searchRomanStr;

    public void Init()
    {
        foreach (SensorDevice device in devices)
        {
            // �V���A���ʐM�X�N���v�g�����Q�[���I�u�W�F�N�g�𐶐�
            device.Create();
        }
    }

    public bool SearchResult(string inputText)
    {
        // �X�y�[�X���܂܂�邩�𔻒�
        if (inputText.Contains(" ") || inputText.Contains("�@"))
        {
            // �X�y�[�X���܂܂��ꍇ�A�P�ꂲ�Ƃɕ���
            string[] words = inputText.Split(new char[] { ' ', '�@' }, StringSplitOptions.RemoveEmptyEntries);

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
            // �X�y�[�X���܂܂�Ȃ����߁A���̂܂܌���
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
