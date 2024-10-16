using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    // アプリのFPSを設定。アプリのFPSは必ずこの値になるようにする
    public static readonly int SPECIFIED_FPS = 60;

    // Paramで使用。各種メッセージを表す
    public const int MSG_NULL = 0;
    public const int MSG_SUCCESS = 1;
    public const int MSG_FAILED = 2;
    public const int MSG_ERROR = 3;
    public const int MSG_WARNING = 4;
    public const int MSG_CHANGE_SCENE = 5;

    // 各シーン名は指定。インスペクター上でシーン名を記述する場合以下の値にする
    public const string SCENE_HOME = "Home";
    public const string SCENE_SEARCH = "Search";
    public const string SCENE_TOPIC = "Topic";
    public const string SCENE_MYPAGE = "MyPage";
    public const string SCENE_BOOKMARK = "Bookmark";

    // 各エconstンスペクター上で以下の文字列で指定する
    public const string TYPE_BACKGROUND = "Background";
    public const string TYPE_IMAGE = "Image";
    public const string TYPE_INPUT_BOX = "InputBox";
    public const string TYPE_BUTTON = "Button";
    public const string TYPE_TEXT = "Text";
}

