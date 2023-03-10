using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
  public GameObject mutedEff,unmutedEff,mutedMus,unmutedMus;

  public GameObject[] gameControls;
  public GameObject[] arrows;
    // Start is called before the first frame update
    void Start()
    {
      currentControlUpdate();

    }

    // Update is called once per frame
    void Update()
    {



      if(PlayerPrefs.GetInt("mutedEffects")==0){
        mutedEff.SetActive(false);
        unmutedEff.SetActive(true);
      }
      else{
        mutedEff.SetActive(!false);
        unmutedEff.SetActive(!true);
      }


      if(PlayerPrefs.GetInt("mutedMusic")==0){
        mutedMus.SetActive(false);
        unmutedMus.SetActive(true);
      }
      else{
        mutedMus.SetActive(!false);
        unmutedMus.SetActive(!true);
      }




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

    public void openScene(int id){
      StartCoroutine(loadAsync(id));
    }


    public void muteEffects(){
      PlayerPrefs.SetInt("mutedEffects",1);
    }
    public void unmuteEffects(){
      PlayerPrefs.SetInt("mutedEffects",0);
    }

    public void muteMusic(){
      PlayerPrefs.SetInt("mutedMusic",1);
    }

    public void unmuteMusic(){
      PlayerPrefs.SetInt("mutedMusic",0);
    }



    public void chooseControl(int id){
      PlayerPrefs.SetInt("gameControl",id);
      currentControlUpdate();
    }

    public void currentControlUpdate(){
      for(int i=0;i<gameControls.Length;i++){

        if(i==PlayerPrefs.GetInt("gameControl")){
          gameControls[i].GetComponent<Image>().color=new Color32(158,226,110,255);
          arrows[i].SetActive(true);
        }
        else{
          gameControls[i].GetComponent<Image>().color=new Color32(255,255,255,255);
          arrows[i].SetActive(false);
        }

    }
    }


    public void undoProgress(){
      gameObject.GetComponent<AudioSource>().Play();
      PlayerPrefs.DeleteAll();
      PlayerPrefs.SetInt("studied",1);
    }


}
