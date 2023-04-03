using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    // Start is called before the first frame update


    public TMPro.TMP_InputField myName;
    public TMPro.TextMeshProUGUI myScore;
    public int currentScore;

    void Update()
    {

        myScore.text = $"SCORE: {PlayerPrefs.GetInt("highscore")}";

    }
    public void SendScore()
    {
        if (currentScore > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", currentScore); HighScores.UploadScore(myName.text, currentScore);
        }

    }
}