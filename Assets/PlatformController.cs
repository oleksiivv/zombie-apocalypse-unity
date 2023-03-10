using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
  public Quaternion deg;

    // Start is called before the first frame update
    void Start()
    {
      deg=transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(-Vector3.up*PlayerOceanRun.speed/4);

      if(transform.position.z<-33){
        Instantiate(gameObject,new Vector3(-0.55f,-0.9f,Random.Range(46f,48f)),deg);
        Destroy(gameObject);
      }

    }


}
