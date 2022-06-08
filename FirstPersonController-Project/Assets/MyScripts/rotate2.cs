using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate2 : MonoBehaviour
{
   //use to control the rotation of the object

    public Transform from;
    public Transform to;

    private float timeCount = 0.0f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //use quaternion.slerp to control the rotation
      transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, timeCount);
      timeCount = timeCount + Time.deltaTime;    

    }
}
