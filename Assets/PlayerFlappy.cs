using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class PlayerFlappy : MonoBehaviour
{
  public int speed=1;

  public GameObject pausePanel;
  public GameObject diePanel;

public Text score,score1;
public Text best,best1;
public Text money,money1;

int iScore=0;

public GameObject bird;
public static int decSpeed=1;
public Text study;
public string appId="3887151";
  // Start is called before the first frame update
  void Start()
  {
    Advertisement.Initialize(appId,false);

      if(PlayerPrefs.GetInt("studiedFlappy")==0){
        study.gameObject.SetActive(true);
        PlayerPrefs.SetInt("studiedFlappy",1);
        Invoke("studyTextOff",4f);
      }
      else{
        study.gameObject.SetActive(!true);
      }



      decSpeed=1;
      EnemyMoveDino.dir=1;
      EnemyMoveDino.speed=2;
      Time.timeScale=1;



        best.GetComponent<Text>().text="Best: "+PlayerPrefs.GetInt("BestFlappy").ToString();

    }


    void studyTextOff(){
      study.gameObject.SetActive(false);
    }

bool started=false;
    // Update is called once per frame
    void Update()
    {



      if(Input.GetMouseButtonDown(0)){
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*600);

      }
      gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.up*25);




      if((gameObject.GetComponent<Animator>().GetBool("Attacked") && !started) || (speed==0 && !started) || (transform.position.y>12.8f && !started)){
        started=true;
        gameObject.GetComponent<Rigidbody>().mass=90;
        gameObject.GetComponent<Rigidbody>().useGravity=true;;
        bird.SetActive(false);
        DecorMove.speed=0;
        decSpeed=0;
        speed=0;
        Invoke("endgame",0.1f);
      }


      score.GetComponent<Text>().text="Score: "+iScore.ToString();
      money.GetComponent<Text>().text=PlayerPrefs.GetInt("money").ToString();



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
    }



    void OnCollisionEnter(Collision other){
      gameObject.GetComponent<Animator>().SetBool("JumpDino",false);

      if(other.gameObject.tag=="Enemy"){
        if(iScore>PlayerPrefs.GetInt("BestFlappy")){
          PlayerPrefs.SetInt("BestFlappy",iScore);
        }
        best.GetComponent<Text>().text="Best: "+PlayerPrefs.GetInt("BestFlappy").ToString();
        speed=0;
        decSpeed=0;
        DecorMove.speed=0;
      }
    }

    public void pause(){
      if(speed!=0){
        score1.GetComponent<Text>().text="Score: "+iScore.ToString();
        best1.GetComponent<Text>().text="Best: "+PlayerPrefs.GetInt("BestFlappy").ToString();
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
      if(iScore>PlayerPrefs.GetInt("BestFlappy")){
        PlayerPrefs.SetInt("BestFlappy",iScore);
      }

      StartCoroutine(loadAsync(Application.loadedLevel));
    }

    public void loadLevel(int id){
      if(iScore>PlayerPrefs.GetInt("BestFlappy")){
        PlayerPrefs.SetInt("BestFlappy",iScore);
      }
      Advertisement.Show("video");
      
      StartCoroutine(loadAsync(id));
    }

    public void OnTriggerEnter(Collider other){
      if(other.tag=="money"){
        other.GetComponent<AudioSource>().Play();
        other.gameObject.GetComponentInChildren<MeshRenderer>().enabled=false;
        other.gameObject.GetComponentInChildren<BoxCollider>().enabled=false;
        PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")+10);
      }
      if(other.tag=="score"){
        iScore++;
        Destroy(other.gameObject);
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
