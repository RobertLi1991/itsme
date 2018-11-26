using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreUI : MonoBehaviour {
    private Text m_textComponent;
	// Use this for initialization
	void Start () {
        m_textComponent = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(m_textComponent!=null)
        {
            m_textComponent.text = "Score:" + ScoreManager.score;
        }
	}
}
