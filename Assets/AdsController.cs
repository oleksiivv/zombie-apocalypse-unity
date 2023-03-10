using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsController : MonoBehaviour
{
  public string appId="3887151";
    // Start is called before the first frame update
    void Start()
    {

      Advertisement.Initialize(appId,false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void watchAdd(){
      ShowOptions options = new ShowOptions();
      options.resultCallback = AdCallbackHandler;
      if(Advertisement.IsReady("rewardedVideo")){
        Advertisement.Show("rewardedVideo",options);
      }
    }








    void AdCallbackHandler(ShowResult res)
    {
        if (res == ShowResult.Finished)
        {
          PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")+30);
          //gameObject.GetComponent<AudioSource>().Play();

        }
        else if (res == ShowResult.Skipped)
        {
            Debug.Log("skipped");
        }
        else if (res == ShowResult.Skipped)
        {
            Debug.Log("error");
        }
    }
}
