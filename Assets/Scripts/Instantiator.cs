using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{

    public TMPro.TMP_Text pinetext01;
    public TMPro.TMP_Text pinetext02;
    public int cantpines=10;
    public int pinesdown;
    public int pinesup;
    public GameObject pinePrefab;
    public List<GameObject> generatedPines=new List<GameObject>();
    public CameraMovement cameracomp;
    public Ball ball;

    public void init() 
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
        for (short i = 0; i < 10; i++)
        {
            GameObject instantiator = Instantiate(pinePrefab, new Vector3(this.transform.position.x + pinePositions[i].x, 0, this.transform.position.z + pinePositions[i].y), Quaternion.identity).gameObject;
            instantiator.AddComponent<MeshCollider>();
            instantiator.AddComponent<Rigidbody>();
            instantiator.GetComponent<Rigidbody>().mass = 1.5f;
            instantiator.GetComponent<MeshCollider>().sharedMesh = instantiator.GetComponentInChildren<MeshFilter>().mesh;
            instantiator.GetComponent<MeshCollider>().convex = true;
            generatedPines.Add(instantiator);
        }
    }
    public void deinit()
    {
        foreach (GameObject pine in generatedPines)
        {
            Destroy(pine);
        }
        generatedPines.Clear();
    }
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        pinesdown = 0;
        foreach (GameObject pine in generatedPines)
        {
            //Debug.Log(pine.transform.rotation);
            if (Mathf.Abs(pine.transform.rotation.x)> 0.2f || Mathf.Abs(pine.transform.rotation.z)> 0.5f) 
            {
                pinesdown++;
            }
        }
        pinesup = cantpines - pinesdown;
        if (cameracomp.resets)
        {
            cameracomp.transform.position = new Vector3(3.0111f, 0.847f, 0.05f);
            ball.transform.position = new Vector3(3.75f, 0.25f,0);
            ball.instantiate();
            cameracomp.instantiate();
        }
    }
}
