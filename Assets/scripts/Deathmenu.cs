using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathmenu : MonoBehaviour {

    public  GameObject DeathMenu;

    public void ShowDeathMenu()
    {
        Time.timeScale = 0;

        DeathMenu.SetActive(true);
    }

    public void BacktoStartMenu() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void OnRestart()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        
       
    }

}
