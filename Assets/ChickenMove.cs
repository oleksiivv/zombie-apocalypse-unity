using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.forward/20);
        if(transform.position.x>3){
          Instantiate(gameObject,new Vector3(-3,Random.Range(-0.4f,2.22f),Random.Range(-6.1f,-8f)),gameObject.transform.rotation);
          Destroy(gameObject);
        }
    }
}
