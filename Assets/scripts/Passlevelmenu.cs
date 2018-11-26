using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Passlevelmenu : MonoBehaviour {

    public  GameObject passlevelMenu;
    public Image starpicture;
    public Text scoretext;

    
    public void ShowPassLevelMenu(float score)
    {
 
        passlevelMenu.SetActive(true);
        showstar(score);
        showscore(score);
    }

    public void NextLevel() 
    {
        SceneManager.LoadScene("level2");
    }

    public void OnRestart()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        
    }
    public void showstar(float score)
    {
        if (score < 200)
        {
            starpicture.fillAmount = 0.33f;
        }
        if (score >= 200 && score < 250)
        {
            starpicture.fillAmount = 0.67f;
        }
        if (score >= 250)
        {
            starpicture.fillAmount = 1;
        }

    }
    public void showscore(float score)
    {
        scoretext.text = "Score:" + score;
    }

}
