using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
* BaseManagerクラスの関数を呼び出すために基本的には使用する
* staticなためParam.変数名で値を編集できる
*/
public class Params : MonoBehaviour
{
    // Constants.MSG_の値を使用する
    [HideInInspector] public static int msg = Constants.MSG_NULL;

    // BaseManager関数の引数的なもの。シーンの名前などを指定する
    [HideInInspector] public static float floPar = 0;
    [HideInInspector] public static string strPar = "";

    // 毎フレーム実行され、そのフレーム外でのmsgは保持されない
    public static void Init()
    {
        msg = Constants.MSG_NULL;
        floPar = 0;
        strPar = "";
    }
}
