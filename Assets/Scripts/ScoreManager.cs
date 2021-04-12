using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public CameraMovement cameracomp;
    public Instantiator instance;
    public List<GameObject> score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cameracomp.reseteable)
        {
            
        }
    }
}
