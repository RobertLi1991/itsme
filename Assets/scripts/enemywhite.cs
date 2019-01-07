using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemywhite : MonoBehaviour {
    public Animator whiteenemychangeface;
    public float Setface = -1;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        if (RealGameManager.Scenename == "level1")
        {
            if (playercontrol.blackflag == 1)
            {
                whiteenemychangeface.SetFloat("playeriswhite", -1);
            }
            if (playercontrol.blackflag == -1)
            {
                whiteenemychangeface.SetFloat("playeriswhite", 1);
            }
        }
        if (Setface == -1 && RealGameManager.Scenename == "level2")
        {
            whiteenemychangeface.SetFloat("Islevel2", 1);
            Setface =1;
       
        }
    }
}
