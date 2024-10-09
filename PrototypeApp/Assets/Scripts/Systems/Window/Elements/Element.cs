using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

abstract public class Element : MonoBehaviour
{
    // エレメントの種類を設定
    [SerializeField] private string type = "";
    public string Type { get { return type; } }

    // 要素の外枠になる画像を持つGameObjectを設定。画像は透明度０にすることで非表示状態にしておく
    [SerializeField] protected GameObject frame;
    
    // 要素に使用した画像らをインスペクターで設定。
    [SerializeField] private List<Image> images = new List<Image>();

    // エレメントの表示状態を設定。Show関数内でtrueにし、Close関数内でfalseにすることで表示状態を管理する
    private bool isShow = false;
    public bool IsShow { get { return isShow; } set { isShow = value; } }

    // すべてのImageを表示する
    protected void ShowImages()
    {
        foreach (var image in images)
        {
            image.enabled = true;
        }
    }

    // すべてのImageを非表示にする
    protected void HideImages()
    {
        foreach (var image in images)
        {
            image.enabled = false;
        }
    }

    // エレメントの初期化処理を記述。初期化時にエレメントは非表示状態にする
    abstract public void Init();

    // エレメントの表示処理を記述
    abstract public void Show();

    // エレメントの非表示処理を記述
    abstract public void Close();

    // エレメントの実行処理を記述
    abstract public void Execute();

    // エレメントの移動処理を記述
    public void Move(ref Vector2 vec)
    {
        foreach (var image in images)
        {
            Vector2 newVec = new Vector2
            (
                image.rectTransform.anchoredPosition.x + vec.x,
                image.rectTransform.anchoredPosition.y + vec.y
            );
            image.rectTransform.anchoredPosition = newVec;
        }
    }

    // エレメントが表示されているときに、タップされたか判定する処理を記述
    protected bool IsTapped()
    {
        if (!isShow || Input.touchCount == 0) return false;

        Touch touch = Input.GetTouch(0);
        Vector2 touchPosition = touch.position;

        if (touch.phase == TouchPhase.Ended)
        {
            RectTransform rectTransform = frame.GetComponent<RectTransform>();
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, touchPosition, null, out localPoint);

            if (rectTransform.rect.Contains(localPoint)) return true;
        }

        return false;
    }
}
