using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    // �A�v����FPS��ݒ�B�A�v����FPS�͕K�����̒l�ɂȂ�悤�ɂ���
    public static readonly int SPECIFIED_FPS = 60;

    // ��ʉ𑜓x
    public static readonly int SCREEN_WIDTH = 1920;
    public static readonly int SCREEN_HEIGHT = 1080;

    // Param�Ŏg�p�B�e�탁�b�Z�[�W��\��
    public static readonly int MSG_NULL = 0;
    public static readonly int MSG_SUCCESS = 1;
    public static readonly int MSG_FAILED = 2;
    public static readonly int MSG_ERROR = 3;
    public static readonly int MSG_WARNING = 4;
    public static readonly int MSG_CHANGE_SCENE = 5;

    // �e�V�[�����͎w��B�C���X�y�N�^�[��ŃV�[�������L�q����ꍇ�ȉ��̒l�ɂ���
    public static readonly string SCENE_HOME = "Home";
    public static readonly string SCENE_SEARCH = "Search";
    public static readonly string SCENE_TOPIC = "Topic";
    public static readonly string SCENE_MYPAGE = "MyPage";
    public static readonly string SCENE_BOOKMARK = "Bookmark";

    // �e�G�������g�̃^�C�v���w�肷��B�C���X�y�N�^�[��ňȉ��̕�����Ŏw�肷��
    public static readonly string TYPE_BACKGROUND = "Background";
    public static readonly string TYPE_IMAGE = "Image";
    public static readonly string TYPE_INPUT_BOX = "InputBox";
    public static readonly string TYPE_BUTTON = "Button";
    public static readonly string TYPE_TEXT = "Text";
}
