using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

  public GameObject gun,character;
  public GameObject[] particles;

  public GameObject healthUpdateEffect;

  public Text headCnt,pauseHeadCnt,money,hiCurrentLevel;
  public int iHeadCnt=0;

  float iHealth=100f;
  public int headMaxNum=100;

  public Slider health;

  public bool die=false,win=false;

  public GameObject winText,dieText, buttonHome,buttonRestart,buttonNextLevel,buttonShoot,jstick;

  public Text patronCnt;

  public float iPatronCnt;

  public int levelid=0;

  public GameObject fire;
  public GameObject bazookaEffects;
  public GameObject[] blaster1Eff;

    // Start is called before the first frame update
    void Start()
    {
      iPatronCnt=(float)headMaxNum*1.7f;
      money.GetComponent<Text>().text=PlayerPrefs.GetInt("money").ToString();

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
      headCnt.GetComponent<Text>().text=iHeadCnt.ToString()+"/"+headMaxNum.ToString();
      pauseHeadCnt.GetComponent<Text>().text=iHeadCnt.ToString()+"/"+headMaxNum.ToString();

      patronCnt.GetComponent<Text>().text=iPatronCnt.ToString();

      hiCurrentLevel.GetComponent<Text>().text=PlayerPrefs.GetInt("hi"+levelid.ToString()).ToString()+"/"+headMaxNum.ToString();
        //transform.rotation=new Quaternion(0,transform.rotation.y,0,0);

        if(iHealth<=0.1f && !once){
          die=true;
          once=true;
          restart();

        }

        if(iHeadCnt==headMaxNum){
          win=true;
          winning();
        }

          health.value=iHealth;

    }

    public GameObject[] patronPrephab;

    public void shootBtn(){
      shoot();
    }
    public bool shoot(){


      if(die==false && win==false && iPatronCnt>0){


      //if(PlayerPrefs.GetInt("gameControl")!=1)


      if(PlayerPrefs.GetInt("currentBlaster")==0){
        foreach(var a in particles){
          a.SetActive(true);
        }
        Instantiate(patronPrephab[PlayerPrefs.GetInt("currentBlaster")],gun.transform.position,transform.rotation);
        GetComponent<AudioSource>().Play();
        Invoke("offParticles",1);
        //if(PlayerPrefs.GetInt("gameControl")!=1)
        iPatronCnt--;
        return true;
      }
      else if(PlayerPrefs.GetInt("currentBlaster")==1 && iPatronCnt>=5){
        //blaster1Eff.SetActive(false);
        foreach(var a in blaster1Eff){
          a.SetActive(true);
        }
        patronPrephab[PlayerPrefs.GetInt("currentBlaster")].GetComponent<AudioSource>().Play();
        Instantiate(patronPrephab[PlayerPrefs.GetInt("currentBlaster")],gun.transform.position,transform.rotation);
        //GetComponent<AudioSource>().Play();
        Invoke("offParticles",0.5f);
        //if(PlayerPrefs.GetInt("gameControl")!=1){
          iPatronCnt-=5;
          return true;
        //}
      }


      else if(PlayerPrefs.GetInt("currentBlaster")==2 && iPatronCnt>=10){
        fire.SetActive(false);
        fire.SetActive(true);
        Invoke("offParticles",1.5f);
        patronPrephab[PlayerPrefs.GetInt("currentBlaster")].GetComponent<AudioSource>().Play();
        Instantiate(patronPrephab[PlayerPrefs.GetInt("currentBlaster")],gun.transform.position,transform.rotation);

        //if(PlayerPrefs.GetInt("gameControl")!=1){
          iPatronCnt-=10;
          return true;
        //}


      }
      else if(PlayerPrefs.GetInt("currentBlaster")==3 && iPatronCnt>=20){
        bazookaEffects.SetActive(false);
        bazookaEffects.SetActive(true);
        Invoke("offParticles",8f);
        patronPrephab[PlayerPrefs.GetInt("currentBlaster")].GetComponent<AudioSource>().Play();
        Instantiate(patronPrephab[PlayerPrefs.GetInt("currentBlaster")],gun.transform.position,transform.rotation);

        //if(PlayerPrefs.GetInt("gameControl")!=1){
          iPatronCnt-=20;
          return true;
        //}
      }

      //iHeadCnt++;
      headCnt.GetComponent<Text>().text=iHeadCnt.ToString()+"/100";
      pauseHeadCnt.GetComponent<Text>().text=iHeadCnt.ToString()+"/100";

      if(iHeadCnt>PlayerPrefs.GetInt("hi"+levelid.ToString())){
        PlayerPrefs.SetInt("hi"+levelid.ToString(),iHeadCnt);
      }
      //if(PlayerPrefs.GetInt("gameControl")!=1)iPatronCnt--;



      return false;
    }
    return false;
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
    }

    void offAnim(){
      character.GetComponent<Animator>().SetBool("Attacked",false);
    }

    public void addBullets(){
      iPatronCnt+=5;
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

      if(iHeadCnt>PlayerPrefs.GetInt("hi"+levelid.ToString())){
        PlayerPrefs.SetInt("hi"+levelid.ToString(),iHeadCnt);
      }
    }

    void winning(){
      PlayerPrefs.SetInt("Completed"+levelid.ToString(),1);
      PlayerPrefs.SetInt("hi"+levelid.ToString(),100);
      winText.SetActive(true);
      buttonHome.SetActive(true);
      buttonRestart.SetActive(true);
      buttonNextLevel.SetActive(true);
    }


    public void loadScene(int id){
      Application.LoadLevel(id);
    }


    public void updateHealth(){
      if(iHealth<100){
        iHealth+=25;
      }
      if(iHealth>100){
        iHealth=100;
      }
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
