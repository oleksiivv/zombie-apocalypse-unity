using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour
{
  public GameObject player;
  bool zombieMove=true;
  public int speed=1;
    // Start is called before the first frame update
    void Start()
    {
      zombieMove=true;

    }
    Vector3 newDir;

    // Update is called once per frame
    void Update()
    {


      if(zombieMove){
      if(player.GetComponent<PlayerController>().win==false  && player.GetComponent<PlayerController>().die==false){

        newDir = Vector3.RotateTowards(transform.forward, (player.transform.position - transform.position), 1, 0.0F);

        //if(gameObject.isStatic!=true)transform.position = Vector3.MoveTowards(transform.position,pl.transform.position,0.06f*speed*Time.timeScale);
        transform.rotation = Quaternion.LookRotation(newDir);
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position,0.06f*Time.timeScale/8);

      }

      else{

        newDir = Vector3.RotateTowards(transform.forward, (new Vector3(-0.08f,transform.position.y,-20.14f) - transform.position), 1, 0.0F);

        //if(gameObject.isStatic!=true)transform.position = Vector3.MoveTowards(transform.position,pl.transform.position,0.06f*speed*Time.timeScale);
        transform.rotation = Quaternion.LookRotation(newDir);


        transform.position = Vector3.MoveTowards(transform.position,new Vector3(-0.08f,transform.position.y,-20.14f),speed*0.06f*Time.timeScale/8);
      }
    }
      if(player.GetComponent<PlayerController>().win==true){
        GetComponent<Animator>().SetBool("Dead",true);
        Invoke("zombieFall",1);
        zombieMove=false;
      }


      if(transform.position.y<-3){

        Destroy(gameObject);
      }
      if(player.GetComponent<PlayerController>().win==true || player.GetComponent<PlayerController>().die==true){
        GetComponent<Animator>().SetBool("Attacks",false);
      }

    }

    void OnMouseDown(){
      if(PlayerPrefs.GetInt("gameControl")==1){

        if(zombieMove){
          //Rotating.worldPosition=transform.position;
          //Rotating.move=false;

          if(player.GetComponent<PlayerController>().shoot()){
            dieZombie();
          }
        }
        zombieMove=false;

        //player.GetComponent<PlayerController>().iPatronCnt--;
      }
    }




    void dieZombie(){
      if(Time.timeScale==1 && player.GetComponent<PlayerController>().win!=true && player.GetComponent<PlayerController>().die!=true){
      Rotating.worldPosition=transform.position;
      Rotating.move=false;
      Debug.Log("pipicka");
      if(zombieMove)player.GetComponent<PlayerController>().iHeadCnt++;


      //player.transform.LookAt(transform.position,new Vector3(0,1,0)); // rotate the transform around y axis

      //Vector3 newDir = Vector3.RotateTowards(transform.forward, (transform.position - player.transform.position), 1, 0.0F);


      /*Vector3 direction = (transform.position - player.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, lookRotation, 10f );*/


      if(player.GetComponent<PlayerController>().die==false && player.GetComponent<PlayerController>().win==false && PlayerPrefs.GetInt("gameControl")==1)player.transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position,new Vector3(0,1,0));

      GetComponent<Animator>().SetBool("Dead",true);
      Invoke("zombieFall",1);
      //Invoke("moveTrue",0.4f);

      //if(zombieMove)player.GetComponent<PlayerController>().shoot();
      //zombieMove=false;

    }
    }





    void moveTrue(){
      Rotating.move=true;
    }

    void zombieFall(){
      //GetComponent<Rigidbody>().useGravity=false;
      GetComponent<BoxCollider>().enabled=false;
      Invoke("zombieClean",2);
    }

    void zombieClean(){
      Destroy(gameObject);
    }


    public void OnCollisionEnter(Collision other){
      if(other.gameObject.tag=="Player"){
        if(player.GetComponent<PlayerController>().win!=true &&  player.GetComponent<PlayerController>().die!=true )
        {

          GetComponent<Animator>().SetBool("Attacks",true);

        }

      }


    }


    public void OnCollisionStay(Collision other){
      if(other.gameObject.tag=="Player"){

        player.GetComponent<PlayerController>().lowerhealth();
        //player.GetComponent<Rigidbody>().AddForce(Vector3.forward*100);
      }

    }



    public void OnCollisionExit(Collision other){
      if(other.gameObject.tag=="Player"){
        GetComponent<Animator>().SetBool("Attacks",false);
      }
    }


    void OnTriggerEnter(Collider other){

        if(zombieMove){
          if(other.gameObject.tag=="patron")Destroy(other.gameObject);
          //


          if(Time.timeScale==1 && player.GetComponent<PlayerController>().win!=true && player.GetComponent<PlayerController>().die!=true){
          Debug.Log("pipicka");
          if(zombieMove)player.GetComponent<PlayerController>().iHeadCnt++;

          if(player.GetComponent<PlayerController>().die==false && player.GetComponent<PlayerController>().win==false && PlayerPrefs.GetInt("gameControl")==1)player.transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position,new Vector3(0,1,0));

          GetComponent<Animator>().SetBool("Dead",true);
          Invoke("zombieFall",1);


        }



          //
          zombieMove=false;

      }
    }
























}
