using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateBox : MonoBehaviour
{
      void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void rate(){


      Application.OpenURL("https://play.google.com/store/apps/details?id=com.VertexStudio.WalkingDead");
      PlayerPrefs.SetInt("rated",1);
      gameObject.SetActive(false);



    }

    public void remindLater(){
      Menu.remindCnt=4;
      gameObject.SetActive(false);


    }

    public void remindNewer(){
      PlayerPrefs.SetInt("rated",1);
      gameObject.SetActive(false);

    }
}
