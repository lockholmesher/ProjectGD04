using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : SingletionMonoBehaviour<AdsManager>
{
   
    public bool isShowingADS = false;
    public int type;
    
#if UNITY_IOS
   private string unityadsID = "3311814";
#elif UNITY_ANDROID
    private string unityadsID = "3311815";
#endif
    void Start()
    {
        Advertisement.Initialize(unityadsID, true);
        isShowingADS = false;
    }

    public void ShowAds(int type)
    {
        ShowUnityAds();
    }
    public void ShowUnityAds()
    {
        ShowOptions show = new ShowOptions
        {
            resultCallback = HandelCallback
        };
        if( Advertisement.IsReady())
        {
            
            Advertisement.Show(null, show);
        }
        isShowingADS = true;

    }

    void HandelCallback(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished :
                Debug.Log("finish");
                break;
            case ShowResult.Failed :
                break;
            case ShowResult.Skipped :
                Debug.Log("Skip");
                break;
        }
        isShowingADS = false;

    }

    void RewardAfterVideoFinish()
    {
        // dosomething 
        switch (type)
        {
            case 1:
                break;
        }

    }

}
