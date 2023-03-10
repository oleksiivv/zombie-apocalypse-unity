using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public GameObject[] soundHolder,musicHolder;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(PlayerPrefs.GetInt("mutedEffects")==0){
        foreach(var a in soundHolder){
          a.GetComponent<AudioSource>().enabled=true;
        }
      }
      else{
        foreach(var a in soundHolder){
          a.GetComponent<AudioSource>().enabled=false;
        }
      }


      if(PlayerPrefs.GetInt("mutedMusic")==0){
        foreach(var a in musicHolder){
          a.GetComponent<AudioSource>().enabled=true;
        }
      }
      else{
        foreach(var a in musicHolder){
          a.GetComponent<AudioSource>().enabled=false;
        }
      }

    }
}
