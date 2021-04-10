using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject pinePrefab;
    public List<GameObject> generatedPines;
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
       generatedPines.Capacity = 10;
       for (short i = 0; i < 10; i++) {
           GameObject instantiator = Instantiate(pinePrefab, new Vector3(this.transform.position.x+pinePositions[i].x, 0, this.transform.position.z+pinePositions[i].y), Quaternion.identity).gameObject;
            generatedPines.Add(instantiator);
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
