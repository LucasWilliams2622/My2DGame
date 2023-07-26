using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    public bool isRight = true;

    public float thrownSpace;
    [SerializeField] private LayerMask jumableGround;
    private float dirX;// = 0f just in case
    [SerializeField] private float moveSpeed = 7f;//if some variable use many times u should use it like a global variable 
    [SerializeField] private float jumpForce = 10f;//SerializeField for set value on Editor 
    // use enum to assign the names or string values to integral constants, that make a program easy to read and maintain.
    private enum MovementState { idle, running, jumping, falling }//0 idle | 1 running | 2 jumping | 3 falling
    [SerializeField] private AudioSource playerDeath;
    [SerializeField] private AudioSource jumpSoundEffet;
    private Vector2 lastCheckpointPos;
    public static Vector3 lastPlayerPos;

    public GameObject frogDead,playerDead;
    public GameObject panelDead;

    void Start()
    {
        
        rigidbody2 = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();//get all component of Animator
        sprite = GetComponent<SpriteRenderer>();
        /*    if (CheckpointManagerScript.instance.GetLastCheckpoint() != Vector2.zero)
            {
                lastCheckpointPos = CheckpointManagerScript.instance.GetLastCheckpoint();
                transform.position = lastCheckpointPos;
            }*/
    }

    void Update()
    {
        rigidbody2.velocity = new Vector2(dirX * moveSpeed, rigidbody2.velocity.y);
        dirX = Input.GetAxisRaw("Horizontal");//GetAxisRaw make movemoment more smooth

        if ((Input.GetKey(KeyCode.Space) && isGround()))
        {
            jumpSoundEffet.Play();
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpForce);
        }
        UpdateAnimationState();

    }
    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            //anim.SetBool("running", true);
            state = MovementState.running;

            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            //anim.SetBool("running", true);
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
            // anim.SetBool("running", false);
        }

        if (rigidbody2.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        if (rigidbody2.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AmmunitionBox")
        {
            Destroy(collision.gameObject);
            PlayerShooting shootingScript = GetComponent<PlayerShooting>();
            shootingScript.MountOfBullet = shootingScript.MountOfBullet + 10;
            shootingScript.BulletLeftText.text = " " + shootingScript.MountOfBullet;

        }
       
        if (collision.gameObject.CompareTag("TouchLeft"))
        {
            Destroy(gameObject);
            Instantiate(playerDead,
            collision.gameObject.transform.position,
            collision.gameObject.transform.localRotation);
            panelDead.SetActive(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        /*  if (collision.gameObject.tag == "TouchTop")
          {
              var name = collision.attachedRigidbody.name;
              Destroy(GameObject.Find(name));
          }*/

        if (collision.gameObject.CompareTag("TouchTop"))
        {
            //frogDead.Play();
            var name = collision.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            Instantiate(frogDead,
             collision.gameObject.transform.position,
             collision.gameObject.transform.localRotation);
        }
    }

    public void ReloadScreeen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    private bool isGround()
    {
        // u have to get the collider of player to know touch the ground
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumableGround);
        // this line create a box around player if this box touch the layout name "Ground" player can jump again
    }
}
