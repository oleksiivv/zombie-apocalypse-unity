using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstStart : MonoBehaviour
{
  public GameObject[] gameControls;
  public GameObject[] arrows;

  public GameObject panelChoose;
  public GameObject panelStudy;

  public GameObject btnBack;

  public GameObject story;


  public void Start(){
    currentControlUpdate();

    if(PlayerPrefs.GetInt("studied")==0){
      panelStudy.SetActive(false);
      panelChoose.SetActive(true);

      PlayerPrefs.SetInt("studied",1);
    }

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


  public void nextAfterChoose(){
    panelStudy.SetActive(true);
    panelChoose.SetActive(false);
  }


  public void backToChoose(){
    panelStudy.SetActive(false);
    panelChoose.SetActive(true);
  }

  public void startGame(){

    story.SetActive(true);
    panelStudy.SetActive(false);
    panelChoose.SetActive(false);

  }


  public void showInfo(){
    panelStudy.SetActive(true);
    btnBack.SetActive(false);
  }

  public void showStory(){
    story.SetActive(true);
  }
}
