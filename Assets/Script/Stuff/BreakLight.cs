using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakLight : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject LightObj;
    [SerializeField] private AudioSource breakLightSound;

    void Start()
    {
           

    }

  
    void Update()
    {
        
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hurt"))
        {
            breakLightSound.Play();
            Destroy(LightObj);
        }
        if (collision.gameObject.tag == "Player")
        {         
            breakLightSound.Play();
            Destroy(LightObj);
        }
    }
  
}
