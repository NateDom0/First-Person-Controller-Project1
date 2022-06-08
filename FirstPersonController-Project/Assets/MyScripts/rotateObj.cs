using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObj : MonoBehaviour
{
    //this program allows the object to rotate

    private Vector3 angle;

    // Start is called before the first frame update
    void Start()
    {
        angle = new Vector3(1,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(angle, Space.World);
    }
    
}
