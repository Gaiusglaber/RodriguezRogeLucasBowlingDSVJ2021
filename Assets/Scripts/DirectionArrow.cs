using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrow : MonoBehaviour
{
    public float speed;
    public bool bounce = false;
    private bool presspace = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            presspace = true;
        }
        if (!presspace)
        {
            if (bounce)
            {
                this.transform.Rotate(0, speed * Time.deltaTime, 0, Space.World);
            }
            else
            {
                this.transform.Rotate(0, -(speed * Time.deltaTime), 0, Space.World);
            }
            if (this.transform.rotation.y > 0.4f)
            {
                bounce = true;
            }
            else if (this.transform.rotation.y < -0.4f)
            {
                bounce = false;
            }
        }
    }
}
