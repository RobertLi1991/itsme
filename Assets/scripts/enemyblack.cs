using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyblack : MonoBehaviour {
    public Animator changeface;
    public float Setface=-1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (RealGameManager.Scenename=="level1")
        { 
		   if(playercontrol.blackflag==1)
           {
            changeface.SetFloat("playerisblack", 1);
           }
           if (playercontrol.blackflag == -1)
           {
            changeface.SetFloat("playerisblack", -1);
           }
        }
        if (Setface==-1&&RealGameManager.Scenename == "level2")
        {
            changeface.SetFloat("Islevel2", 1);
       
            Setface= 1;

        }


    }
}
