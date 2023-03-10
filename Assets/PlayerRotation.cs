using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
  public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {




    }

    void OnMouseOver(){

      if(player.GetComponent<PlayerController>().die==false && player.GetComponent<PlayerController>().win==false)player.transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position,new Vector3(0,1,0));





    }
}
