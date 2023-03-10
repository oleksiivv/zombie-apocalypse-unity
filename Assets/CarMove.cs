using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(Vector3.forward/10);
      if(transform.position.x>19){
        Instantiate(gameObject,new Vector3(-3,transform.position.y,Random.Range(-6.1f,-8f)),gameObject.transform.rotation);
        Destroy(gameObject);
      }
  }
}
