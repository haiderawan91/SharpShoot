using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCube : MonoBehaviour
{
    public GameObject[] targetarr;
    
    public GameObject player;

    public GameObject ingamescore;
    public GameObject ingameammo;
    public GameObject ingametime;

    public GameObject showtime;
    public GameObject showscore;
    
    public GameObject bttn;
    public GameObject bttn2;



    void OnTriggerEnter(Collider other)
    {
        targetarr = GameObject.FindGameObjectsWithTag("Target");
        if (targetarr.Length == 0)
        {
            ingametime.SetActive(false);
            ingamescore.SetActive(false);
            ingameammo.SetActive(false);
            player.SetActive(false);
            
            showscore.SetActive(true);
            showtime.SetActive(true);

            bttn.SetActive(true);
            bttn2.SetActive(true);
            showscore.GetComponent<Text>().text = "Score:" + EndScoreScript.endscore;
            showtime.GetComponent<Text>().text = "Remaining Time(s):" + TimerScript.sec;
        }
    }
            
        

    
    
    
}
