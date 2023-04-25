using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlProjectile : MonoBehaviour
{
    private float xBound = 50.0f;
    private float yBound = -5.0f;
    private float zBound = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //destroy if out of bounds
        if(transform.position.y < yBound)
        {
            Destroy(gameObject);
        }
        if(transform.position.x > xBound || transform.position.x < -xBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z > zBound || transform.position.z < -zBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "killable")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
