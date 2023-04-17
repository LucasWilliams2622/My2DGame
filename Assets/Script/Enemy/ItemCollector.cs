using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemCollector : MonoBehaviour
{
    //public UnityEngine.UI.Text My_Text;
    public static int scores;
    public int ScorePlus;
    public TextMeshProUGUI scoreText;
    [SerializeField] private AudioSource collectItemSound;
    private void Start()
    {
        ScorePlus = 1;
        scores = 0;
        scoreText.text = "";
        UpdateScoreText();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            collectItemSound.Play();
            onIncrementScore(ScorePlus);
        }
    }
    public void onIncrementScore(int scorePlus)
    {
        scores = scores + scorePlus;
        PlayerPrefs.SetInt("score", scores);
        PlayerPrefs.Save();
        Debug.Log(scores);

        UpdateScoreText();
    }
    public void UpdateScoreText()
    {
        Debug.Log(scores);
        scoreText.text = "" + scores;
        
       

    }
}
