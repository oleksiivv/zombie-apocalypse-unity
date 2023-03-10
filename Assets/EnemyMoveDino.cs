using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveDino : MonoBehaviour
{
  public static float speed=2;
  private int localSpeed=1;
  public static int dir=1;
    // Start is called before the first frame update
    void Start()
    {
        //speed=1f;
    }

    // Update is called once per frame
    void Update()
    {
      if(Application.loadedLevel==17)transform.Translate(Vector3.forward*speed*localSpeed*dir*Time.timeScale/12);
      else transform.Translate(Vector3.forward*speed*localSpeed*dir*Time.timeScale/8);
        if(transform.position.z<=-55){
          //Instantiate(gameObject,new Vector3(0,gameObject.transform.position.y,transform.position.z+transform.localScale.z*4),gameObject.transform.rotation);
          if(speed<18)speed+=0.005f;

          Destroy(gameObject);

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
        speed=-1;
        dir=-1;
        other.gameObject.GetComponent<Animator>().SetBool("Run",false);
        other.gameObject.GetComponent<Animator>().SetBool("Attacked",true);


      }
    }
}
