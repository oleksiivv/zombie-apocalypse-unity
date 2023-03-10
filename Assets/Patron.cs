using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

      if(gameObject.name=="patron_2")Invoke("cleanObj",0.1f);

      if(PlayerPrefs.GetInt("mutedEffects")==1){
        gameObject.GetComponent<AudioSource>().enabled=false;
      }
      else{
        gameObject.GetComponent<AudioSource>().enabled=true;
      }

    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.forward/5);

    }

    void cleanObj(){
      Destroy(gameObject);
    }
}
