using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speed = 0.5f;
    public GameObject directionArrow;
    public TMPro.TMP_Text strength;
    public GameObject ui;
    public bool hitspace = false;
    public bool hitspacetwice = false;
    public bool hitspacefinal = false;
    public bool bounce = false;
    public bool bouncetime = false;
    public Color textcolor = new Color(0, 1, 0);
    public float valuestrength=0;
    void Start()
    {

    }
    public void instantiate()
    {
        hitspace = false;
        hitspacetwice = false;
        hitspacefinal = false;
        bounce = false;
        bouncetime = false;
        textcolor = new Color(0, 1, 0);
        valuestrength = 0;
        ui.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (!hitspace)
        {
            if (transform.position.z > 0.6f)
            {
                bounce = true;
            }
            else if (transform.position.z < -0.6f)
            {
                bounce = false;
            }
            if (bounce)
            {
                transform.position = new Vector3(this.transform.position.x, this.transform.position.y, (this.transform.position.z - speed * Time.deltaTime));
            }
            else
            {
                transform.position = new Vector3(this.transform.position.x, this.transform.position.y, (this.transform.position.z + speed * Time.deltaTime));
            }

            
            
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
            directionArrow.SetActive(true);
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
            strength.color = textcolor;
            
            strength.text = ""+(short)valuestrength;
        }
        if (hitspacefinal)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(valuestrength/100, 0, (directionArrow.transform.rotation.y/2)*-1),ForceMode.Impulse);
            directionArrow.SetActive(false);
        }
    }
}
