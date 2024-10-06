using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    // アプリのFPSを設定。アプリのFPSは必ずこの値になるようにする。
    public static readonly int SPECIFIED_FPS = 60;

    public static readonly int MSG_NULL = 0;
    public static readonly int MSG_SUCSESS = 1;
    public static readonly int MSG_FAILED = 2;
    public static readonly int MSG_ERROR = 3;
    public static readonly int MSG_WARNING = 4;
    public static readonly int MSG_CHANGE_SCENE = 5;

    public static readonly string SCENE_HOME = "Home";
    public static readonly string SCENE_SEARCH = "Search";
    public static readonly string SCENE_TOPIC = "Topic";
    public static readonly string SCENE_MYPAGE = "MyPage";
    public static readonly string SCENE_BOOKMARK = "Bookmark";

    public static readonly string TYPE_BACKGROUND = "Background";
    public static readonly string TYPE_IMAGE = "Image";
    public static readonly string TYPE_INPUT_BOX = "InputBox";
    public static readonly string TYPE_BUTTON = "Button";
    public static readonly string TYPE_TEXT = "Text";

    public static readonly string WND_HEADER = "WindowHeader";
    public static readonly string WND_FOOTER = "WindowFooter";
}

