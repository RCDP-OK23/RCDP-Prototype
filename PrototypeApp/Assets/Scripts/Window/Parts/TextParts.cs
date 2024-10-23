using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextParts : MonoBehaviour
{
    // �e�L�X�g���^�b�v���ꂽ�Ƃ��Ɏ��s�����C�x���g
    public UnityEvent<string> tappedEvent = null;

    // �e�L�X�g�̗v�f���擾
    [SerializeField] private TextEl textEl = null;

    // �^�b�v���̉摜�A�e�L�X�g�O���[�v
    [SerializeField] private GameObject tappingImageGroup = null;
    [SerializeField] private GameObject tappingText = null;

    public void TappingEvent()
    {
        textEl.ShowImages(false, textEl.defImageGroup.name);
        textEl.ShowText(false, textEl.defText.name);

        textEl.ShowImages(true, tappingImageGroup.name);
        textEl.ShowText(true, tappingText.name);
    }

    public void UnTappingEvent()
    {
        textEl.ShowImages(false, tappingImageGroup.name);
        textEl.ShowText(false, tappingText.name);

        textEl.ShowImages(true, textEl.defImageGroup.name);
        textEl.ShowText(true, textEl.defText.name);
    }

    public void TappedEvent()
    {
        tappedEvent.Invoke("");
    }
}
