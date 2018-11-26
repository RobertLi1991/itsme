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
        playercontrol.Dieflag = -1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        
       
    }

}
