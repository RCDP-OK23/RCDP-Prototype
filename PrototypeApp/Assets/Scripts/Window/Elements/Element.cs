using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

abstract public class Element : MonoBehaviour
{
    // �G�������g�̎�ނ�ݒ�
    [SerializeField] private string type = "";
    public string Type { get { return type; } }

    // �C�x���g�V�X�e����ݒ�
    private EventSystem eventSystem;

    // ���C�L���X�^�[��ݒ�
    private GraphicRaycaster raycaster;

    // �v�f�̊O�g�ɂȂ�摜������GameObject��ݒ�B�摜�͓����x�O�ɂ��邱�ƂŔ�\����Ԃɂ��Ă���
    [SerializeField] protected GameObject frame;

    // �����ݒ�ŕ\�������摜�̐e�I�u�W�F�N�g��ݒ�
    [SerializeField] public GameObject defImageGroup;

    // �g�p����摜��̐e�I�u�W�F�N�g��ݒ�
    [SerializeField] private GameObject imageGroups;

    // �g�p����摜���i�[
    private Dictionary<string, List<Image>> diImageGroups;

    // �g�p����e�L�X�g���i�[
    protected Dictionary<string, Text> diTexts;

    // �摜�O���[�v�̕\����Ԃ�ݒ�
    private Dictionary<string, bool> diGroupShow;

    // �G�������g�̕\����Ԃ�ݒ�BShow�֐�����true�ɂ��AClose�֐�����false�ɂ��邱�Ƃŕ\����Ԃ��Ǘ�����
    private bool isShow = false;
    public bool IsShow { get { return isShow; } set { isShow = value; } }

    // �G�������g�̏����������BInit�֐��ŌĂяo��
    protected void BaseInit()
    {
        raycaster = GetComponentInParent<GraphicRaycaster>();
        eventSystem = GetComponentInParent<EventSystem>();

        InitImages();
    }

    // ���I�u�W�F�N�g�����ׂĎ擾
    protected List<GameObject> GetAllChildren(GameObject parent)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            children.Add(child.gameObject);
        }
        return children;
    }

    // �摜��̏������������L�q
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

        // �t���[���̓����x���O�ɂ��邱�ƂŔ�\����Ԃɂ���
        frame.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    // Image�̕\����Ԃ�ݒ�
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

    public void ShowText(bool val, string name)
    {
        if (diTexts.ContainsKey(name))
        {
            diTexts[name].enabled = val;
        }
    }

    protected void ShowAllTexts(bool val)
    {
        foreach (KeyValuePair<string, Text> pair in diTexts)
        {
            pair.Value.enabled = val;
        }
    }

    // �G�������g�̏������������L�q�B���������ɃG�������g�͔�\����Ԃɂ���
    abstract public void Init();

    // �G�������g�̕\���������L�q
    abstract public void Show();

    // �G�������g�̔�\���������L�q
    abstract public void Close();

    // �G�������g�̎��s�������L�q
    abstract public void Execute();

    // �G�������g�̈ړ��������L�q
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

    private bool IsUnderMouse()
    {
        PointerEventData pointerEventData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pointerEventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject == frame)
            {
                return true;
            }
        }
        return false;
    }

    protected bool IsClick()
    {
        if (!isShow) return false;

        if (Input.GetMouseButtonDown(0) && IsUnderMouse())
        {
            return true;
        }
        return false;
    }

    protected bool IsHover()
    {
        if (!isShow) return false;

        if (IsUnderMouse())
        {
            return true;
        }
        return false;
    }

    protected bool IsTapped()
    {
        if (!isShow || Input.touchCount == 0) return false;

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Ended)
        {
            PointerEventData pointerEventData = new PointerEventData(eventSystem)
            {
                position = touch.position
            };

            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(pointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject == frame)
                {
                    return true;
                }
            }
        }

        return false;
    }

    protected bool IsTapping()
    {
        if (!isShow || Input.touchCount == 0) return false;

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
        {
            PointerEventData pointerEventData = new PointerEventData(eventSystem)
            {
                position = touch.position
            };

            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(pointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject == frame)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
