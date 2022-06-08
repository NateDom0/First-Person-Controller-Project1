using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstObject : MonoBehaviour
{
    //This code instantiates/generates objects when user presses a key

    public GameObject prefab;
    private int d; //use to instantiate object in different positions 

    // Start is called before the first frame update
    void Start()
    {
        d = -40;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, new Vector3(449.59f, 42.64f, d), Quaternion.identity);
            d +=10; 
        }
    }
}
