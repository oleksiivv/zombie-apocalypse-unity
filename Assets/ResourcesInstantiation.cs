using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesInstantiation : MonoBehaviour
{
  public GameObject resource,coin,bullet;
  public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(resourcesInst());
        StartCoroutine(coinInst());
        StartCoroutine(bulletsInst());
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator bulletsInst(){

      while(true){

        yield return new WaitForSeconds(7.5f);


        if(player.GetComponent<PlayerController>().win!=true && player.GetComponent<PlayerController>().die!=true){
          var obj=Instantiate(bullet,new Vector3(Random.Range(-1.5f,1.5f),bullet.transform.position.y,Random.Range(-1,-6)),bullet.transform.rotation) as GameObject;
          obj.GetComponent<Bullet>().player=player;
        }




      }



    }

    IEnumerator resourcesInst(){

      while(true){


        yield return new WaitForSeconds(10);


        if(player.GetComponent<PlayerController>().win!=true && player.GetComponent<PlayerController>().die!=true){
          var obj=Instantiate(resource,new Vector3(Random.Range(-1.5f,1.5f),resource.transform.position.y,Random.Range(-1,-6)),resource.transform.rotation) as GameObject;
          obj.GetComponent<HillUpdate>().player=player;
        }
      }
    }

    IEnumerator coinInst(){
      while(true){


        yield return new WaitForSeconds(5);


        if(player.GetComponent<PlayerController>().win!=true && player.GetComponent<PlayerController>().die!=true){
          var obj2=Instantiate(coin,new Vector3(Random.Range(-1.5f,1.5f),resource.transform.position.y,Random.Range(-1,-6)),coin.transform.rotation) as GameObject;
          obj2.GetComponent<moneyAdd>().player=player;
        }
      }
    }
}
