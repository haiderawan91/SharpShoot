using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
   
    public float health = 50f;
    
    public void takedamage(float amount)
    {
        health = health - amount;
        if (health <= 0)
            die();
    }
    void die() {
        ScoreScript.initialscore += 1;
        Destroy(this.gameObject);
    }
}