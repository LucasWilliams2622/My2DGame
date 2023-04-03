
using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour
{

    public int id = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

           // CheckpointManagerScript.instance.AddCheckpoint(transform.position);




            /*CheckpointManagerScript.instance.AddCheckpoint(id, transform.position);
            
            CheckpointManagerScript.instance.SetLastCheckpoint(id);
            id++;
            Debug.Log(id + "id ne");*/
        }
    }
}
