using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieInst : MonoBehaviour
{
  public GameObject zombiePreph;
    // Start is called before the first frame update
    void Start()
    {

      StartCoroutine(zombie());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator zombie(){
      while(true){
        Instantiate(zombiePreph,new Vector3(0,-2.77f,60),zombiePreph.transform.rotation);

        yield return new WaitForSeconds(Random.Range(0.6f,2.5f));
      }
    }
}
