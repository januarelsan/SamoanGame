using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAdsManager : Singleton<ShowAdsManager>
{

    [SerializeField] private GoogleAdMobController adsController;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneController.Instance.getSceneLoaded() == "Home"){
            adsController.RequestBannerAd();
        }

        if(SceneController.Instance.getSceneLoaded() == "YoutubeGallery"){
            adsController.RequestBannerAd();
        }
    }

    public void RequestAndLoadInterstitialAd(){
        adsController.DestroyInterstitialAd();
        adsController.RequestAndLoadInterstitialAd();
    }

    public void ShowInterstitialAd(){
        adsController.ShowInterstitialAd();
    }

    public void DestroyAllAds(){
        adsController.DestroyInterstitialAd();
        adsController.DestroyBannerAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
