using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaunaFlappyMove : MonoBehaviour
{
  static float speed=1;
  public PlayerFlappy player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(-Vector3.forward*speed*player.speed/8);
        if(transform.position.z<=-75){
          var go=Instantiate(gameObject,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,transform.position.z+50*4),gameObject.transform.rotation) as GameObject;
          go.GetComponent<FaunaFlappyMove>().player=player;
          Destroy(gameObject);
          if(speed<8)speed+=0.05f;
        }
    }
}
