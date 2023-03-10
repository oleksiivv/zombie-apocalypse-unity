using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieInstFlappy : MonoBehaviour
{
  public GameObject zombiePreph,tube,score;
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
        var obj=Instantiate(zombiePreph,new Vector3(0,-2.77f,60),zombiePreph.transform.rotation) as GameObject;
        Instantiate(tube,new Vector3(0,27.15f,60),tube.transform.rotation);
        Instantiate(score,new Vector3(0,score.transform.position.y,60),score.transform.rotation);

        float size=Random.Range(4f,5.6f);
        obj.transform.localScale=new Vector3(size,size,size);

        yield return new WaitForSeconds(Random.Range(1f,2.5f));
      }
    }
}
