using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Passlevelmenu : MonoBehaviour {

    public  GameObject passlevelMenu;
    public Image starpicture;
    public Text scoretext;
    public Text Winner;
    public float WinnerPlayerNumber;

    
    public void ShowPassLevelMenu()
    {
       
        passlevelMenu.SetActive(true);
        if (RealGameManager.Scenename == "level1")
        {
            showstar(ScoreManager.score1);
            showscore(ScoreManager.score1);
            RecordHighScore(ScoreManager.score1);
        }
        else
        {
           
            ShowWinner();
        }
    }

    public void NextLevel() 
    {
        //SceneManager.LoadScene("level3");
    }
    public void BacktoStartMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void OnRestart()
    {
        playercontrol.WinFlag = -1;
        playercontrol2.WinFlag2 = -1;
        playercontrol.Dieflag1 = -1;
        playercontrol2.Dieflag2 = -1;
        if (RealGameManager.Scenename == "level2")
        {
            SceneManager.LoadScene("level2");
        }
        else
        {
            SceneManager.LoadScene("level1");
        }

    }
    public void Quitgame()
    {
        Application.Quit();
    }
    public void showstar(float score)
    {
        if (score < 200)
        {
            starpicture.fillAmount = 0.33f;
        }
        if (score >= 200 && score < 300)
        {
            starpicture.fillAmount = 0.67f;
        }
        if (score >= 300)
        {
            starpicture.fillAmount = 1;
        }

    }
    public void showscore(float score)
    {
        scoretext.text = "Score:" + score;
    }
    public void ShowWinner()
    {
        if (playercontrol.Dieflag1==1)
        {
            Winner.text = "The winer is Player2";
            WinnerPlayerNumber = 2;
            showstar(ScoreManager.score2);
            scoretext.text = "P1: Failed  P2: "+ScoreManager.score2;
            RecordHighScore(ScoreManager.score2);
        }
        if (playercontrol2.Dieflag2 == 1)
        {
            Winner.text = "The winer is Player1";
            showstar(ScoreManager.score1);
            scoretext.text = "P1: " + ScoreManager.score1+ "  P2: Failed";
            RecordHighScore(ScoreManager.score1);
        }
        if (playercontrol.Dieflag1 == -1 && playercontrol2.Dieflag2 == -1)
        {
            if (ScoreManager.score1 > ScoreManager.score2)
            {
                Winner.text = "The winer is Player1";
                WinnerPlayerNumber = 1;
                showstar(ScoreManager.score1);
                RecordHighScore(ScoreManager.score1);
            }
            else if (ScoreManager.score1 < ScoreManager.score2 && playercontrol2.Dieflag2 == -1)
            {
                Winner.text = "The winer is Player2";
                WinnerPlayerNumber = 2;
                showstar(ScoreManager.score2);
                RecordHighScore(ScoreManager.score2);
            }
            else
            {
                Winner.text = "It's a tie";
                showstar(ScoreManager.score2);
                RecordHighScore(ScoreManager.score2);
            }
            scoretext.text = "P1: " + ScoreManager.score1 + "  P2: " + ScoreManager.score2;
        }
    }
    public void RecordHighScore(float score)
    {
        if(RealGameManager.Scenename == "level2")
        {
            if (score > PlayerPrefs.GetFloat("L2HighestScore", 0))
            {
                PlayerPrefs.SetFloat("L2HighestScore", score);

            }
        }
        else
        {
            if (score > PlayerPrefs.GetFloat("L1HighestScore", 0))
            {
                PlayerPrefs.SetFloat("L1HighestScore", score);

            }
        }
    }
}
