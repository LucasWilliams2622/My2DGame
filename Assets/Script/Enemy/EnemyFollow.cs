using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    public float thrownSpace;
    private SpriteRenderer sprite;

    private Animator anim;
    private int stack;
    public int diePoint;
    private ScoreManager scoreManager;
    [SerializeField] private AudioSource hitSound;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TrampolineTop")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, thrownSpace);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hurt")
        {
            hitSound.Play();
            stack++;
            //anim.SetTrigger("EnemyHurt");
            if (stack == diePoint)
            {
             
                if (gameObject.tag == "Boss")
                {
                    var player = GameObject.FindGameObjectsWithTag("Player");
                    ItemCollector itemCollector = player[0].gameObject.GetComponent<ItemCollector>();
                    itemCollector.onIncrementScore(10);
                    itemCollector.UpdateScoreText();
                    Destroy(gameObject);
                 
                

                }
                else
                {
                    var player = GameObject.FindGameObjectsWithTag("Player");
                    ItemCollector itemCollector = player[0].gameObject.GetComponent<ItemCollector>();
                    itemCollector.onIncrementScore(5);
                    itemCollector.UpdateScoreText();
                    Destroy(gameObject);

                }
            }
            else
            {
                return;
            }
        }
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        if (player.transform.position.x > 0f)
        {
            sprite.flipX = true;
        }
        else if (player.transform.position.x < 0f)
        {
            sprite.flipX = false;
        }
    }
 

}
