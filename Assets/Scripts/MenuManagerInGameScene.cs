using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerInGameScene : MonoBehaviour
{
    public GameObject InGameScreen, PauseScreen,LoseScreen,WinScreen;
    public GameObject OneStar, TwoStar, ThreeStar;
    public GameObject backgroundsound;
    public static MenuManagerInGameScene Instance;

    public Text TimerText;
    public float StartTimer;
    public Text Score;
    public Text ScoreWin;
    // Start is called before the first frame update
    void Start()
    {  
        Instance = this;
        StartTimer = Time.time;



    }

    // Update is called once per frame
    void Update()
    {
        
        float t = Time.time - StartTimer;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f");
        TimerText.text = minutes + ":" + seconds;
        
        Score.text = DataManager.Instance.SkorPuan.ToString();
        ScoreWin.text = DataManager.Instance.SkorPuan.ToString();
    }
    


    public void PauseButton()
    {
        Time.timeScale = 0;
        InGameScreen.SetActive(false);
        PauseScreen.SetActive(true);
        
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        InGameScreen.SetActive(true);
    }

    public void ReplayButton()
    {
        DataManager.Instance.reset();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
       

    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        DataManager.Instance.SaveData(false);
        SceneManager.LoadScene(0);

    }
    public void WinScreenOn()
    {

        InGameScreen.SetActive(false);
        WinScreen.SetActive(true);
    }

    public void LoseScreenOn()
    {
        LoseScreen.SetActive(true);
    }
    public void loseReplayButton()
    {
        DataManager.Instance.reset();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        DataManager.Instance.yasiyormu = true;
        LoseScreen.SetActive(false);

    }

    public void loseHomeButton()
    {
        Time.timeScale = 1;
        DataManager.Instance.SaveData(false);
        SceneManager.LoadScene(0);
        DataManager.Instance.yasiyormu = true;
        LoseScreen.SetActive(false);
    }







}
