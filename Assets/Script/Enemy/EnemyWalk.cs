using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public float left, right;
    private SpriteRenderer sprite;

   
    private bool isRight;
    public float speedRun;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

    }
   
    // Update is called once per frame
    void Update()
    {
        var enemyX = transform.position.x;
        if (enemyX < left)
        {
            isRight = true;
        }
        if (enemyX > right)
        {
            isRight = false;
        }
        if (isRight)
        {
            sprite.flipX = true;
            transform.Translate(new Vector3(Time.deltaTime * speedRun, 0, 0));
        }
        else
        {
            sprite.flipX = false;
            transform.Translate(new Vector3(-Time.deltaTime * speedRun, 0, 0));
        }


    }
}
