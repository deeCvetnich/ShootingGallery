using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public member variables
    public float jumpForce;
    public float gravityMod;
    public GameObject cam;


    //private member variables
    private float horizontalInput;
    private float verticalInput;
    private float speed = 10.0f;
    private float rotSpeed = 1.0f;
    private Rigidbody playerRb;
    private bool isGrounded = true;

    bool is3rdPOV;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
        is3rdPOV = false;
    }

    // Update is called once per frame
    void Update()
    {
        //handle horizontal and vertical movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //keep player in bounds
        //if (transform.position.x > horizBound)
        //{
        //    transform.position = new Vector3(horizBound, transform.position.y, transform.position.z);
        //}
        //else if (transform.position.x < -horizBound)
        //{
        //    transform.position = new Vector3(-horizBound, transform.position.y, transform.position.z);
        //}

        //transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Rotate(new Vector3(0, 1, 0), rotSpeed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        //handle jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            is3rdPOV = !is3rdPOV;
        }

        //handle cam position
        if (is3rdPOV)
        {
            cam.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y + 2, transform.position.z - 3);
            
        }
        else
        {
            cam.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
        cam.transform.rotation = transform.rotation;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
