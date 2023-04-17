using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class ScoresManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputScore;
    [SerializeField] private TMP_InputField inputName;
    public UnityEvent<string, int> submitScoreEvent;
    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));    
        // Update is called once per frame
     
    }

    private void Update()
    {
       
        if(inputScore.text != PlayerPrefs.GetInt("score").ToString())
        {
            inputScore.text = PlayerPrefs.GetInt("score").ToString();
        }
    }
}