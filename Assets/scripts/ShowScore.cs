using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowScore : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        this.GetComponent<Text>().text = "Highest scores " + PlayerPrefs.GetFloat("L1HighestScore", 0);

    }
	
	
}
