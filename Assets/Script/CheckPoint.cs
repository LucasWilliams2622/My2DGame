using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag =="Player")
        {
            PlayerLife.lastCheckPoint = transform.position;
        }
    }
}
