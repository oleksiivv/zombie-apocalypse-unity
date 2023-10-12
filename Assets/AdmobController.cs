using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class AdmobController : MonoBehaviour
{
    private InterstitialAd intersitional;
    private BannerView banner;

#if UNITY_IOS
    private string appId="ca-app-pub-4962234576866611~8935289308";
    //public string intersitionalId="ca-app-pub-4962234576866611/4595485396";
    private string bannerId="ca-app-pub-4962234576866611/4595485396";
#else
    private string appId="ca-app-pub-4962234576866611~3768162882";
    //public string intersitionalId="ca-app-pub-4962234576866611/1677809250";
    private string bannerId="ca-app-pub-4962234576866611/3385019504";
#endif

}
