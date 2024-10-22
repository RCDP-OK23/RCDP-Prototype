using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputBoxParts : MonoBehaviour
{
    // �e�L�X�g���^�b�v���ꂽ�Ƃ��Ɏ��s�����C�x���g
    public UnityEvent tappedEvent = null;

    // �e�L�X�g�̗v�f���擾
    [SerializeField] private InputBoxEl inputBoxEl = null;

    // �^�b�v���̉摜�A�e�L�X�g�O���[�v
    [SerializeField] private GameObject typingImageGroup = null;

    private bool isTyping = false;

    public void TappedEvent()
    {
        inputBoxEl.ShowImages(false, inputBoxEl.defImageGroup.name);
        inputBoxEl.ShowImages(true, typingImageGroup.name);

        tappedEvent.Invoke();
    }
}
