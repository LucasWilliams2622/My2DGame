using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingBox : MonoBehaviour
{

    private int timesGotShoot;
    public int NumOfEndurance = 4;
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
        if (collision.gameObject.tag == "Hurt")
        {
            timesGotShoot++;
           // Debug.Log(timesGotShoot + "times");
            if (timesGotShoot == NumOfEndurance)
            {
                Debug.Log("Destroy");

                Destroy(gameObject);
            }
        }
    }
}
