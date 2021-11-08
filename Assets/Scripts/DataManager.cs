using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private int shotBullet;
    public int totalShotBullet;
    private int enemyKilled;
    public int totalEnemyKilled;
    private int collectCoin;
    public int totalCollectCoin;
    private int beeKilled;
    public int totalBeeKilled;
    EasyFileSave myfile;
    public bool yasiyormu;
    public string Skortime;
    public int SkorPuan;
    public int totalskorpuan;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            StartProcess();

        }
        else
        {
            Destroy(gameObject);

        }
        DontDestroyOnLoad(gameObject);
        yasiyormu = true;


    }

    
  


    // Update is called once per frame
    void Update()
    {
        
    }
    public int ShotBullet
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            GameObject.Find("ShotBulletText").GetComponent<Text>().text = ":" + shotBullet.ToString();
            
        }
    }

    public int EnemyKilled
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = ":" + enemyKilled.ToString();
            WinProcess();
        }
    }

    public int CollectCoin
    {
        get
        {
            return collectCoin;
        }
        set
        {
            collectCoin = value;
            GameObject.Find("CollectCoinText").GetComponent<Text>().text = ":" + collectCoin.ToString();
            WinProcess();
        }
    }
    public int BeeKilled
    {
        get
        {
            return beeKilled;
        }
        set
        {
            beeKilled = value;
            GameObject.Find("BeeKilledText").GetComponent<Text>().text = ":" + beeKilled.ToString();
            WinProcess();
        }
    }
    

    void StartProcess()
    {
        myfile = new EasyFileSave();
        LoadData();
    }
    public void SaveData(bool Remove)
    {
        totalShotBullet += shotBullet;
        totalEnemyKilled += enemyKilled;
        totalCollectCoin += collectCoin;
        totalBeeKilled += beeKilled;



        myfile.Add("SkorPuan", SkorPuan);
        myfile.Add("totalShotBullet", totalShotBullet);
        myfile.Add("totalEnemyKilled", totalEnemyKilled);
        myfile.Add("totalCollectCoin", totalCollectCoin);
        myfile.Add("totalBeeKilled", totalBeeKilled);
        if (!Remove)
        {
            myfile.Add("Time", MenuManagerInGameScene.Instance.TimerText.text);
        }
        else
        {
            myfile.Add("Time", "00:00,00");
        }

        myfile.Save();

    }
    public void LoadData()
    {
        if (myfile.Load())
        {
            totalShotBullet = myfile.GetInt("totalShotBullet");
            totalEnemyKilled = myfile.GetInt("totalEnemyKilled");
            totalCollectCoin = myfile.GetInt("totalCollectCoin");
            totalBeeKilled = myfile.GetInt("totalBeeKilled");
            Skortime=(myfile.GetString("Time"));
            totalskorpuan = myfile.GetInt("SkorPuan");
        }
    }
   
    public void reset()
    {
        shotBullet = 0;
        enemyKilled = 0;
        collectCoin = 0;
        beeKilled = 0;
        SkorPuan = 0;
       
    }
    public void TotalReset()
    {
        shotBullet = -totalShotBullet;
        enemyKilled = -totalEnemyKilled;
        collectCoin = -totalCollectCoin;
        beeKilled = -totalBeeKilled;
        MenuManager.Instance.dataBoard.transform.GetChild(5).GetComponent<Text>().text = "Timer :" + "";
        myfile.Add("Time", "00:00,00");
        SkorPuan = 0;
        SaveData(true);
    }
    public void WinProcess()
    {
        SkorPuan = enemyKilled*14 + collectCoin*5 + beeKilled*40;
        
    }


    IEnumerator KazanmaBekle(float sure)  //Kazanma PlayerManager içinde
    {
        yield return new WaitForSeconds(sure);
        WİN();
    }
    public void Kazanma()
    {
        StartCoroutine(KazanmaBekle(2f));
    }

    void WİN()
    {
        
        Time.timeScale = 0;
        MenuManagerInGameScene.Instance.WinScreenOn();
        if(SkorPuan>=650)
        {
            MenuManagerInGameScene.Instance.OneStar.SetActive(true);
        }
        if (SkorPuan >= 800)
        {
            MenuManagerInGameScene.Instance.OneStar.SetActive(true);
            MenuManagerInGameScene.Instance.TwoStar.SetActive(true);
        }
        if (SkorPuan >= 950)
        {
            MenuManagerInGameScene.Instance.OneStar.SetActive(true);
            MenuManagerInGameScene.Instance.TwoStar.SetActive(true);
            MenuManagerInGameScene.Instance.ThreeStar.SetActive(true);
        }
    }

  

    public void loseProcess()   // Kaybetme
    {
        
        Time.timeScale = 0;
        MenuManagerInGameScene.Instance.LoseScreenOn();
    }

    IEnumerator yokolma(float sure)
    {
        yield return new WaitForSeconds(sure);
        loseProcess();
    }

    public void Yokolma()
    {
        yasiyormu = false;
        StartCoroutine(yokolma(3f));
    }
}
