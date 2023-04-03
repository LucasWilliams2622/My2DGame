using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCheckpoint : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 lastCheckpointPos;

    public static Vector3 lastPlayerPos;
    void Start()
    {
        if(CheckpointManagerScript.instance.GetLastCheckpoint() != Vector2.zero)
        {
            lastCheckpointPos = CheckpointManagerScript.instance.GetLastCheckpoint();
            transform.position = lastCheckpointPos;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Checkpoint"))
        {



           /* Debug.Log("aaaaaaaaaaaaaaaaa");
            lastCheckpointPos = CheckpointManagerScript.instance.GetLastCheckpoint();
            CheckpointScript checkpoint = other.GetComponent<CheckpointScript>();
            if (checkpoint != null)
            {
                CheckpointManagerScript.instance.SetLastCheckpoint(checkpoint.id);
            }*/
        }
    }
    public void Replay()
    {
        Debug.Log("Click");
        Vector2 posPlayer = CheckpointManagerScript.instance.GetLastCheckpoint();

        transform.position= posPlayer;

    }
}
