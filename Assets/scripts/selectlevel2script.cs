using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class selectlevel2script : MonoBehaviour {
    public Animator Level2Ani;

	// Use this for initialization
	public void MouseIn()
    {
        Level2Ani.SetFloat("selectlevel2",1);
       
    }
    public void MouseOut()
    {
        Level2Ani.SetFloat("selectlevel2", -1);

    }
    public void ClickLevel()
    {
        SceneManager.LoadScene("level2");
       
    }
}

