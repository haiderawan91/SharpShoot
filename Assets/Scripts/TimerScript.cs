using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{

    public Text timer;
    public bool timing = false;
    public int seconds =0;
    public static int sec;
    public static int secs;
    // Update is called once per frame
    void Update()
    {
        sec = seconds;
        if (!timing)
        {
            
            StartCoroutine(Substractsecond());
            secs = seconds;
        }

    }
    IEnumerator Substractsecond()
    {
        timing = true;
        seconds += 1;
        timer.text = "Time:" + seconds;
        yield return new WaitForSeconds(1);
        timing = false;
    }
}
