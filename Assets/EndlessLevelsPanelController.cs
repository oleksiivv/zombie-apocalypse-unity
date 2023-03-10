using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessLevelsPanelController : MonoBehaviour
{
  //  public GameObject[] addictedlevels;
    public GameObject[] hideAddictedLevels;

    public bool halloween;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      for(int i=0;i<hideAddictedLevels.Length;i++){
        if(PlayerPrefs.GetInt("addictedLevel"+i.ToString())==1){
          hideAddictedLevels[i].SetActive(false);
        }
        else{
          hideAddictedLevels[i].SetActive(!halloween);
        }
      }

    }
}
