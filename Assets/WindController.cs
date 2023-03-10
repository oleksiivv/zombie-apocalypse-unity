using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*300);
      gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right*500);

      Invoke("cleanCurrentObj",2);

    }

    void cleanCurrentObj(){
      Destroy(gameObject);
    }

    void OnCollisisonEnter(Collision other){

    }
}
