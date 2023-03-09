using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /*private bool isHurt ;*/
    [SerializeField] private AudioSource hitSound;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); 
        anim = GetComponent<Animator>();
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
            anim.SetTrigger("EnemyHurt");
            if (stack == diePoint)
            {
                Destroy(gameObject);
                /*Invoke("CompleteLevel1", 3f);*/
                Die();
            }
            else
            {
                return;
            }
        }
    }
    private void Die()
    {
        // playerDeath.Play();
        Debug.Log("Enemy dead");

        anim.SetTrigger("death");
    }
    // Update is called once per frame
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
