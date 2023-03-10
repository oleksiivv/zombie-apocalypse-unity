using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale=new Vector3(3,Random.Range(5f,8.5f),3);    
    }

    // Update is called once per frame
    void Update()
    {

    }
}
