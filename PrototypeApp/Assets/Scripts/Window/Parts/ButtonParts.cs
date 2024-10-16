using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonParts : MonoBehaviour
{
    // �{�^�����^�b�v���ꂽ�Ƃ��Ɏ��s�����C�x���g
    public UnityEvent tappedEvent = null;

    // �{�^���̗v�f���擾
    [SerializeField] private ButtonEl buttonEl = null;

    // �^�b�v���̉摜�O���[�v
    [SerializeField] private GameObject tappingImageGroup = null;

    public void TappingEvent()
    {
        // �{�^���̉摜��ύX
        buttonEl.ShowImages(false, buttonEl.defImageGroup.name);
        buttonEl.ShowImages(true, tappingImageGroup.name);
    }

    public void UnTappingEvent()
    {
        // �{�^���̉摜��߂�
        buttonEl.ShowImages(false, tappingImageGroup.name);
        buttonEl.ShowImages(true, buttonEl.defImageGroup.name);
    }

    public void TappedEvent()
    {
        tappedEvent.Invoke();
    }
}
