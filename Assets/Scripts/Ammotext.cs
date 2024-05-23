using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammotext : MonoBehaviour
{
public static int Ammo=10;
public int totalammo;
public Text Ammodisplay;

    // Update is called once per frame
    void Update()
    {
        totalammo=Ammo;
        Ammodisplay.text="Ammo: "+totalammo;
        

    }
}
