using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour
{
    // Start is called before the first frame 
    
    private ParticleSystem boomEffect;
    void Awake()
    {
        boomEffect = gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        transform.position = new Vector3(transform.position.x,4.7f,transform.position.z);
    }

    void OnTriggerEnter(Collider other){
        boomEffect.gameObject.transform.parent = null;
        boomEffect.Play();
        Destroy(gameObject);
    }
}
