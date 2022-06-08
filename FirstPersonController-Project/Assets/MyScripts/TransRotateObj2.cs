using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransRotateObj2 : MonoBehaviour
{
    public GameObject prefab; 

    private Vector3 direction = new Vector3(0,0,-10);

    private Vector3 angle = new Vector3(1,1,1);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime, Space.World);
        transform.Rotate(angle, Space.World);

    }

    //to dedect collision
    void OnCollisionEnter(Collision obj)             //obj is the object they collide with
    {                                                //tells you which object it collides with
        if(obj.gameObject.tag == "SecondObject")
        {   //if there's an object with the tag "SecondObject", then it'll instantiate 
            Instantiate(prefab, obj.gameObject.transform.position, Quaternion.identity); 
            Destroy(obj.gameObject);
            //Destroy(gameObject); //can destroy object itself
            
        }
    }
}
