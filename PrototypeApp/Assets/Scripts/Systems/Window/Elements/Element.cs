using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

abstract public class Element : MonoBehaviour
{
    // �G�������g�̎�ނ�ݒ�
    [SerializeField] private string type = "";
    public string Type { get { return type; } }

    // �v�f�̊O�g�ɂȂ�摜������GameObject��ݒ�B�摜�͓����x�O�ɂ��邱�ƂŔ�\����Ԃɂ��Ă���
    [SerializeField] protected GameObject frame;
    
    // �v�f�Ɏg�p�����摜����C���X�y�N�^�[�Őݒ�B
    [SerializeField] private List<Image> images = new List<Image>();

    // �G�������g�̕\����Ԃ�ݒ�BShow�֐�����true�ɂ��AClose�֐�����false�ɂ��邱�Ƃŕ\����Ԃ��Ǘ�����
    private bool isShow = false;
    public bool IsShow { get { return isShow; } set { isShow = value; } }

    // ���ׂĂ�Image��\������
    protected void ShowImages()
    {
        foreach (var image in images)
        {
            image.enabled = true;
        }
    }

    // ���ׂĂ�Image���\���ɂ���
    protected void HideImages()
    {
        foreach (var image in images)
        {
            image.enabled = false;
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

    // �G�������g���\������Ă���Ƃ��ɁA�^�b�v���ꂽ�����肷�鏈�����L�q
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
