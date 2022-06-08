using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyController : MonoBehaviour
{
    public Transform target;
    public GameObject explosion; 
    private float speed;

    public NotificationManager manager = null; //listener


    // Start is called before the first frame update
    void Start()
    {
        speed = 0.0f; //2.0f

        if(manager != null)
        {
            manager.AddListener(this, "Touch");
            manager.AddListener(this, "Fire");
        }
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

    public void Touch()
    {
        speed = 1f; //change speed from 0 to 1
    }

    public void Fire()
    {
        speed = 2f;
    }
}
