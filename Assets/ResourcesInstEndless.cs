using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesInstEndless : MonoBehaviour
{
  public GameObject resource,coin;
  public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(resourcesInst());
        StartCoroutine(coinInst());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator resourcesInst(){

      while(true){


        yield return new WaitForSeconds(10);


        if(player.GetComponent<PlayerControllerEndlessMode>().win!=true && player.GetComponent<PlayerControllerEndlessMode>().die!=true){
          var obj=Instantiate(resource,new Vector3(Random.Range(-1.5f,1.5f),resource.transform.position.y,Random.Range(-1,-6)),resource.transform.rotation) as GameObject;
          obj.GetComponent<someScript>().player=player;
        }
      }
    }

    IEnumerator coinInst(){
      while(true){


        yield return new WaitForSeconds(5);


        if(player.GetComponent<PlayerControllerEndlessMode>().win!=true && player.GetComponent<PlayerControllerEndlessMode>().die!=true){
          var obj2=Instantiate(coin,new Vector3(Random.Range(-1.5f,1.5f),resource.transform.position.y,Random.Range(-1,-6)),coin.transform.rotation) as GameObject;
          obj2.GetComponent<MoneyAddEndless>().player=player;
        }
      }
    }
}
