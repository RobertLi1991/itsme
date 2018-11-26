using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemywhite : MonoBehaviour {
    public Animator whiteenemychangeface;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(playercontrol.blackflag==1)
        {
            whiteenemychangeface.SetFloat("playeriswhite", -1);
        }
        if (playercontrol.blackflag == -1)
        {
            whiteenemychangeface.SetFloat("playeriswhite", 1);
        }

    }
}
