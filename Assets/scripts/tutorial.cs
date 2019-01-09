using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour {
    public static float tutorialOpenFlag=1f;
    public static float readFlag=-1f;
    public Animator countDown;
	// Use this for initialization
	void Start () {
        GameObject closepicture = transform.Find("close").gameObject;
        if (readFlag==1f)
        {
            CloseTutorial();
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void CloseTutorial()
    {
        Destroy(gameObject);
        tutorialOpenFlag = -1f;
        countDown.SetFloat("tutorialEndFlag",1);
        readFlag = 1f;
    }
}
