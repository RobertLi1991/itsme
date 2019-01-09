using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPause : MonoBehaviour {

    public GameObject ingameMenu;

    public void OnPause()//点击“暂停”时执行此方法
    {
       playercontrol.PauseFlag=1;

    ingameMenu.SetActive(true);
    }

    public void OnResume()//点击“回到游戏”时执行此方法
    {
        ingameMenu.SetActive(false);
        playercontrol.PauseFlag =-1;
        
    }
    public void BacktoStartMenu()
    {
       SceneManager.LoadScene("startscreen");
    }
    public void OnRestart()//点击“重新开始”时执行此方法
    {
        playercontrol.PauseFlag = -1;
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
