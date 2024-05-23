using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int initialscore = 0;
    public int score ;
    public Text scoreText;
    public static int endscore;

    // Update is called once per frame
    void Update()
    {
        score = initialscore;
        endscore = score;

        scoreText.text = "Score:" + score;
    }
}
