using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class PlayerDinoRun : MonoBehaviour
{
  public int speed=1;

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
    Application.targetFrameRate=50;


      if(PlayerPrefs.GetInt("studiedDino")==0){
        study.gameObject.SetActive(true);
        PlayerPrefs.SetInt("studiedDino",1);
      }
      else{
        study.gameObject.SetActive(!true);
      }




      EnemyMoveDino.dir=1;
      EnemyMoveDino.speed=2;
      Time.timeScale=1;

      gameObject.GetComponent<Animator>().SetBool("Run",true);

      best.GetComponent<Text>().text="Best: "+PlayerPrefs.GetInt("BestDino").ToString();

    }

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

      if(Input.GetMouseButtonDown(0) && !gameObject.GetComponent<Animator>().GetBool("JumpDino")){
        gameObject.GetComponent<Animator>().SetBool("JumpDino",true);
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*550);
      }
      else if(Input.GetMouseButtonDown(0) && gameObject.GetComponent<Animator>().GetBool("JumpDino")){
        gameObject.GetComponent<Animator>().SetBool("JumpDino",false);
        gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.up*550);
      }

      if(gameObject.GetComponent<Animator>().GetBool("Attacked") && !started){
        started=true;
        gameObject.GetComponent<Rigidbody>().mass=90;
        Invoke("endgame",0.1f);
      }

      if(speed!=0 && Time.timeScale==1)iScore++;
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
        if(iScore>PlayerPrefs.GetInt("BestDino")){
          PlayerPrefs.SetInt("BestDino",iScore);
        }
        best.GetComponent<Text>().text="Best: "+PlayerPrefs.GetInt("BestDino").ToString();
        speed=0;
      }
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
        other.GetComponent<AudioSource>().Play();
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
