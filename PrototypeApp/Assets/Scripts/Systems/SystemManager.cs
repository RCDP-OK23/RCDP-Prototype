using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    // Manager�֐��̈����̎Q�ƌ��ϐ��BSystemManager�Ƀf�[�^��n�����߂Ɏg�p�B
    public static Param param;

    // �A�v����FPS��ݒ�B�A�v����FPS�͕K�����̒l�ɂȂ�悤�ɂ���B
    readonly int SPECIFIED_FPS = 60;

    // �V�[���̖��O��v�f�Ɏ��ϐ�
    [SerializeField] private List<string> SCENE_NAMES;

    // �e�V�[���ł�Manager�N���X���p�������N���X������GameObject��ݒ�B
    [SerializeField] private Manager manager;

    /* ����̃v���g�^�C�v�łł͈ȉ��̊֐��ł̂�Unity��Awake�AStart�AUpdate�֐����g�p����B
     * ���̃X�N���v�g�ł������g�����Ƃ͐������Ȃ����ǁA�����ł͂Ȃ�
     */
    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // �V�[�����؂�ւ��ۂɌĂяo�����֐�
    private void Exit()
    {

    }

    // �e�V�[���ŕK����x���s����BFPS�̐ݒ���s���B
    public Param.MSG SetFps()
    {
        return Param.MSG.SUCSESS;
    }

    // param�Ɋi�[���ꂽ�V�[���������ɁA�V�[����ύX����B
    public Param.MSG ChangeScene()
    {
        return Param.MSG.SUCSESS;
    }
}
