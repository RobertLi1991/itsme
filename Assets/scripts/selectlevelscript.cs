using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class selectlevelscript : MonoBehaviour {
    public Animator Level1Ani;
    public float SelectedFlag=-1;
	// Use this for initialization
	public void MouseIn()
    {
        Level1Ani.SetFloat("selected",1);
       
    }
    public void MouseOut()
    {
        Level1Ani.SetFloat("selected", -1);

    }
    public void ClickLevel()
    {
        SceneManager.LoadScene("level1");
       
    }
}

