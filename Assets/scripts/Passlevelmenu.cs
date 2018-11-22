using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Passlevelmenu : MonoBehaviour {

    public GameObject passlevelMenu;

    public void ShowPassLevelMenu()//点击“暂停”时执行此方法
    {
        Time.timeScale = 0;
        passlevelMenu.SetActive(true);
    }

    public void NextLevel()//点击“回到游戏”时执行此方法
    {
        //SceneManager.LoadScene(level2);
    }

    public void OnRestart()//点击“重新开始”时执行此方法
    {
        //Loading Scene0
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

}
