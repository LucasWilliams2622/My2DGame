using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{   //everything in the game is in GameObject

    /*[SerializeField] private GameObject[] waypoints;//add waypoint to use in script
    private int currentWayPointIndex = 0;
    [SerializeField] private float speed = 2f;
    // Update is called once per frame
    private void Update()
    {
        Debug.Log("1");
        if (Vector2.Distance(waypoints[currentWayPointIndex].transform.position, transform.position) < .1f)
        {
            Debug.Log("2");

            currentWayPointIndex++;
            if (currentWayPointIndex >= waypoints.Length)
            {
                Debug.Log("3");

                currentWayPointIndex = 0;
            }
            //switch    
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, Time.deltaTime * speed);
        }
    }*/


    public Transform pos1, pos2;
    public float speed = 2f;
    public Transform startPos;

    Vector3 nextPos;
    private void Start()
    {
        nextPos = startPos.position;
    }
    private void Update()
    {
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
    
}
