using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyblack : MonoBehaviour {
    public Animator changeface;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(playercontrol.blackflag==1)
        {
            changeface.SetFloat("playerisblack", 1);
        }
        if (playercontrol.blackflag == -1)
        {
            changeface.SetFloat("playerisblack", -1);
        }

    }
}
