using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    //u can get this variable (currentHealth) in any script 
    //but the private set mean u only can set variable (currentHealth) in this script
    private Animator anim;
    private bool dead;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage( float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if(currentHealth>0)
        {
            //player hurt
            anim.SetTrigger("hurt");
        }
        else
        {
            if(!dead)
            {
                //player dead
                anim.SetTrigger("death");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
          
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1); 
        }
    }
}
