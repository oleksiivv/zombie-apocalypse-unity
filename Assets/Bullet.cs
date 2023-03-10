using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

  public GameObject player;

    void Start()
    {
      Invoke("cleanObj",3);

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
        player.GetComponent<PlayerController>().addBullets();
        gameObject.GetComponent<MeshRenderer>().enabled=false;
        gameObject.GetComponent<AudioSource>().Play();
        Invoke("clean",10);
      }
    }

    void OnCollisionEnter(Collision other){
      if(other.gameObject.tag=="Player"){
        Destroy(gameObject);
      }
    }
}
