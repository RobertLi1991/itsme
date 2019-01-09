using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RealGameManager : MonoBehaviour
{
    public GameObject DeathMenu;
    public GameObject PassLevelMenu;
    public float Invokeflag2 = -1;
    public float Invokeflag1 = -1;
    public static string Scenename;
    // Use this for initialization
    void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        Scenename = scene.name;

    }

    // Update is called once per frame
    void Update()
    {
        if (Scenename == "level2")
        {
            if (playercontrol.Dieflag1 == 1 && playercontrol2.Dieflag2 == 1)
            {
               
                DeathMenu.GetComponent<Deathmenu>().ShowDeathMenu();
            }
        }
        else if (Scenename == "level1")
        {
            if (playercontrol.Dieflag1 == 1)
            {
                DeathMenu.GetComponent<Deathmenu>().ShowDeathMenu();
            }
        }

        if (playercontrol.WinFlag == 1 || playercontrol2.WinFlag2 == 1)
        {
            PassLevelMenu.GetComponent<Passlevelmenu>().ShowPassLevelMenu();
        }
        if (playercontrol2.yellowflag2 == 1&&Invokeflag2==-1)
        {
            
            playercontrol2.yellowlayer2.SetActive(true);
            Invoke("CancelYellowLayer2", 3f);
            Invokeflag2 = 1;
        }
        if (playercontrol.yellowflag1 == 1 && Invokeflag1 == -1)
        {

            playercontrol.yellowlayer1.SetActive(true);
            Invoke("CancelYellowLayer1", 3f);
            Invokeflag1 = 1;
        }
    }
    private void CancelYellowLayer1()

    {
        playercontrol.yellowlayer1.SetActive(false);
        playercontrol.yellowflag1 = -1;
        Invokeflag1 = -1;
    }
    private void CancelYellowLayer2()

    {
        playercontrol2.yellowlayer2.SetActive(false);
        playercontrol2.yellowflag2 = -1;
        Invokeflag2 = -1;
    }
}
