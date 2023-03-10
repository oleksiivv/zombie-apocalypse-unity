using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward/40);
        if(transform.position.y>10){
          Instantiate(gameObject,new Vector3(0,-1.31f,-7.94f),gameObject.transform.rotation);
          Destroy(gameObject);
        }
    }
}
