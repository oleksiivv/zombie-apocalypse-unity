using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WepoonChooseController : MonoBehaviour
{
  public GameObject[] blasterChooseButton;
  public GameObject[] blasterImg;

  public GameObject[] blaster;


    // Start is called before the first frame update
    void Start()
    {
      //PlayerPrefs.SetInt("blaster_n1",1);
      //PlayerPrefs.SetInt("blaster_n2",1);
      //PlayerPrefs.SetInt("blaster_n3",1);
      for(int i=1;i<blasterImg.Length;i++){
        if(PlayerPrefs.GetInt("blaster_n"+i.ToString())==0){
          blasterImg[i].SetActive(false);
        }
      }

    }

    // Update is called once per frame
    void Update()
    {

      for(int i=0;i<blaster.Length;i++){
        if(PlayerPrefs.GetInt("currentBlaster")==i){
          offAllBlaster();
          blaster[i].SetActive(true);
        }
      }

      

    }

    public void chooseBlaster(int id){
      if(PlayerPrefs.GetInt("blaster_n"+id.ToString())==1){
        PlayerPrefs.SetInt("currentBlaster",id);
      }
      if(id==0){
        PlayerPrefs.SetInt("currentBlaster",0);
      }
    }

    void offAllBlaster(){
      for(int i=0;i<blaster.Length;i++){
        blaster[i].SetActive(false);
      }
    }
}
