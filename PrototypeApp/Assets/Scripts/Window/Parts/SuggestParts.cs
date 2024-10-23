using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuggestParts : MonoBehaviour
{
    private Account account = null;

    [SerializeField] private TextEl textEl = null;
    [SerializeField] private GameObject tappingImageGroup = null;

    public void Create(GameObject accountObj)
    {
        account = accountObj.GetComponent<Account>();
    }

    public void TappingEvent()
    {
        textEl.ShowImages(false, textEl.defImageGroup.name);
        textEl.ShowImages(true, tappingImageGroup.name);
    }

    public void UnTappingEvent()
    {
        textEl.ShowImages(false, tappingImageGroup.name);
        textEl.ShowImages(true, textEl.defImageGroup.name);
    }

    public void TappedEvent()
    {
        Params.msg = Constants.MSG_CHANGE_SCENE;
        Params.floPar = account.ID;
    }
}
