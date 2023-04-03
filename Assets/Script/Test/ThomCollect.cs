using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThomCollect : MonoBehaviour
{
    /*private int cherries = 0;
    public TextMeshProUGUI cherriesText;*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*       void Start()
               {
                   cherriesText = GetComponent<Text>();
               }*/


        if (collision.gameObject.CompareTag("Player"))
        {
           /* collision.transform.localScale = new Vector3(0.75f, 0.75f, 0);
            collision.transform.localScale = new Vector3(0.50f, 0.50f, 0);
            collision.transform.localScale = new Vector3(0.25f, 0.25f, 0);*/
            collision.transform.localScale = new Vector3(1.5f, 1.5f, 0);

            transform.localScale = new Vector3(0.2f,0.2f, 0);

         
            Destroy(gameObject, 3f);
           
            /* var name = collision.attachedRigidbody.name;
             Destroy(gameObject.Find(name));*/
        }


        /*if (cherriesText == null)
        {
            Debug.Log("Null Object");
        }
        else
        {
            Debug.Log("Not Object");

        }*/

    }
}
