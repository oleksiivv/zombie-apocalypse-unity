using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInst : MonoBehaviour
{

  public GameObject coinPrephab;
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(coins());

    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator coins(){
      while(true){

        Instantiate(coinPrephab,new Vector3(0,coinPrephab.transform.position.y,60),coinPrephab.transform.rotation);
        yield return new WaitForSeconds(Random.Range(5f,15f));
      }
    }
}
