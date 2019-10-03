using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : SingletionMonoBehaviour<GamePlayController>
{
    
    public UIListColor IListColor;

    [SerializeField]
    private UIButton btnWatchAds;

	void Start()
    {
        btnWatchAds.SetUpEvent(ClickAds);
    }
    public void ClickAds()
    {
        Debug.Log("click");
        AdsManager.Instance.ShowAds(3);
    }

    
}
