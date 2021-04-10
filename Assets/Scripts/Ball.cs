using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 0.5f;
    public GameObject DirectionArrow;
    public TMPro.TMP_Text strength;
    public GameObject ui;
    public bool hitspace = false;
    public bool hitspacetwice = false;
    public bool hitspacefinal = false;
    private bool hitcornerright = false;
    private bool hitcornerleft = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hitspace)
        {
            if (transform.position.z > 0.6f && !hitcornerleft)
            {
                hitcornerleft = true;
            }
            if (transform.position.z < -0.6f && !hitcornerright)
            {
                hitcornerright = true;
            }
            if (hitcornerright)
            {
                speed *= -1;
                hitcornerright = false;
            }
            if (hitcornerleft)
            {
                speed *= -1;
                hitcornerleft = false;
            }
            transform.position = new Vector3(this.transform.position.x, this.transform.position.y, (this.transform.position.z + speed * Time.deltaTime));
        }
        if (hitspacetwice && (Input.GetKeyUp(KeyCode.Space)))
        {
            hitspacefinal = true;
        }
        if (hitspace && (Input.GetKeyUp(KeyCode.Space)))
        {
            hitspacetwice = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            hitspace = true;
        }
        if (hitspace)
        {
            DirectionArrow.SetActive(true);
        }
        if (hitspacetwice)
        {
            ui.SetActive(true);
        }
        if (hitspacefinal)
        {

        }
    }
}
