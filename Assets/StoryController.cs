using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{
  public Image[] images;
  public Image startGameBtn;
  public Text[] txts;
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(storyTellText());
      StartCoroutine(storyTellImage());
      Invoke("startGameBtnOn",15);

    }

    // Update is called once per frame
    void Update()
    {

    }
    int cntText=0;

    IEnumerator storyTellText(){

      while(cntText<txts.Length){

        txts[cntText].gameObject.SetActive(true);
        cntText++;

        yield return new WaitForSeconds(3);



      }


    }

    void startGameBtnOn(){
      startGameBtn.gameObject.SetActive(true);
    }



    int cntImg=0;

    IEnumerator storyTellImage(){

      while(cntImg<images.Length){

        images[cntImg].gameObject.SetActive(true);
        cntImg++;

        yield return new WaitForSeconds(3);



      }


    }


    public void skip(){
      gameObject.SetActive(false);
    }

    
}
