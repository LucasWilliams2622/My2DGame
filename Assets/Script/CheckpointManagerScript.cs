using UnityEngine;
using System.Collections.Generic;

public class CheckpointManagerScript : MonoBehaviour
{

    public static CheckpointManagerScript instance;
    // private Dictionary<int, Vector2> checkpoints = new Dictionary<int, Vector2>();
    public Vector2 lastCheckpointTransform = Vector2.zero;
    private int lastCheckpoint = 1 ;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /* public void AddCheckpoint(int id, Vector2 pos)
     {
         checkpoints[id] = pos;
     }
 */
    public void AddCheckpoint(Vector2 position)
    {
        lastCheckpointTransform = position;
    }
    /* public void SetLastCheckpoint(int id)
     {
         lastCheckpoint = id;
     }*/
    public Vector2 GetLastCheckpoint()
    {
        return lastCheckpointTransform;

    }
    /* public Vector2 GetLastCheckpoint()
     {

         return checkpoints[lastCheckpoint];
     }*/
}
