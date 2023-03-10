using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMove : MonoBehaviour
{
  static float speed=1;
  public PlayerDinoRun player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(-Vector3.forward*speed*player.speed/9);
        if(transform.position.z<=-75){
          var go=Instantiate(gameObject,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z+50*4),gameObject.transform.rotation) as GameObject;
          go.GetComponent<TreeMove>().player=player;

          if(speed<8)speed+=0.003f;
          gameObject.SetActive(false);


        }
    }
}
