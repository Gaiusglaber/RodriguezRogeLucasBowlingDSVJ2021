using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float cameraHeight = 20.0f;
    public float cameraX = 5.0f;
    public float cameramaxY = 2;
    public bool reseteable = false;
    void LateUpdate()
    {
        cameramaxY = this.transform.position.y;
        if (transform.position.x < 11) // llega a un poco antes de chocar los pinos
        {
            Vector3 pos = player.transform.position;
            pos.y += cameraHeight;
            pos.x += cameraX;
            transform.position = pos;
        }
        else
        {
            if (cameramaxY < 4.5f)
            {
                cameramaxY += 0.006f;
            }
            else
            {
                reseteable = true;
            }
            transform.position = new Vector3(this.transform.position.x, cameramaxY, this.transform.position.z);
        }
    }
}
