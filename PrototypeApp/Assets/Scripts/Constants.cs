using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    // �A�v����FPS��ݒ�B�A�v����FPS�͕K�����̒l�ɂȂ�悤�ɂ���
    public static readonly int SPECIFIED_FPS = 60;

    // Param�Ŏg�p�B�e�탁�b�Z�[�W��\��
    public const int MSG_NULL = 0;
    public const int MSG_SUCCESS = 1;
    public const int MSG_FAILED = 2;
    public const int MSG_ERROR = 3;
    public const int MSG_WARNING = 4;
    public const int MSG_CHANGE_SCENE = 5;

    // �e�V�[�����͎w��B�C���X�y�N�^�[��ŃV�[�������L�q����ꍇ�ȉ��̒l�ɂ���
    public const string SCENE_HOME = "Home";
    public const string SCENE_SEARCH = "Search";
    public const string SCENE_TOPIC = "Topic";
    public const string SCENE_MYPAGE = "MyPage";
    public const string SCENE_BOOKMARK = "Bookmark";

    // �e�Gconst���X�y�N�^�[��ňȉ��̕�����Ŏw�肷��
    public const string TYPE_BACKGROUND = "Background";
    public const string TYPE_IMAGE = "Image";
    public const string TYPE_INPUT_BOX = "InputBox";
    public const string TYPE_BUTTON = "Button";
    public const string TYPE_TEXT = "Text";
}

