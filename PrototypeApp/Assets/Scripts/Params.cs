using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
* BaseManager�N���X�̊֐����Ăяo�����߂Ɋ�{�I�ɂ͎g�p����
* static�Ȃ���Param.�ϐ����Œl��ҏW�ł���
*/
public class Params : MonoBehaviour
{
    // Constants.MSG_�̒l���g�p����
    [HideInInspector] public static int msg = Constants.MSG_NULL;

    // BaseManager�֐��̈����I�Ȃ��́B�V�[���̖��O�Ȃǂ��w�肷��
    [HideInInspector] public static float floPar = 0;
    [HideInInspector] public static string strPar = "";

    // ���t���[�����s����A���̃t���[���O�ł�msg�͕ێ�����Ȃ�
    public static void Init()
    {
        msg = Constants.MSG_NULL;
        floPar = 0;
        strPar = "";
    }
}
