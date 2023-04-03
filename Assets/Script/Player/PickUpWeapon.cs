using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject BoxWeapon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BoxWeapon")
        {
            Gun.SetActive(true);
            BoxWeapon.SetActive(false);
            PlayerShooting shootingScript = GetComponent<PlayerShooting>();
            shootingScript.enabled = true;
            shootingScript.MountOfBullet = shootingScript.MountOfBullet + 20;
            shootingScript.BulletLeftText.text = " " + shootingScript.MountOfBullet;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
