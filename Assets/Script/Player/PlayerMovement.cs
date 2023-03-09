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
/*    private bool ground;*/
    //public GameObject boxPresent;
    public GameObject panal, text, button;
    public float thrownSpace;
    [SerializeField] private LayerMask jumableGround;
    private float dirX;// = 0f just in case
    [SerializeField] private float moveSpeed = 7f;//if some variable use many times u should use it like a global variable 
    [SerializeField] private float jumpForce = 10f;//SerializeField for set value on Editor 

    // use enum to assign the names or string values to integral constants, that make a program easy to read and maintain.
    private enum MovementState { idle, running, jumping, falling }//0 idle | 1 running | 2 jumping | 3 falling

    
    [SerializeField] private AudioSource jumpSoundEffet;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();//get all component of Animator
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        // directionX = dirX
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TouchLeft")
        {
            Time.timeScale = 0;
            panal.SetActive(true);
            text.SetActive(true);
            button.SetActive(true);
            jumpSoundEffet.Stop();
            //   Destroy(gameObject);

        }
        if (collision.gameObject.tag == "TouchTop")
        {
            var name = collision.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
        }
        if (collision.gameObject.tag == "TrampolineTop")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, thrownSpace);
        }
       /* if (collision.gameObject.tag == "BoxPresent")
        {
            var name = collision.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            Instantiate(boxPresent,
                collision.gameObject.transform.position,
                collision.gameObject.transform.localRotation);
        }*/
    }

    public void ReloadScreeen()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

    }
   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            ground = true;
            if (Input.GetKey(KeyCode.Space))
            {
                if (isRight)
                {
                    transform.Translate(Time.deltaTime * 5, Time.deltaTime * 10, 0);
                    Vector2 scale = transform.localScale;
                    scale.x *= scale.x > 0 ? 1 : -1;
                    transform.localScale = scale;
                }
                else
                {
                    transform.Translate(-Time.deltaTime * 5, Time.deltaTime * 10, 0);
                    Vector2 scale = transform.localScale;
                    scale.x *= scale.x > 0 ? -1 : 1;
                    transform.localScale = scale;

                }

                ground = false;

            }
        }
    }*/
    private bool isGround()
    {
        // u have to get the collider of player to know touch the ground
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumableGround);
        // this line create a box around player if this box touch the layout name "Ground" player can jump again
    }
}
