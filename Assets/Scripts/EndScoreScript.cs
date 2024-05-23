using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScoreScript : MonoBehaviour
{
    public Text score;
    public static int endscore;
    

    private void Update()
    {
        endscore = ScoreScript.endscore;
        score.text = "Score:"+endscore;
    }
}
