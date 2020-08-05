using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    static int score = 0;
   static Text scoreboard;

    private void Start()
    {
        scoreboard = gameObject.GetComponent<Text>();
        scoreboard.text = "";
    }
    static public void AddScore(int scoreCost)
    {
            score += scoreCost;
            scoreboard.text = score.ToString(); 
    }
    static public void Delete()
    {
        score = 0;
        scoreboard.text = score.ToString();
    }
  
}
