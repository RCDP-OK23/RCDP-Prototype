using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    // �V���A���ʐM�X�N���v�g�����̃Q�[���I�u�W�F�N�g��ݒ�
    [SerializeField] private SensorDevice sensorDevice;

    // Manager�N���X���p�������N���X�����Q�[���I�u�W�F�N�g��ݒ�
    [SerializeField] private GameObject managerObject;
    private Manager manager;

    /* 
     * ����̃v���g�^�C�v�łł͈ȉ��̊֐��ł̂�Unity��Awake�AStart�AUpdate�֐����g�p����
     * ���̃X�N���v�g�ł������g�����Ƃ͐����͂��Ȃ����A��Ǝ��ԏ㋖�e����ꍇ������
     */
    private void Awake()
    {
        Debug.Log("BaseManager Awake");

        // FPS��ݒ�
        SetFps();

        // ���b�Z�[�W�����̂��߂̃p�����[�^��������
        Params.Init();

        // �V���A���ʐM�X�N���v�g�����Q�[���I�u�W�F�N�g�𐶐�
        sensorDevice.Create();

        // Manager�N���X���p�������N���X�����Q�[���I�u�W�F�N�g����Manager�N���X���擾
        manager = managerObject.GetComponent<Manager>();

        // Manager�N���X���p�������N���X��Awake�֐������s
        manager.BaseAwake();
    }

    void Start()
    {
        Debug.Log("BaseManager Start");

        // ���b�Z�[�W�����̂��߂̃p�����[�^��������
        Params.Init();

        // FPS��ݒ�
        SetFps();

        // �𑜓x��ݒ�
        SetResolution();

        // Manager�N���X���p�������N���X��Start�֐������s
        manager.BaseStart();
    }

    void Update()
    {
        // ���b�Z�[�W�����̂��߂̃p�����[�^��������
        Params.Init();

        // Manager�N���X���p�������N���X��Update�֐������s
        manager.BaseUpdate();
    }

    // �V�[�����؂�ւ��ۂɌĂяo�����֐�
    private void Exit()
    {
        Debug.Log("BaseManager Exit");

        // Manager�N���X���p�������N���X��Exit�֐������s
        manager.BaseExit();
    }

    // �e�V�[���ŕK����x���s����BFPS�̐ݒ���s���B
    public void SetFps()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = Constants.SPECIFIED_FPS;
    }

    // �e�V�[���ŕK����x���s����B�𑜓x�̐ݒ���s���B
    public void SetResolution()
    {
        //Screen.SetResolution(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, true);
    }

    // Param�Ɋi�[���ꂽ�V�[���������ɁA�V�[����ύX����B
    public void ChangeScene()
    {
        Debug.Log("BaseManager ChangeScene");
    }
}
