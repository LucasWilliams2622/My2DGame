using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformUp : MonoBehaviour
{
    public float thrownSpace;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("aaaaaaaaa");
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, thrownSpace);
        }
    }
}