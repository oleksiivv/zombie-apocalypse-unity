using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControllerEndlessMode : MonoBehaviour
{
  public GameObject gun,character;
  public GameObject[] particles;

  public Text headCnt,pauseHeadCnt,hi,pauseHi;
  public int iHeadCnt=0;

  float iHealth=100f;

  public Slider health;

  public bool die=false,win=false;

  public GameObject winText,dieText, buttonHome,buttonRestart,buttonShoot,jstick;

  public GameObject fire;
  public GameObject bazookaEffects;
  public GameObject[] blaster1Eff;


    // Start is called before the first frame update
    void Start()
    {
      if(PlayerPrefs.GetInt("gameControl")==1){
        buttonShoot.SetActive(false);
        jstick.SetActive(false);
      }
      else{
        buttonShoot.SetActive(true);
        jstick.SetActive(true);
      }


    }

    bool once=false;

    // Update is called once per frame
    void Update()
    {
        //transform.rotation=new Quaternion(0,transform.rotation.y,0,0);

        if(iHealth<=0.1f && !once){
          die=true;
          once=true;
          restart();

        }

        if(iHeadCnt>PlayerPrefs.GetInt("hi")){
          PlayerPrefs.SetInt("hi",iHeadCnt);
        }

        hi.GetComponent<Text>().text="Best: "+PlayerPrefs.GetInt("hi").ToString();
        pauseHi.GetComponent<Text>().text="Best: "+PlayerPrefs.GetInt("hi").ToString();

        headCnt.GetComponent<Text>().text="Score: "+iHeadCnt.ToString();
        pauseHeadCnt.GetComponent<Text>().text=iHeadCnt.ToString()+"/100";

        money.GetComponent<Text>().text=PlayerPrefs.GetInt("money").ToString();



    }


    public GameObject[] patronPrephab;


    public void shoot(){
      if(die==false && win==false){

      //if(PlayerPrefs.GetInt("gameControl")!=1){

      //}
      if(PlayerPrefs.GetInt("currentBlaster")==0){
        foreach(var a in particles){
          a.SetActive(true);
        }
        Instantiate(patronPrephab[PlayerPrefs.GetInt("currentBlaster")],gun.transform.position,transform.rotation);
        GetComponent<AudioSource>().Play();
        Invoke("offParticles",1);
      }
      else if(PlayerPrefs.GetInt("currentBlaster")==1){
        //blaster1Eff.SetActive(false);
        foreach(var a in blaster1Eff){
          a.SetActive(true);
        }
        patronPrephab[PlayerPrefs.GetInt("currentBlaster")].GetComponent<AudioSource>().Play();
        Instantiate(patronPrephab[PlayerPrefs.GetInt("currentBlaster")],gun.transform.position,transform.rotation);
        //GetComponent<AudioSource>().Play();
        Invoke("offParticles",0.5f);
      }


      else if(PlayerPrefs.GetInt("currentBlaster")==2){
        fire.SetActive(false);
        fire.SetActive(true);
        Invoke("offParticles",1.5f);
        patronPrephab[PlayerPrefs.GetInt("currentBlaster")].GetComponent<AudioSource>().Play();
        Instantiate(patronPrephab[PlayerPrefs.GetInt("currentBlaster")],gun.transform.position,transform.rotation);
      }
      else if(PlayerPrefs.GetInt("currentBlaster")==3){
        bazookaEffects.SetActive(false);
        bazookaEffects.SetActive(true);
        Invoke("offParticles",8f);
        patronPrephab[PlayerPrefs.GetInt("currentBlaster")].GetComponent<AudioSource>().Play();
        Instantiate(patronPrephab[PlayerPrefs.GetInt("currentBlaster")],gun.transform.position,transform.rotation);
      }
      //iHeadCnt++;
      headCnt.GetComponent<Text>().text="Score: "+iHeadCnt.ToString();
      pauseHeadCnt.GetComponent<Text>().text=iHeadCnt.ToString()+"/100";


      if(iHeadCnt>PlayerPrefs.GetInt("hi")){
        PlayerPrefs.SetInt("hi",iHeadCnt);
      }





    }
    }


    public void lowerhealth(){
      if(character.GetComponent<Animator>().GetBool("Attacked")==false  && !win &&!die)character.GetComponent<Animator>().SetBool("Attacked",true);
      if(!IsInvoking("offAnim"))Invoke("offAnim",1);
      iHealth-=0.8f;
      health.value=iHealth;
    }

    public void offParticles(){
      foreach(var a in particles){
        a.SetActive(false);
      }
      foreach(var a in blaster1Eff){
        a.SetActive(false);
      }
      fire.SetActive(false);
      bazookaEffects.SetActive(false);
      //blaster1Eff.SetActive(false);
    }

    void offAnim(){
      character.GetComponent<Animator>().SetBool("Attacked",false);
    }

    void restart(){
      GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
      //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
      //GetComponent<BoxCollider>().enabled=false;
      gameObject.isStatic=true;
      transform.position=new Vector3(transform.position.x,-0.38f,transform.position.z);
      //GetComponent<BoxCollider>().enabled=false;
      //GetComponent<Rigidbody>().useGravity=false;
      transform.Rotate(-90,0,0);
      dieText.SetActive(true);
      buttonRestart.SetActive(true);
      buttonHome.SetActive(true);
      //Defence.zombieMove=false;
      //Time.timeScale=0;
      GetComponent<BoxCollider>().enabled=false;
      GetComponent<Rigidbody>().useGravity=false;
      if(iHeadCnt>PlayerPrefs.GetInt("hi")){
        PlayerPrefs.SetInt("hi",iHeadCnt);
      }
    }

    void winning(){
      winText.SetActive(true);
      buttonHome.SetActive(true);
      buttonRestart.SetActive(true);
    }


    public void loadScene(int id){

      if(iHeadCnt>PlayerPrefs.GetInt("hi")){
        PlayerPrefs.SetInt("hi",iHeadCnt);
      }
      Application.LoadLevel(id);
    }

   public GameObject healthUpdateEffect;
   public Text money;

    public void updateHealth(){
      iHealth+=25;
      healthUpdateEffect.SetActive(true);
      Invoke("healthUpdateEffectOff",3f);
    }

    void healthUpdateEffectOff(){
      healthUpdateEffect.SetActive(false);
    }

    public void addMoney(){
      money.GetComponent<Text>().text=PlayerPrefs.GetInt("money").ToString();
      PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")+10);
    }
}
