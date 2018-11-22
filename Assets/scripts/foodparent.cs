using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodparent : MonoBehaviour {

    public string foodkind;
    public static float pluspoint;
    public static float newpoint;
    public static float addpoint(float currentpoint,string foodname)
    {   if (foodname=="blackfood")
        { newpoint = currentpoint + 1;}
        if (foodname == "3blackfood")
        { newpoint = currentpoint + 3; }
        if (foodname == "whitefood")
        { newpoint = currentpoint + 1; }
        if (foodname == "3whitefood")
        { newpoint = currentpoint + 3; }
        return newpoint;
    }

}
