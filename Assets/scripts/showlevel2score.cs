using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showlevel2score : MonoBehaviour {

	// Use this for initialization
	
        void Start()
        {
            this.GetComponent<Text>().text = "Highest scores " + PlayerPrefs.GetFloat("L2HighestScore", 0);

        }
    
	
	// Update is called once per frame
	void Update () {
		
	}
}
