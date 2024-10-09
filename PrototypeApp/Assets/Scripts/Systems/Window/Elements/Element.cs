using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

abstract public class Element : MonoBehaviour
{
    // 要素の外枠になる画像を持つGameObjectを設定。画像は透明度０にすることで非表示状態にしておく
    [SerializeField] private GameObject frame;

    // エレメントの種類を設定
    [SerializeField] private string type = "";
    public string Type { get { return type; } }

    // エレメントの初期化処理を記述。初期化時にエレメントは非表示状態にする
    abstract public void Init();

    // エレメントの表示処理を記述
    abstract public void Show();

    // エレメントの非表示処理を記述
    abstract public void Close();

    // エレメントの実行処理を記述
    abstract public void Execute();

    // エレメントの移動処理を記述
    abstract public void Move(ref Vector2 vec);
}
