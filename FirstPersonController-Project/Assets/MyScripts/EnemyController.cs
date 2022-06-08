using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public GameObject explosion; 
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        speed = 2.0f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target); //force enemy to face the robot
        transform.position += transform.forward * speed * Time.deltaTime;

    }

    void OnCollisionEnter(Collision col) //col represents the object that collides with the enemy
    {
        if(col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this);
            Destroy(gameObject);
            
        }
    }

}
