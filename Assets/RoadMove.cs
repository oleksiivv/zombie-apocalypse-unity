using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMove : MonoBehaviour
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
          var go=Instantiate(gameObject,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,transform.position.z+transform.localScale.z*4),gameObject.transform.rotation) as GameObject;
          go.GetComponent<RoadMove>().player=player;
          if(speed<8)speed+=0.003f;
          Destroy(gameObject);

        }
    }
}
