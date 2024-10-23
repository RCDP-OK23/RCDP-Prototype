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

    public void Init()
    {
        foreach (SensorDevice device in devices)
        {
            // �V���A���ʐM�X�N���v�g�����Q�[���I�u�W�F�N�g�𐶐�
            device.Create();
        }
    }
}
