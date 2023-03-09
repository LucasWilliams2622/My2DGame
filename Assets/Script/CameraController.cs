using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    // Update is called once per frame
   
    private void Update()
    {
       /* if (playerX > start && playerX < end)
        {
            camX = playerX;
        }
        else
        {
            if (playerX < start)
            {
                camX = start;
            }

            if (playerX > end)
            {
                camX = end;
            }
        }*/
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        //Vector3 cause the camera is a 3D object   
    }
}
