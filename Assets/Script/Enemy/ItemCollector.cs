using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemCollector : MonoBehaviour
{
    //public UnityEngine.UI.Text My_Text;
    public int scores = 0;
    public TextMeshProUGUI scoreText;
    [SerializeField] private AudioSource collectItemSound;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*       void Start()
               {
                   scoresText = GetComponent<Text>();
               }*/


        if (collision.gameObject.CompareTag("Cherry"))
        {
            /*collision.transform.localScale = new Vector3(0.75f, 0.75f, 0);
            collision.transform.localScale = new Vector3(0.50f, 0.50f, 0);
            collision.transform.localScale = new Vector3(0.25f, 0.25f, 0);
            collision.transform.localScale = new Vector3(0.5f, 0.5f, 0);*/
            /* var name = collision.attachedRigidbody.name;
             Destroy(gameObject.Find(name));*/
            //transform.localScale = new Vector3(2f, 2f, 0);

            collectItemSound.Play();
            Destroy(collision.gameObject);
            scores++;

            scoreText.text = "" + scores;


        }




    }
}
