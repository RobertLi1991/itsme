﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countdown : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("disappear"))
        {
            playercontrol.Countflag = 1;
        }

            
    }
}
