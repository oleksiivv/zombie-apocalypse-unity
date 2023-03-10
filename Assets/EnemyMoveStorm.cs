using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveStorm : MonoBehaviour
{
  public static float speed=2;
  private int localSpeed=1;
  public static int dir=1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      transform.Translate(Vector3.forward*PlayerOceanRun.speed/3.6f);

      if(transform.position.z<=-13){
        Instantiate(gameObject,new Vector3(-0.55f,2f,Random.Range(38f,42f)),gameObject.transform.rotation);
        Destroy(gameObject);
      }


      //transform.Translate(Vector3.forward*speed*localSpeed*dir*Time.timeScale/8);
        if(transform.position.z<=-55){
          //Instantiate(gameObject,new Vector3(0,gameObject.transform.position.y,transform.position.z+transform.localScale.z*4),gameObject.transform.rotation);
          Destroy(gameObject);
          if(speed<18)speed+=0.005f;
        }
        if(localSpeed==1 && speed==-1){
          transform.rotation=new Quaternion(0,0,0,0);
          if(transform.position.z>55)Destroy(gameObject);
        }

        if(PlayerFlappy.decSpeed==0){
          //speed=-1;
          //dir=-1;
          //other.gameObject.GetComponent<Animator>().SetBool("Run",false);
          //other.gameObject.GetComponent<Animator>().SetBool("Attacked",true);
        }
    }

    void OnCollisionEnter(Collision other){
      if(other.gameObject.name=="Player"){
        localSpeed=0;
        gameObject.GetComponent<Animator>().SetBool("Attacks",true);

        other.gameObject.GetComponent<Animator>().SetBool("Run",false);
        other.gameObject.GetComponent<Animator>().SetBool("Attacked",true);


      }
    }
}
