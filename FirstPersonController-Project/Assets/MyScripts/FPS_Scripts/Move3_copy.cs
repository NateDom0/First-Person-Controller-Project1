using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3_copy : MonoBehaviour
{
    //copy of move3
    //this is the original script when creating first person movement
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

    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f; //original constant is 3.0f
        rotationSpeed = 2f;
        rotationX = 0;
        rotationY = 10f;
        jumpHeight = 5.0f;
        rbody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();

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
    }
}
