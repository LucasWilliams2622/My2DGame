using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject panelDead;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHeallth(currentHealth);
        /*Debug.Log("healthBar.slider.minValue" + healthBar.slider.minValue);
        Debug.Log("healthBar.slider.minValue" + healthBar.slider.maxValue);*/
    }


    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.tag == "Trap")
        {

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            TakeDamage(1);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            TakeDamage(1);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth == healthBar.slider.minValue)
        {
            Debug.Log("DEAD");
            Time.timeScale = 0f;
            panelDead.SetActive(true);
        }
    }
}
