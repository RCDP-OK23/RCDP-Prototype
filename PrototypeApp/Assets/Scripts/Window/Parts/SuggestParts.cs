using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuggestParts : MonoBehaviour
{
    [SerializeField] public GameObject accountObj = null;
    [SerializeField] private GameObject deviceObj;

    [SerializeField] private TextEl textEl = null;
    [SerializeField] private GameObject tappingImageGroup = null;

    [SerializeField] private List<Vector3> suggestPos;

    private bool isShow = false;

    public void ShowSuggest(ref int suggestCount, int maxSuggestCount)
    {
        if (suggestCount == maxSuggestCount || isShow) return;

        isShow = true;
        textEl.ShowImages(true, textEl.defImageGroup.name);
        textEl.ShowText(true, textEl.defText.name);

        textEl.TransObjPos(suggestPos[suggestCount]);
        suggestCount++;
    }

    public void TransPosSuggest(ref int suggestCount, int maxSuggestCount)
    {
        if (suggestCount == maxSuggestCount) return;

        textEl.TransObjPos(suggestPos[suggestCount]);
        suggestCount++;
    }

    public void CloseSuggest(ref int suggestCount)
    {
        if (!isShow) return;

        isShow = false;
        textEl.ShowImages(false, textEl.defImageGroup.name);
        textEl.ShowText(false, textEl.defText.name);

        suggestCount--;
    }

    public void CloseSuggest()
    {
        isShow = false;
        textEl.ShowImages(false, textEl.defImageGroup.name);
        textEl.ShowText(false, textEl.defText.name);
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
        Params.strPar = Constants.SCENE_DETAIL;

        Params.strPar2 = deviceObj.name;
        Params.floPar = accountObj.GetComponent<Account>().ID;
    }
}
