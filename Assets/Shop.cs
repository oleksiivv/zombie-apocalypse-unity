using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
  public Image[] weapoonItems;
  public GameObject[] weapoonButtons;

  public Image[] levelItems;
  public GameObject[] levelButton;

  public GameObject[] textMoneyWeapoon,textMoneyLevel;
  public GameObject[] imageMoneyWeapoon,imageMoneyLevel;

  public GameObject[] textAvailableWeapoon,textAvailableLevel;

    public Text money;
    // Start is called before the first frame update
    void Start()
    {


        //PlayerPrefs.SetInt("money",1000);

    }

    // Update is called once per frame
    void Update()
    {

      for(int i=0;i<weapoonItems.Length;i++){
        if(PlayerPrefs.GetInt("blaster_n"+(i+1).ToString())==1){
          weapoonItems[i].GetComponent<Image>().color=new Color32(131,255,95,255);
          weapoonButtons[i].SetActive(false);

          textMoneyWeapoon[i].SetActive(false);
          imageMoneyWeapoon[i].SetActive(false);

          textAvailableWeapoon[i].SetActive(true);
        }
        else{
          weapoonButtons[i].SetActive(!false);

          textMoneyWeapoon[i].SetActive(!false);
          imageMoneyWeapoon[i].SetActive(!false);

          textAvailableWeapoon[i].SetActive(!true);
        }

      }

      for(int i=0;i<levelItems.Length;i++){
        PlayerPrefs.SetInt("addictedLevel"+i.ToString(), 1);
        if(PlayerPrefs.GetInt("addictedLevel"+i.ToString())==1){
          levelItems[i].GetComponent<Image>().color=new Color32(131,255,95,255);
          levelButton[i].SetActive(false);


          textMoneyLevel[i].SetActive(false);
          imageMoneyLevel[i].SetActive(false);

          textAvailableLevel[i].SetActive(true);
        }
        else{
          levelButton[i].SetActive(!false);


          textMoneyLevel[i].SetActive(!false);
          imageMoneyLevel[i].SetActive(!false);

          textAvailableLevel[i].SetActive(!true);
        }
      }

      money.GetComponent<Text>().text=PlayerPrefs.GetInt("money").ToString();

    }

    public void buyWeapoon(int id){
      if(id==1 && PlayerPrefs.GetInt("money")>=500){
        gameObject.GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("blaster_n"+id.ToString(),1);
        PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")-500);
      }

      else if(id==2 && PlayerPrefs.GetInt("money")>=1000){
        gameObject.GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("blaster_n"+id.ToString(),1);
        PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")-1000);
      }

      else if(id==3 && PlayerPrefs.GetInt("money")>=2000){
        gameObject.GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("blaster_n"+id.ToString(),1);
        PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")-2000);
      }



    }

    public void buyLevel(int id){
      if(id==0 && PlayerPrefs.GetInt("money")>=200){
        gameObject.GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("addictedLevel"+id.ToString(),1);
        PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")-200);
      }

      else if(id==1 && PlayerPrefs.GetInt("money")>=500){
        gameObject.GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("addictedLevel"+id.ToString(),1);
        PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")-500);
      }

      else if(id==2 && PlayerPrefs.GetInt("money")>=800){
        gameObject.GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("addictedLevel"+id.ToString(),1);
        PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")-800);
      }


    }

}
