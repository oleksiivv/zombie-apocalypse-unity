using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalloweenPumpkins : MonoBehaviour
{
    public GameObject[] pumpkin;

    void Start(){
        StartCoroutine(spawn());
    }


    IEnumerator spawn(){
        while(true){


            yield return new WaitForSeconds(4*Random.Range(0.5f, 2f));
            int n=Random.Range(0,pumpkin.Length);
            var obj=Instantiate(pumpkin[n],new Vector3(Random.Range(-1.5f,1.5f),pumpkin[n].transform.position.y,Random.Range(-1,-6)),pumpkin[n].transform.rotation) as GameObject;
             
        }
      
    }
}
