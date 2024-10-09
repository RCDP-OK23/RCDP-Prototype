using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    // アプリのFPSを設定。アプリのFPSは必ずこの値になるようにする
    public static readonly int SPECIFIED_FPS = 60;

    // Paramで使用。各種メッセージを表す
    public static readonly int MSG_NULL = 0;
    public static readonly int MSG_SUCSESS = 1;
    public static readonly int MSG_FAILED = 2;
    public static readonly int MSG_ERROR = 3;
    public static readonly int MSG_WARNING = 4;
    public static readonly int MSG_CHANGE_SCENE = 5;

    // 各シーン名は指定。インスペクター上でシーン名を記述する場合以下の値にする
    public static readonly string SCENE_HOME = "Home";
    public static readonly string SCENE_SEARCH = "Search";
    public static readonly string SCENE_TOPIC = "Topic";
    public static readonly string SCENE_MYPAGE = "MyPage";
    public static readonly string SCENE_BOOKMARK = "Bookmark";

    // 各エレメントのタイプを指定する。インスペクター上で以下の文字列で指定する
    public static readonly string TYPE_BACKGROUND = "Background";
    public static readonly string TYPE_IMAGE = "Image";
    public static readonly string TYPE_INPUT_BOX = "InputBox";
    public static readonly string TYPE_BUTTON = "Button";
    public static readonly string TYPE_TEXT = "Text";
}

