using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource finishScene;
    private Animator anim;


    // Update is called once per frame
    void Update()
    {
        finishScene = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Complete");
            finishScene.Play();
            anim.SetTrigger("FinishLv1");   
            Invoke("CompleteLevel1", 3f);
           // CompleteLevel1();


        }
    }



    private void CompleteLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
