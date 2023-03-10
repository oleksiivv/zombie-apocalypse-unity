using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
  public Text headCnt;
  public int levelid=0;
  public int maxHeadNum=100;
    // Start is called before the first frame update
    void Start()
    {
        headCnt.GetComponent<Text>().text=PlayerPrefs.GetInt("hi"+levelid.ToString()).ToString()+"/"+maxHeadNum.ToString();

        if(PlayerPrefs.GetInt("Completed"+(levelid-1).ToString())==0 && levelid!=0){
          headCnt.gameObject.SetActive(false);
          gameObject.GetComponent<Image>().color=new Color32(255,255,255,40);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
