using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatingEndless : MonoBehaviour
{

  public static bool move=true;
  public Image shootButton;

    public Joystick stick;
    // Start is called before the first frame update
    void Start()
    {
      move=true;

    }
    public static Vector3 worldPosition;

    // Update is called once per frame
    void Update()
    {
  if(PlayerPrefs.GetInt("gameControl")==1){


    if(Input.GetMouseButtonUp(0)){
      move=true;
    }




      Vector3[] corners=new Vector3[4];
      shootButton.GetComponent<Image>().rectTransform.GetWorldCorners(corners);
      Rect newRect =new Rect(corners[0],corners[2]-corners[0]);

      if(move && Time.timeScale==1 && Input.GetMouseButton(0) && !newRect.Contains(Input.mousePosition)){
        Plane plane = new Plane(Vector3.up, 0.62f);

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }


        worldPosition=new Vector3(worldPosition.x,-0.62f,worldPosition.z);


      if(GetComponent<PlayerControllerEndlessMode>().die==false && GetComponent<PlayerControllerEndlessMode>().win==false){
        transform.rotation = Quaternion.LookRotation(worldPosition -transform.position,new Vector3(0,1,0));
      }
    }

    else{
      if(GetComponent<PlayerControllerEndlessMode>().die==false && GetComponent<PlayerControllerEndlessMode>().win==false  && !newRect.Contains(Input.mousePosition)){
        transform.rotation = Quaternion.LookRotation(worldPosition -transform.position,new Vector3(0,1,0));
      }

    }
  }

  else{


    if(GetComponent<PlayerControllerEndlessMode>().die==false &&
     GetComponent<PlayerControllerEndlessMode>().win==false && move && Time.timeScale==1 && Input.GetMouseButton(0)  &&
    (stick.Horizontal!=0 || stick.Vertical!=0)){
      float heading = Mathf.Atan2(stick.Horizontal,stick.Vertical);

      transform.rotation=Quaternion.Euler(0f,heading*Mathf.Rad2Deg,0f);
    }
  }

    }
}
