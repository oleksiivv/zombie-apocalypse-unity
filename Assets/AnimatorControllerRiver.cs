using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerRiver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(updateAnimator());
    }

    // Update is called once per frame
    void Update()
    {

    }
   int first=0;

    IEnumerator updateAnimator(){
      while(true){
        if(first!=0)gameObject.GetComponent<Animator>().enabled=!gameObject.GetComponent<Animator>().enabled;

        if(gameObject.GetComponent<Animator>().enabled==true){
          first++;
          yield return new WaitForSeconds(2);
        }
        else{
          first++;
          yield return new WaitForSeconds(15);
        }



      }
    }
}
