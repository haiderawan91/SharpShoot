using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammobox : MonoBehaviour
{
    public AudioSource ammoaud;
    
    void OnTriggerEnter(Collider other)
    {
        
        ammoaud.Play();
        Ammotext.Ammo+=15;
        Destroy(gameObject);
    
   
    }
}

