using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public GameObject elevator; // Object Elevator
    private bool playerInTrigger; // Kiểm tra player có trong vùng trigger
    public float speed;
    public Transform nextPos;

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

    private void Update()
    {
        //Debug.Log("playerInTrigger"+ playerInTrigger);
        if (playerInTrigger && Input.GetKey(KeyCode.E))
        {
            Debug.Log("playerInTrigger" + playerInTrigger);
            // Di chuyển object Elevator lên trên
            elevator.transform.Translate(Vector2.up * Time.deltaTime);
            //elevator.transform.position = Vector3.MoveTowards(elevator.transform.position, nextPos, speed * Time.deltaTime);

        }
    }


}
