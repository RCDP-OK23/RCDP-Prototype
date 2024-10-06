using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class SensorDevice : MonoBehaviour
{
    // �V���A���ʐM�p�̕ϐ�
    private SerialPort serialPort = null;

    // �V���A���ʐM�̐ݒ�
    [SerializeField] private string portName = "";
    [SerializeField] private int baudRate = 0;

    // �f�[�^�ۑ��ϐ��������ɍ쐬�B

    // �V���A���ʐM�̐ݒ�y�я�����
    public void Create()
    {
        serialPort = new SerialPort(portName, baudRate);
    }

    // �V���A���ʐM�̊J�n
    public void Open()
    {
        serialPort.Open();
    }

    // �V���A���ʐM����f�[�^���擾
    public void GetData()
    {

    }

}
