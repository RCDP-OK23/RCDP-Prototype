using System.Collections;
using System.Collections.Generic;
using UnityEngine;


abstract public class Manager : MonoBehaviour
{
    // �V�[���ŕ\������E�B���h�E�����ׂăC���X�y�N�^�[�Őݒ�
    [SerializeField] private List<AppWindow> windows = null;

    // �E�B���h�E�̖��O���L�[�ɂ��A���X�g�̃C���f�b�N�X���擾���邽�߂̕ϐ�
    private Dictionary<string, AppWindow> windowNameToIndex = null;

    // BaseAwake�֐��ōŏ��ɕK�����s����BManager�N���X�̏��������s��
    protected void Init()
    {
        Debug.Log("Manager Init");

        windowNameToIndex = new Dictionary<string, AppWindow>();

        for (int i = 0; i < windows.Count; i++)
        {
            windowNameToIndex.Add(windows[i].WndName, windows[i]);
            windows[i].Init();
        }
    }

    // BaseExit�֐��ōŌ�ɕK�����s����BManager�N���X�̏I���������s��
    protected void Destoroy()
    {
        Debug.Log("Manager Destoroy");
    }

    // �����ɃE�B���h�E�̖��O���w�肵�A���̃E�B���h�E��\������
    protected void ShowWindow(string wndName)
    {
        windows[windows.IndexOf(windowNameToIndex[wndName])].Show();
    }

    // �����ɃE�B���h�E�̖��O���w�肵�A���̃E�B���h�E���\���ɂ���
    protected void CloseWindow(string wndName)
    {
        windows[windows.IndexOf(windowNameToIndex[wndName])].Close();
    }

    // ���ׂĂ̊J���Ă���E�B���h�E�̃C�x���g�����s�̕K�v������Ȃ���s����
    // BaseUpdate�֐��Ŏ��s����
    protected void ExecuteWindows()
    {
        for (int i = 0; i < windows.Count; i++)
        {
            windows[i].Execute();
        }
    }

    // �X�N���[�����邱�Ƃ����m���ꂽ�ꍇ�A�E�B���h�E���X�N���[���ɍ��킹�Ĉړ�������
    // BaseUpdate�֐���ExecuteWindows�֐��̂��ƂɎ��s����
    protected void ScrollWindows()
    {
        // �X�N���[���ɂ��E�B���h�E�̈ړ��ʂ��擾
        Vector2 moveVec = new Vector2(0, 0);

        // �X�N���[������K�v������E�B���h�E�̏ꍇ�A�E�B���h�E���X�N���[���ɍ��킹�Ĉړ�������
        for (int i = 0; i < windows.Count; i++)
        {
            if (windows[i].IsScroll) windows[i].Move(ref moveVec);
        }
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