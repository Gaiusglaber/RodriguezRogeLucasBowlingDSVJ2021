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
    private bool bouncetime = false;
    private Color textcolor = new Color(0, 1, 0);
    float valuestrength=0;
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
        if (hitspace&& !hitspacefinal)
        {
            DirectionArrow.SetActive(true);
        }
        if (hitspacetwice&&!hitspacefinal)
        {
            ui.SetActive(true);

            if (bouncetime)
            {
                if (textcolor.r < 1)
                    textcolor.r += 0.01f;
                else if (textcolor.g > 0)
                    textcolor.g -= 0.01f;

                valuestrength += 0.5f;
            }
            else
            {
                if (textcolor.g < 1)
                    textcolor.g += 0.01f;
                else if (textcolor.r > 0)
                    textcolor.r -= 0.01f;

                valuestrength -= 0.5f;
            }
            if (valuestrength>100)
            {
                bouncetime = false;
            }else if (valuestrength < 0)
            {
                bouncetime = true;
            }
            Debug.Log(textcolor);
            strength.color = textcolor;
            
            strength.text = ""+(short)valuestrength;
        }
        if (hitspacefinal)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(valuestrength, 0, DirectionArrow.transform.rotation.y*10));
            DirectionArrow.SetActive(false);
        }
    }
}
