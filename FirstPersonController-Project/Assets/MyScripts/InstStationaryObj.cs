using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstStationaryObj : MonoBehaviour
{
  //This code instantiates/generates objects when user presses a key,
  //but keeps object at same spot

    public GameObject prefab;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, new Vector3(449.59f, 42.64f, -52.5f), Quaternion.identity);
             
        }
    }
}
