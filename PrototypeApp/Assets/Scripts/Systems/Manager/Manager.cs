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
        windowNameToIndex = new Dictionary<string, AppWindow>();

        for (int i = 0; i < windows.Count; i++)
        {
            windowNameToIndex.Add(windows[i].name, windows[i]);
            windows[i].Init();
        }
    }

    // BaseExit�֐��ōŌ�ɕK�����s����BManager�N���X�̏I���������s��
    protected void Destoroy()
    {

    }

    // �����ɃE�B���h�E�̖��O���w�肵�A���̃E�B���h�E��\������
    protected void ShowWindow(string wndName)
    {

    }

    // �����ɃE�B���h�E�̖��O���w�肵�A���̃E�B���h�E���\���ɂ���
    protected void CloseWindow(string wndName)
    {

    }

    // ���ׂĂ̊J���Ă���E�B���h�E�̃C�x���g�����s�̕K�v������Ȃ���s����
    // BaseUpdate�֐��Ŏ��s����
    protected void ExecuteWindows(ref Params param)
    {

    }

    // �X�N���[�����邱�Ƃ����m���ꂽ�ꍇ�A�E�B���h�E���X�N���[���ɍ��킹�Ĉړ�������
    // BaseUpdate�֐���ExecuteWindows�֐��̂��ƂɎ��s����
    protected void ScrollWindows(ref Params param)
    {

    }

    // Unity��Awake�֐��̑���Ɏg�p����֐�
    abstract public void BaseAwake(ref Params param);

    // Unity��Start�֐��̑���Ɏg�p����֐�
    abstract public void BaseStart(ref Params param);

    // Unity��Update�֐��̑���Ɏg�p����֐�
    abstract public void BaseUpdate(ref Params param);

    // �V�[�����؂�ւ��ۂɌĂяo�����֐�
    abstract public void BaseExit(ref Params param);
}
