﻿using System.Collections;
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
        MobileAds.Initialize(initStatus => { });

      RequestConfigurationAd();

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
      if(id!=Application.loadedLevel){
        showIntersitionalAd();
      }
      Time.timeScale=1;
      StartCoroutine(loadAsync(id));
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


    private InterstitialAd intersitional;
    private BannerView banner;

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


      void RequestConfigurationAd(){
          intersitional=new InterstitialAd(intersitionalId);
          AdRequest request=AdRequestBuild();
          intersitional.LoadAd(request);

          intersitional.OnAdLoaded+=this.HandleOnAdLoaded;
          intersitional.OnAdOpening+=this.HandleOnAdOpening;
          intersitional.OnAdClosed+=this.HandleOnAdClosed;

      }


      public bool showIntersitionalAd(){
          if(intersitional.IsLoaded()){
              intersitional.Show();

              return true;
          }

          return false;
      }

      private void OnDestroy(){
          DestroyIntersitional();

          intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
          intersitional.OnAdOpening-=this.HandleOnAdOpening;
          intersitional.OnAdClosed-=this.HandleOnAdClosed;

      }

      private void HandleOnAdClosed(object sender, EventArgs e)
      {
          intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
          intersitional.OnAdOpening-=this.HandleOnAdOpening;
          intersitional.OnAdClosed-=this.HandleOnAdClosed;

            RequestConfigurationAd();

        
      }

      private void HandleOnAdOpening(object sender, EventArgs e)
    {
        
    }

    private void HandleOnAdLoaded(object sender, EventArgs e)
    {
        
    }

     public void DestroyIntersitional(){
         intersitional.Destroy();
     }

}
