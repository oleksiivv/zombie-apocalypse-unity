using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorInst : MonoBehaviour
{
  public GameObject[] decor;
    // Start is called before the first frame update
    void Start()
    {

      StartCoroutine(decorInstCoroutine());

    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator decorInstCoroutine(){
      while(true){
        int id=Random.Range(0,decor.Length);
        Instantiate(decor[id],decor[id].transform.position,decor[id].transform.rotation);
        yield return new WaitForSeconds(0.4f);
      }
    }
}
