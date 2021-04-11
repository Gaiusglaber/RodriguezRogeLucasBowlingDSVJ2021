using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{

    public TMPro.TMP_Text pinetext01;
    public TMPro.TMP_Text pinetext02;
    private int cantpines=10;
    private int pinesdown;
    public GameObject pinePrefab;
    public List<GameObject> generatedPines=new List<GameObject>(); 
    void Start()
    {
       Vector2[] pinePositions = new Vector2[10]{
       new Vector2 ( 0, 0 ),

       new Vector2 ( 0.3f, 0.3f ),
       new Vector2 ( 0.3f, -0.3f ),

       new Vector2 ( 0.6f, 0),
       new Vector2 ( 0.6f, 0.45f ),
       new Vector2 ( 0.6f, -0.45f ),

       new Vector2 ( 0.9f, -0.6f ),
       new Vector2 ( 0.9f, -0.3f ),
       new Vector2 ( 0.9f, 0.3f ),
       new Vector2 ( 0.9f, 0.6f ) };
       for (short i = 0; i < 10; i++) {
           GameObject instantiator = Instantiate(pinePrefab, new Vector3(this.transform.position.x+pinePositions[i].x, 0, this.transform.position.z+pinePositions[i].y), Quaternion.identity).gameObject;
           instantiator.AddComponent<MeshCollider>();
           instantiator.AddComponent<Rigidbody>();
           instantiator.GetComponent<Rigidbody>().mass = 1.5f;
           instantiator.GetComponent<MeshCollider>().sharedMesh = instantiator.GetComponentInChildren<MeshFilter>().mesh;
           instantiator.GetComponent<MeshCollider>().convex = true;
           generatedPines.Add(instantiator);
       }
    }

    // Update is called once per frame
    void Update()
    {
        pinesdown = 0;
        foreach (GameObject pine in generatedPines)
        {
            //Debug.Log(pine.transform.rotation);
            if (Mathf.Abs(pine.transform.rotation.x)> Mathf.Abs(0.2f) || Mathf.Abs(pine.transform.rotation.z)> Mathf.Abs(0.5f)) 
            {
                pinesdown++;
            }
        }
        if (cantpines - pinesdown == 0)
        {
            pinetext02.text = "STRIKE!";
            pinetext01.text = " ";
        }
        else
        {
            pinetext01.text = "" + (cantpines - pinesdown);
        }
        
    }
}
