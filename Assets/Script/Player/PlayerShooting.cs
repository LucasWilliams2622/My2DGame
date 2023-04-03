using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public Transform Gun;
    Vector2 direction;
    public GameObject Bullet;
    public int MountOfBullet = 0;
    public float BulletSpeed;
    public Transform ShootPoint;
    public TextMeshProUGUI BulletLeftText;
    public GameObject showShootPoint;
    //public float fireRate;
    float ReadyForNextShot;
    [SerializeField] private AudioSource sniperSound;
    [SerializeField] private AudioSource chargingSound;
    [SerializeField] private AudioSource outOfBulletSound;
    private int times = 0;


    // Start is called before the first frame update
    void Start()
    {
        showShootPoint.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;
        FaceMouce();
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > ReadyForNextShot)
            {
                // ReadyForNextShot = Time.time * 1 / fireRate;
                shoot();

            }
        }
    }
    void showFireShoot()
    {
        showShootPoint.SetActive(true);
        Invoke("hideFireShoot", 0.1f);
    }
    void hideFireShoot()
    {
        showShootPoint.SetActive(false);
    }
    void shoot()
    {
        if (MountOfBullet == 0)
        {
            outOfBulletSound.Play();
            BulletLeftText.text = " " + MountOfBullet;
        }
        else
        {
            sniperSound.Play();
            showFireShoot();

            times++;
            MountOfBullet--;
            /* Debug.Log("Times shoot :" + times);
             Debug.Log("MountOfBullet" + MountOfBullet);*/
            BulletLeftText.text = " " + MountOfBullet;

            if (times % 5 == 0)
            {
                Debug.Log("Charging Ammo");
                chargingSound.Play();
            }
            GameObject BulletInstant = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);

            BulletInstant.GetComponent<Rigidbody2D>().AddForce(BulletInstant.transform.right * BulletSpeed);
            Destroy(BulletInstant, 2);

        }

    }

    private void FaceMouce()
    {
        Gun.transform.right = direction;
    }
}
