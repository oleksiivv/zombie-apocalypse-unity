using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{

  public GameObject player;
  public GameObject[] enemyPrephab;
  public bool modeEndless=false;
  public int numOfZombies=100;
    // Start is called before the first frame update
    void Start()
    {

      if(!modeEndless){
        StartCoroutine(enemyInst());
      }
      else{
        StartCoroutine(enemyInstEndless());
      }


    }

    // Update is called once per frame
    void Update()
    {

    }

    int i=4;

    IEnumerator enemyInst(){
      while(i<numOfZombies){

        int posititonId=Random.Range(0,2);
        switch(posititonId){
          case 0:

          var go=Instantiate(enemyPrephab[Random.Range(0,enemyPrephab.Length)],new Vector3(Random.Range(-2.54f,3),-0.62f,-8.59f),Quaternion.identity) as GameObject;
          go.GetComponent<Defence>().player=player;
          break;

          case 1:

          var go1=Instantiate(enemyPrephab[Random.Range(0,enemyPrephab.Length)],new Vector3(-4.26f,-0.62f,Random.Range(0.1f,-6)),Quaternion.identity) as GameObject;
          go1.GetComponent<Defence>().player=player;
          break;


        }
        i++;
        Debug.Log(i);

        yield return new WaitForSeconds(0.6f);




      }
    }


      IEnumerator enemyInstEndless(){
        while(true){

          int posititonId=Random.Range(0,2);
          switch(posititonId){
            case 0:

            var go=Instantiate(enemyPrephab[Random.Range(0,enemyPrephab.Length)],new Vector3(Random.Range(-2.54f,3),-0.62f,-8.59f),Quaternion.identity) as GameObject;
            go.GetComponent<DefenceEndless>().player=player;
            break;

            case 1:

            var go1=Instantiate(enemyPrephab[Random.Range(0,enemyPrephab.Length)],new Vector3(-4.26f,-0.62f,Random.Range(0.1f,-6)),Quaternion.identity) as GameObject;
            go1.GetComponent<DefenceEndless>().player=player;
            break;


          }

          yield return new WaitForSeconds(0.6f);




        }



    }
}
