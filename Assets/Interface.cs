using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;
using System;

public class Interface : MonoBehaviour
{

  public GameObject pausePanel;

#if UNITY_IOS
  private string appId="3887150";
#else
  private string appId="3887151";
#endif
    // Start is called before the first frame update
    void Start()
    {
      Advertisement.Initialize(appId,false);

      RequestConfiguration requestConfiguration =
          new RequestConfiguration.Builder()
          .SetSameAppKeyEnabled(true).build();
      MobileAds.SetRequestConfiguration(requestConfiguration);

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => {
          LoadLoadInterstitialAd();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pause(){

      Time.timeScale=0;
      pausePanel.SetActive(true);
    }

    public void resume(){
      Time.timeScale=1;
      pausePanel.SetActive(false);
    }

    public void openScene(int id){
      //if(id!=Application.loadedLevel){
      //}
      Time.timeScale=1;
      StartCoroutine(loadAsync(id));

      showIntersitionalAd();
    }

    public GameObject loadScene;
    public Slider loadSl;
    IEnumerator loadAsync(int id)
    {

        AsyncOperation operation = Application.LoadLevelAsync(id);
        loadScene.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadSl.value = progress;
            yield return null;

        }
    }


#if UNITY_IOS
    private string appIdAdmob="ca-app-pub-4962234576866611~8935289308";
    private string intersitionalId="ca-app-pub-4962234576866611/4595485396";
    private string bannerId="ca-app-pub-4962234576866611/4595485396";
#else
    private string appIdAdmob="ca-app-pub-4962234576866611~3768162882";
    private string intersitionalId="ca-app-pub-4962234576866611/1677809250";
    private string bannerId="ca-app-pub-4962234576866611/3385019504";
#endif

     AdRequest AdRequestBuild(){
         return new AdRequest.Builder().Build();
     }

      public bool showIntersitionalAd(){
          return showIntersitionalGoogleAd();
      }

      private InterstitialAd _interstitialAd;
    
    public void LoadLoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
                _interstitialAd.Destroy();
                _interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        InterstitialAd.Load(intersitionalId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                    "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                            + ad.GetResponseInfo());

                _interstitialAd = ad;
            });
    }


      public bool showIntersitionalGoogleAd(){
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            _interstitialAd.Show();

            return true;
        }
        else
        {
            return false;
        }
      }
}
