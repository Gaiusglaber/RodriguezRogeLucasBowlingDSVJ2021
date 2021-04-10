using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float cameraHeight = 20.0f;
    public float cameraX = 5.0f;
    public float cameramaxY = 2;

    void LateUpdate()
    {
        cameramaxY = this.transform.position.y;
        if (transform.position.x < 11)
        {
            Vector3 pos = player.transform.position;
            pos.y += cameraHeight;
            pos.x += cameraX;
            transform.position = pos;
        }
        else
        {
            if (cameramaxY < 1.4f)
            {
                cameramaxY += 0.006f;
            }
            transform.position = new Vector3(this.transform.position.x, cameramaxY, this.transform.position.z);
        }
    }
}
