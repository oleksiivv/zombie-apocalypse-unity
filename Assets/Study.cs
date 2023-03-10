using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study : MonoBehaviour
{
  public GameObject studyWithButtons,studyTap;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(PlayerPrefs.GetInt("gameControl")==0){
        studyWithButtons.SetActive(true);
        studyTap.SetActive(false);
      }
      else{
        studyTap.SetActive(true);
        studyWithButtons.SetActive(false);
      }

    }
}
