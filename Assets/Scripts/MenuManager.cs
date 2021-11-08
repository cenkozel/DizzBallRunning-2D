using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject dataBoard;
    public GameObject Exit,DataBackground;
    public static MenuManager Instance;
    public GameObject InformationScreen;
    public GameObject OyunKural,PlayerInformation,Dusmanlar;
    public GameObject Beeenemy, RoboEnemy, MaceEnemy;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButton()
    {
        DataManager.Instance.reset();
       
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        SceneManager.LoadScene(1);
    }
  

    public void DataBoardButton()
    {
        DataManager.Instance.LoadData();


        dataBoard.transform.GetChild(1).GetComponent<Text>().text ="Total Bullet : "+ DataManager.Instance.totalShotBullet.ToString();
        dataBoard.transform.GetChild(2).GetComponent<Text>().text = "Total Killed : " + DataManager.Instance.totalEnemyKilled.ToString();
        dataBoard.transform.GetChild(3).GetComponent<Text>().text = "Total Coin : " + DataManager.Instance.totalCollectCoin.ToString();
        dataBoard.transform.GetChild(4).GetComponent<Text>().text = "Total Killed : " + DataManager.Instance.totalBeeKilled.ToString();
        dataBoard.transform.GetChild(5).GetComponent<Text>().text = "Timer :" + DataManager.Instance.Skortime.ToString();
        dataBoard.transform.GetChild(6).GetComponent<Text>().text = "Your Score :" + DataManager.Instance.totalskorpuan.ToString();
        dataBoard.SetActive(true);
        DataBackground.SetActive(true);
    }
    public void XButton()
    {
        dataBoard.SetActive(false);
        DataBackground.SetActive(false);
    }
    public void ResetButton()
    {
        DataManager.Instance.TotalReset();
        DataBoardButton();
    }
    public void ExitButton()
    {
        Exit.SetActive(true);
    }
     public void ExitButtonYes()
    {
        Application.Quit();
    }
    public void ExitButtonNo()
    {
        Exit.SetActive(false);
    }

    // InformationScreen

    public void InformationButton()
    {
        InformationScreen.SetActive(true);
    }

    public void InformationExitButton()
    {
        InformationScreen.SetActive(false);
    }

    public void OyunKuralButton()
    {
        OyunKural.SetActive(true);
        PlayerInformation.SetActive(false);
        Dusmanlar.SetActive(false);
        RoboEnemy.SetActive(false);
        MaceEnemy.SetActive(false);
        Beeenemy.SetActive(false);
    }
    public void PlayerButton()
    {
        OyunKural.SetActive(false);
        PlayerInformation.SetActive(true);
        Dusmanlar.SetActive(false);
        RoboEnemy.SetActive(false);
        MaceEnemy.SetActive(false);
        Beeenemy.SetActive(false);
    }
    public void DusmanlarOn()
    {
        OyunKural.SetActive(false);
        PlayerInformation.SetActive(false);
        Dusmanlar.SetActive(true);
        RoboEnemy.SetActive(false);
        MaceEnemy.SetActive(false);
        Beeenemy.SetActive(false);

    }
    public void BeeEnemyButton()
    {
        OyunKural.SetActive(false);
        PlayerInformation.SetActive(false);
      
        RoboEnemy.SetActive(false);
        MaceEnemy.SetActive(false);
        Beeenemy.SetActive(true);
    }
    public void RoboEnemyButton()
    {
        OyunKural.SetActive(false);
        PlayerInformation.SetActive(false);
      
        RoboEnemy.SetActive(true);
        MaceEnemy.SetActive(false);
        Beeenemy.SetActive(false);
    }
    public void MaceEnemyButton()
    {
        OyunKural.SetActive(false);
        PlayerInformation.SetActive(false);
        
        RoboEnemy.SetActive(false);
        MaceEnemy.SetActive(true);
        Beeenemy.SetActive(false);
    }

}


   

