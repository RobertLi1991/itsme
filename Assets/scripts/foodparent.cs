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
            {ScoreManager.score1+=10; }
            if (this.gameObject.name == "3whitefood")
            { ScoreManager.score1+=30; }
        }
        if (other.GetComponent<playercontrol2>() != null)
        {
            if (this.gameObject.name == "whitefood")
            { ScoreManager.score2 += 10; }
            if (this.gameObject.name == "3whitefood")
            { ScoreManager.score2 += 30; }
        }
    }
    

}
