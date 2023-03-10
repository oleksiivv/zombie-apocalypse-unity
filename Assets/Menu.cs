using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
  public GameObject levelPanel,endlessLevelsPanel;

  public Text hiShooter,hiDino,hiFlappy,hiStorm,money;
  public static int remindCnt=0;

  public GameObject rateIt;
    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale=1;
      //for(int i=0;i<11;i++){
        //PlayerPrefs.SetInt("Completed"+i.ToString(),1);
      //}

      endlessLevelsPanel.SetActive(false);
      levelPanel.SetActive(false);

      if(remindCnt==3 && PlayerPrefs.GetInt("rated")==0){

        rateIt.SetActive(true);

      }
      else{
        rateIt.SetActive(false);

      }
      remindCnt++;

    }

    // Update is called once per frame
    void Update()
    {
      hiShooter.GetComponent<Text>().text="Best: "+PlayerPrefs.GetInt("hi").ToString();
      hiDino.GetComponent<Text>().text="Best: "+PlayerPrefs.GetInt("BestDino").ToString();
      hiFlappy.GetComponent<Text>().text="Best: "+PlayerPrefs.GetInt("BestFlappy").ToString();
      hiStorm.GetComponent<Text>().text="Best: "+PlayerPrefs.GetInt("BestStorm").ToString();

      money.GetComponent<Text>().text=PlayerPrefs.GetInt("money").ToString();

    }

    public void levelPanelOn(){
      //GetComponent<AudioSource>().Play();
      levelPanel.SetActive(true);
    }





    public void levelPanelOff(){

      levelPanel.SetActive(false);
    }



    public void endlessPanelOn(){
      //GetComponent<AudioSource>().Play();
      endlessLevelsPanel.SetActive(true);
    }





    public void endlessPanelOff(){

      endlessLevelsPanel.SetActive(false);
    }

    public GameObject loadingPanel;//panel which is showed while sceneLoading
    public Slider loadingSlider;//slider that shows the progress of loading


    //call this when need to load scene
    public void openScene(int id){
      StartCoroutine(loadAsync(id));
    }

    public void openLevel(int id){
      if(id==0){
        StartCoroutine(loadAsync(1));
      }
      else{
        if(PlayerPrefs.GetInt("Completed"+(id-1).ToString())==1){
          StartCoroutine(loadAsync(id+4));
        }
      }
    }


    IEnumerator loadAsync(int id)
    {
        AsyncOperation operation = Application.LoadLevelAsync(id);
        loadingPanel.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;
            yield return null;

        }
    }
}
