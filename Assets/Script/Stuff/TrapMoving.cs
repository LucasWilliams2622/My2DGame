using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMoving : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
    private bool playerInTrigger; // Kiểm tra player có trong vùng trigger
    public GameObject elevator; // Object Elevator
    Vector3 nextPos;
    private bool elevatorUp = false;
    private int keyupCooldown = 0;
    private int tick = 0;

    void Start()
    {
        nextPos = startPos.position;
    }

    
    private void Update()
    {
        tick++;     
        if (playerInTrigger && Input.GetKey(KeyCode.E) && keyupCooldown < tick)
        {
            keyupCooldown = tick + 64;
            elevatorUp = !elevatorUp;
            
            if(elevatorUp)
            {
                Debug.Log("goPos1" + tick);
              
            } else
            {
                Debug.Log("goPos2" + tick);
              
            }
        }

        if(elevatorUp)
        {
            if(pos2.position != elevator.transform.position)
            {
                elevator.transform.position = Vector3.MoveTowards(elevator.transform.position, pos2.position, speed * Time.deltaTime);
            }
        } else
        {
            if (pos1.position != elevator.transform.position)
            {
                elevator.transform.position = Vector3.MoveTowards(elevator.transform.position, pos1.position, speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("IN");
            playerInTrigger = true; // Gán biến playerInTrigger = true khi player va chạm với trigger
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("OUT");
            playerInTrigger = false; // Gán biến playerInTrigger = false khi player rời khỏi trigger
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
