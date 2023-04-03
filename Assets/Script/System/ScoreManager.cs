using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
  
    private int score = 0;

    public void IncrementPoint()
    {
        score += 1; 
        Debug.Log("Score: " + score);
    }

 
}
