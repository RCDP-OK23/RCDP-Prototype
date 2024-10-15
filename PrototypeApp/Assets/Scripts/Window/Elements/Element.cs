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

    // 初期設定で表示される画像の親オブジェクトを設定
    [SerializeField] public GameObject defImageGroup;

    // 使用する画像らの親オブジェクトを設定
    [SerializeField] private GameObject imageGroups;

    // 使用する画像を格納
    private Dictionary<string, List<Image>> diImageGroups;

    // 画像グループの表示状態を設定
    private Dictionary<string, bool> diGroupShow;

    // エレメントの表示状態を設定。Show関数内でtrueにし、Close関数内でfalseにすることで表示状態を管理する
    private bool isShow = false;
    public bool IsShow { get { return isShow; } set { isShow = value; } }

    // エレメントの初期化処理。Init関数で呼び出す
    protected void BaseInit()
    {
        InitImages();
    }

    // 孫オブジェクトをすべて取得
    protected List<GameObject> GetAllChildren(GameObject parent)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            children.Add(child.gameObject);
        }
        return children;
    }

    // 画像らの初期化処理を記述
    private void InitImages()
    {
        diImageGroups = new Dictionary<string, List<Image>>();
        diGroupShow = new Dictionary<string, bool>();

        List<GameObject> liImageGroups = GetAllChildren(imageGroups);

        for (int i = 0; i < liImageGroups.Count; i++)
        {
            List<Image> liImages = new List<Image>();
            foreach (Transform child in liImageGroups[i].transform)
            {
                child.gameObject.GetComponent<Image>().enabled = false;
                liImages.Add(child.gameObject.GetComponent<Image>());
            }
            diImageGroups.Add(liImageGroups[i].name, liImages);
            diGroupShow.Add(liImageGroups[i].name, false);
        }

        // フレームの透明度を０にすることで非表示状態にする
        frame.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    // Imageの表示状態を設定
    public void ShowImages(bool val, string groupName)
    {
        for (int i = 0; i < diImageGroups[groupName].Count; i++)
        {
            diImageGroups[groupName][i].enabled = val;
        }

        diGroupShow[groupName] = val;

        foreach (KeyValuePair<string, bool> pair in diGroupShow)
        {
            if (pair.Value)
            {
                isShow = true;
                return;
            }
        }

        isShow = false;
    }

    public void ShowAllImages(bool val)
    {
        foreach (KeyValuePair<string, List<Image>> pair in diImageGroups)
        {
            ShowImages(val, pair.Key);
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
        if (!isShow) return;

        foreach (KeyValuePair<string, List<Image>> pair in diImageGroups)
        {
            for (int i = 0; i < pair.Value.Count; i++)
            {
                Vector2 newVec = new Vector2
                (
                    pair.Value[i].rectTransform.anchoredPosition.x + vec.x,
                    pair.Value[i].rectTransform.anchoredPosition.y + vec.y
                );
                pair.Value[i].rectTransform.anchoredPosition = newVec;
            }
        }
    }

    protected bool IsTapped()
    {
        return false;
    }

    protected bool IsTapping()
    {
        return false;
    }

    // エレメントが表示されているときに、タップされたか判定する処理を記述
    //protected bool IsTapped()
    //{
    //    if (!isShow || Input.touchCount == 0) return false;

    //    Touch touch = Input.GetTouch(0);
    //    Vector2 touchPosition = touch.position;

    //    if (touch.phase == TouchPhase.Ended)
    //    {
    //        RectTransform rectTransform = frame.GetComponent<RectTransform>();
    //        Vector2 localPoint;
    //        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, touchPosition, null, out localPoint);

    //        if (rectTransform.rect.Contains(localPoint)) return true;
    //    }

    //    return false;
    //}
}
