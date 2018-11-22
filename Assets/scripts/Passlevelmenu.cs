using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Passlevelmenu : MonoBehaviour {

    public  GameObject passlevelMenu;
    public Image starpicture;

    
    public void ShowPassLevelMenu(float proportion)
    {
        Time.timeScale = 0;
        
        passlevelMenu.SetActive(true);
        showstar(proportion);
    }

    public void NextLevel() 
    {
        SceneManager.LoadScene("level2");
    }

    public void OnRestart()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        
    }
    public void showstar(float proportion)
    {
        if (proportion >= 0.6 && proportion < 0.7)
        {
            starpicture.fillAmount = 0.33f;
        }
        if (proportion >= 0.7 && proportion <0.8)
        {
            starpicture.fillAmount = 0.67f;
        }
        if (proportion >= 0.8)
        {
            starpicture.fillAmount = 1;
        }

    }

}
