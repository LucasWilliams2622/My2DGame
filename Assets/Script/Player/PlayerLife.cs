using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float damage;
    //public Vector2 startPos;
    // Start is called before the first frame update
    [SerializeField] private AudioSource playerDeath;

    // public static Vector2 lastCheckPoint = new Vector2(14,0);
    private Vector2 lastCheckpointPos;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
   /*     if (other.tag == "Trap")
        {
            Die();

            *//* Debug.Log("dame");
             collision.GetComponent<Health>().TakeDamage(damage);*//*
        }
        if (collision.gameObject.tag == "Trap")
        {
            Time.timeScale = 0;
            panal.SetActive(true);
            text.SetActive(true);
            button.SetActive(true);
            jumpSoundEffet.Stop();
            //   Destroy(gameObject);

        }*/

    }
    private void Die()
    {
        playerDeath.Play();

        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    public void ReStartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        /*        anim.SetTrigger("");

                transform.position = startPos;
                rb.bodyType = RigidbodyType2D.Dynamic;*/

    }
}
