using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

using UnityEngine.UI;

public class PlayerOceanRun : MonoBehaviour
{

  public GameObject pausePanel;
  public GameObject diePanel;

public Text score,score1;
public Text best,best1;
public Text money,money1;

public Text study;
int iScore=0;


public string appId="3887151";
  // Start is called before the first frame update
  void Start()
  {
    Advertisement.Initialize(appId,false);

      speed=1;
      Time.timeScale=1;

      gameObject.GetComponent<Animator>().SetBool("Run",true);
      best.GetComponent<Text>().text="Best: "+PlayerPrefs.GetInt("BestStorm").ToString();

      if(PlayerPrefs.GetInt("studiedStorm")==0){
        study.gameObject.SetActive(true);
        PlayerPrefs.SetInt("studiedStorm",1);
      }
      else{
        study.gameObject.SetActive(!true);
      }

    }

    public static int speed=1;

    bool jump=true;
    bool started=false;
    int i=0;
        // Update is called once per frame
    void Update()
    {

          if(Input.GetMouseButtonDown(0)){
            if(study.gameObject.activeSelf==true){
              if(i==0){
                study.GetComponent<Text>().text="and tap while in flight to land faster";
              }
              if(i==1){
                study.gameObject.SetActive(false);
              }
              i++;
            }
          }
      if(Input.GetMouseButtonDown(0) && jump && speed!=0){
        gameObject.GetComponent<Animator>().SetBool("JumpDino",true);
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*850);
        jump=false;
      }
      else if(Input.GetMouseButtonDown(0) && !jump && speed!=0){
        gameObject.GetComponent<Animator>().SetBool("JumpDino",false);
        gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.up*950);
      }

      if((transform.position.y<-5 || transform.position.z<-7 || transform.position.z>8 ||transform.position.y>=26 )&& !started){
        Invoke("endgame",0.2f);
        started=true;
        gameObject.GetComponent<Animator>().SetBool("JumpDino",false);
        gameObject.GetComponent<Animator>().SetBool("Run",false);
        speed=0;

        if(iScore>PlayerPrefs.GetInt("BestStorm")){
          PlayerPrefs.SetInt("BestStorm",iScore);
        }
        best.GetComponent<Text>().text="Best: "+PlayerPrefs.GetInt("BestStorm").ToString();
      }


      if(speed!=0 && Time.timeScale==1)iScore++;
      score.GetComponent<Text>().text="Score: "+iScore.ToString();
      money.GetComponent<Text>().text=PlayerPrefs.GetInt("money").ToString();

      if(speed==0){
        gameObject.GetComponent<Animator>().SetBool("Run",!true);
      }

    }

    void OnCollisionEnter(Collision other){

      jump=true;
      gameObject.GetComponent<Animator>().SetBool("JumpDino",false);
      gameObject.GetComponent<Animator>().SetBool("Run",true);
      if(other.gameObject.tag=="Enemy"){

        if(iScore>PlayerPrefs.GetInt("BestStorm")){
          PlayerPrefs.SetInt("BestStorm",iScore);
        }
        best.GetComponent<Text>().text="Best: "+PlayerPrefs.GetInt("BestStorm").ToString();

        gameObject.GetComponent<Animator>().SetBool("JumpDino",false);
        gameObject.GetComponent<Animator>().SetBool("Run",false);

        gameObject.GetComponent<Animator>().SetBool("Attacked",true);
        speed=0;


        Invoke("endgame",0.2f);

      }

      if(other.gameObject.tag!="Enemy"){
        other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*100);
        if(speed==0){
          other.gameObject.GetComponent<Rigidbody>().mass=3000;
        }
      }
    }

    void endgame(){
      StartCoroutine(die());
    }
    int deg=0;
    IEnumerator die(){
      while(deg>-90){
        transform.Rotate(-2,0,0);
        deg-=2;

        yield return new WaitForSeconds(0.0001f);
      }
      diePanel.SetActive(true);
      //Time.timeScale=0;
    }


    public void pause(){
      if(speed!=0){
        score1.GetComponent<Text>().text="Score: "+iScore.ToString();
        best1.GetComponent<Text>().text="Best: "+PlayerPrefs.GetInt("BestDino").ToString();
        money1.GetComponent<Text>().text=PlayerPrefs.GetInt("money").ToString();
        speed=0;
        Time.timeScale=0;
        pausePanel.SetActive(true);
      }
    }

    public void resume(){
      speed=1;
      Time.timeScale=1;
      pausePanel.SetActive(false);
    }

    public void restart(){
      if(iScore>PlayerPrefs.GetInt("BestDino")){
        PlayerPrefs.SetInt("BestDino",iScore);
      }

      StartCoroutine(loadAsync(Application.loadedLevel));
    }

    public void loadLevel(int id){
      if(iScore>PlayerPrefs.GetInt("BestDino")){
        PlayerPrefs.SetInt("BestDino",iScore);
      }
      if(Advertisement.IsReady("video")){
        Advertisement.Show("video");
      }
      StartCoroutine(loadAsync(id));
    }

    public void OnTriggerEnter(Collider other){
      if(other.tag=="money"){
        if(PlayerPrefs.GetInt("mutedEffects")==0)other.GetComponent<AudioSource>().Play();
        other.gameObject.GetComponentInChildren<MeshRenderer>().enabled=false;
        PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")+10);
      }
    }


    public GameObject loadScene;
    public Slider loadSl;
    IEnumerator loadAsync(int id)
    {

        AsyncOperation operation = Application.LoadLevelAsync(id);
        loadScene.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadSl.value = progress;
            yield return null;

        }
    }
}
