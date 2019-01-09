using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathmenu : MonoBehaviour {

    public  GameObject DeathMenu;

    public void ShowDeathMenu()
    {
       

        DeathMenu.SetActive(true);
    }

    public void BacktoStartMenu() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void OnRestart()
    {
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

}
