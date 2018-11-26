using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodparent : MonoBehaviour {

    public string foodkind;
    public static float pluspoint;
    public static float newpoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<playercontrol>() != null)
        {
            if (this.gameObject.name == "whitefood")
            {ScoreManager.score+=10; }
            if (this.gameObject.name == "3whitefood")
            { ScoreManager.score+=30; }
        }
    }
    

}
