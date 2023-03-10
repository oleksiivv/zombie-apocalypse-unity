using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellarLight : MonoBehaviour
{

  public GameObject lightSource;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(lightBlip());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator lightBlip(){
      while(true){


        lightSource.SetActive(!lightSource.activeSelf);
        yield return new WaitForSeconds(0.03f);
      }
    }
}
