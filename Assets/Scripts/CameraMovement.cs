using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float cameraHeight = 0.5f;
    public float cameraX = -1f;
    public float cameramaxY = 2;
    public bool reseteable = false;
    public bool resets = false;
    void Start()
    {
          
    }
    public void instantiate()
    {
        cameraHeight = 0.5f;
        cameraX = -1f;
        cameramaxY = 2;
        reseteable = false;
        resets = false;
    }
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
                cameramaxY += 0.01f;
            }
            else
            {
                reseteable = true;
            }

            if (reseteable && Input.GetKeyUp(KeyCode.R))
            {
                Debug.Log("resets camera");
                resets = true;
            }
            transform.position = new Vector3(this.transform.position.x, cameramaxY, this.transform.position.z);
        }
    }
}
