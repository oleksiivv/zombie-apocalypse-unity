using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillUpdate : MonoBehaviour
{
  public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
      Invoke("cleanObj",3);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void cleanObj(){
      gameObject.GetComponent<BoxCollider>().enabled=false;
      Invoke("clean",10);
    }

    void clean(){
        Destroy(gameObject);
    }

    void OnMouseDown(){
      if(player.GetComponent<PlayerController>().win!=true && player.GetComponent<PlayerController>().die!=true){
      player.GetComponent<PlayerController>().updateHealth();
      Destroy(gameObject);
    }
    }

    void OnCollisionEnter(Collision other){
      if(other.gameObject.tag=="Player"){
        Destroy(gameObject);
      }
    }
}
