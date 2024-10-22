using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;


abstract public class Manager : MonoBehaviour
{
    // �V�[���ŕ\������E�B���h�E���i�[
    private List<AppWindow> windows = null;

    // �E�B���h�E�̖��O���L�[�ɂ��A���X�g�̃C���f�b�N�X���擾���邽�߂̕ϐ�
    private Dictionary<string, AppWindow> windowNameToIndex = null;

    // �E�B���h�E�̃X�N���[���ɂ��ړ��ʂ��w��B
    private float editorScrollSpeed = 400;
    private float appScrollSpeed = 1;

    // �����ʒu����̈ړ��ʂ�ۑ��B
    private Vector2 movedVec;

    // BaseAwake�֐��ōŏ��ɕK�����s����BManager�N���X�̏��������s��
    protected void Init(List<GameObject> sourceWindows)
    {
        Debug.Log("Manager Init");

        // �E�B���h�E���i�[����ϐ��̍쐬
        windows = new List<AppWindow>();

        // �E�B���h�E�̖��O���L�[�ɂ��A���X�g�̃C���f�b�N�X���擾���邽�߂̕ϐ��̍쐬
        windowNameToIndex = new Dictionary<string, AppWindow>();
        for (int i = 0; i < sourceWindows.Count; i++)
        {
            // �E�B���h�E�����X�g�ɒǉ����A�E�B���h�E�̖��O���L�[�ɂ��A���X�g�̃C���f�b�N�X���擾���邽�߂̕ϐ��ɒǉ�
            windows.Add(sourceWindows[i].GetComponent<AppWindow>());
            windowNameToIndex.Add(windows[i].name, windows[i]);

            // �E�B���h�E�̏�����
            windows[i].Init();
        }

        movedVec = new Vector2(0, 0);
    }

    // BaseExit�֐��ōŌ�ɕK�����s����BManager�N���X�̏I���������s��
    protected void Destoroy()
    {
        Debug.Log("Manager Destoroy");
    }

    // �����ɃE�B���h�E�̖��O���w�肵�A���̃E�B���h�E��\������
    public void ShowWindow(string wndName)
    {
        windows[windows.IndexOf(windowNameToIndex[wndName])].Show();
    }

    // �����ɃE�B���h�E�̖��O���w�肵�A���̃E�B���h�E���\���ɂ���
    public void CloseWindow(string wndName)
    {
        // �E�B���h�E���\���ɂ����ꍇ�A�X�N���[���ʂ����Z�b�g����
        if
        (
            windows[windows.IndexOf(windowNameToIndex[wndName])].IsScroll &&
            !windows[windows.IndexOf(windowNameToIndex[wndName])].IsPopUp
        )
        {
            windows[windows.IndexOf(windowNameToIndex[wndName])].Move(ref movedVec);
        }

        windows[windows.IndexOf(windowNameToIndex[wndName])].Close();
    }

    // ���ׂĂ̊J���Ă���E�B���h�E�̃C�x���g�����s�̕K�v������Ȃ���s����
    // BaseUpdate�֐��Ŏ��s����
    protected void ExecuteWindows()
    {
        for (int i = 0; i < windows.Count; i++)
        {
            if (windows[i].IsPopUp)
            {
                windows[i].Execute();
                if (Params.popUpWindowDone) return;
            }
        }


        for (int i = 0; i < windows.Count; i++)
        {
            if (!windows[i].IsPopUp) windows[i].Execute();
        }
    }

    // �X�N���[�����邱�Ƃ����m���ꂽ�ꍇ�A�E�B���h�E���X�N���[���ɍ��킹�Ĉړ�������
    // BaseUpdate�֐���ExecuteWindows�֐��̂��ƂɎ��s����
    protected void ScrollWindows()
    {
#if UNITY_EDITOR
        // �G�f�B�^�p�̃X�N���[������

        // �X�N���[���ɂ��E�B���h�E�̈ړ��ʂ��擾
        Vector2 moveVec = new Vector2(0, 0);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            moveVec.y = scroll * editorScrollSpeed;
            movedVec -= moveVec;

            // �X�N���[������K�v������E�B���h�E�̏ꍇ�A�E�B���h�E���X�N���[���ɍ��킹�Ĉړ�������
            for (int i = 0; i < windows.Count; i++)
            {
                if (windows[i].IsScroll && !windows[i].IsPopUp) windows[i].Move(ref moveVec);
            }
        }
#else
        // Android�p�̃X�N���[������
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 moveVec = touch.deltaPosition * appScrollSpeed * Time.deltaTime;
                movedVec -= moveVec;

                for (int i = 0; i < windows.Count; i++)
                {
                    if (windows[i].IsScroll && !windows[i].IsPopUp) windows[i].Move(ref moveVec);
                }
            }
        }
#endif
    }

    // �X�N���[�����邱�Ƃ����m���ꂽ�ꍇ�A�E�B���h�E���X�N���[���ɍ��킹�Ĉړ�������B
    // BaseUpdate�֐���ExecuteWindows�֐��̂��ƂɎ��s����B
    // �X�N���[���ɂ��ړ��ł���Œ�Y�l�������Ɏw�肷��B
    protected void ScrollWindows(float bottomY)
    {
#if UNITY_EDITOR
        // �G�f�B�^�p�̃X�N���[������

        // �X�N���[���ɂ��E�B���h�E�̈ړ��ʂ��擾
        Vector2 moveVec = new Vector2(0, 0);

        float scroll = -Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            moveVec.y = scroll * editorScrollSpeed;

            movedVec -= moveVec;
            if (movedVec.y < bottomY)
            {
                movedVec += moveVec;
                return;
            }
            else if (movedVec.y > 0)
            {
                movedVec += moveVec;
                return;
            }

            // �X�N���[������K�v������E�B���h�E�̏ꍇ�A�E�B���h�E���X�N���[���ɍ��킹�Ĉړ�������
            for (int i = 0; i < windows.Count; i++)
            {
                if (windows[i].IsScroll && !windows[i].IsPopUp)
                {
                    windows[i].Move(ref moveVec);
                }
            }
        }
#else
        // Android�p�̃X�N���[������
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 moveVec = touch.deltaPosition * appScrollSpeed * Time.deltaTime;

                movedVec -= moveVec;
                if (movedVec.y < bottomY)
                {
                    movedVec += moveVec;
                    return;
                }
                else if (movedVec.y > 0)
                {
                    movedVec += moveVec;
                    return;
                }

                for (int i = 0; i < windows.Count; i++)
                {
                    if (windows[i].IsScroll && !windows[i].IsPopUp) windows[i].Move(ref moveVec);
                }
            }
        }
#endif
    }

    // Unity��Awake�֐��̑���Ɏg�p����֐�
    abstract public void BaseAwake();

    // Unity��Start�֐��̑���Ɏg�p����֐�
    abstract public void BaseStart();

    // Unity��Update�֐��̑���Ɏg�p����֐�
    abstract public void BaseUpdate();

    // �V�[�����؂�ւ��ۂɌĂяo�����֐�
    abstract public void BaseExit();
}
