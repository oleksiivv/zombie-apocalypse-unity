using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class AdmobController : MonoBehaviour
{
    private InterstitialAd intersitional;
    private BannerView banner;

    public string appId="ca-app-pub-4962234576866611~3768162882";
    //public string intersitionalId="ca-app-pub-4962234576866611/1826596101";

    public string bannerId="ca-app-pub-4962234576866611/3385019504";
    
    void Start(){
        MobileAds.Initialize(appId);
        //RequestBannerAd();
        //RequestConfigurationAd();
        
    }

    //baner

    public void RequestBannerAd(){
        banner=new BannerView(bannerId,AdSize.Banner,AdPosition.Bottom);
        AdRequest request = AdRequestBannerBuild();
        banner.LoadAd(request);
    }

    public void DestroyBanner(){
        if(banner!=null){
            banner.Destroy();
        }
    }



    AdRequest AdRequestBannerBuild(){
        return new AdRequest.Builder().Build();
    }
}
