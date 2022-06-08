using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3 : MonoBehaviour
{
    //this script is updated to create FPS/first person controller
    //for assignment 6

    public float speed;
    public Transform feet;
    public LayerMask ground;
    private float jumpHeight;
    private Vector3 direction;
    private Rigidbody rbody;
    private float rotationSpeed;
    private float rotationX; 
    private float rotationY;
    private AudioSource audio;

    //new added variables
    public GameObject bulletPrefab;
    public Transform bulletSpawn; 
    private AudioSource audio2; //for gun sound


    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f; //original constant is 3.0f
        rotationSpeed = 2f;
        rotationX = 0;
        rotationY = 10f;
        jumpHeight = 5.0f;
        rbody = GetComponent<Rigidbody>();
        audio = GetComponents<AudioSource>()[0]; //change from GetComponent to GetComponents(plural)

        audio2 = GetComponents<AudioSource>()[1];

    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized; 
        if(direction.x != 0)
        {
            rbody.MovePosition(rbody.position + transform.right * direction.x * speed * Time.deltaTime);
        }
        if(direction.z != 0)
        {
            rbody.MovePosition(rbody.position + transform.forward * direction.z * speed * Time.deltaTime);
        }
        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed;
        rotationY += Input.GetAxis("Mouse Y") * rotationSpeed; 
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        bool isGrounded = Physics.CheckSphere(feet.position, 0.1f, ground);
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            audio.Play();
            rbody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
        }
        //add new statement
        if(Input.GetButtonDown("Fire1"))
        {
            audio2.Play();
            Fire();

        }
    }
    //create new function called fire()
    void Fire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 9; 
        Destroy(bullet, 2.0f);
    }
      
    
}
