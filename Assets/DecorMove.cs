using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorMove : MonoBehaviour
{

    public static int speed=1;
    // Start is called before the first frame update
    void Start()
    {
      speed=1;

    }

    // Update is called once per frame
    void Update()
    {
      if(PlayerFlappy.decSpeed!=0)transform.Translate(Vector3.forward*speed*Time.timeScale/6);
        if(transform.position.z<=-55){
          //Instantiate(gameObject,new Vector3(0,gameObject.transform.position.y,transform.position.z+transform.localScale.z*4),gameObject.transform.rotation);
          Destroy(gameObject);
        }

    }
}
