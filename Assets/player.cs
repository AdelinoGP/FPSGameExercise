using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public float thrust = 100f;
    public int maxJumps = 2;
    int jumps = 0;
    public float health = 100;
    

    Vector3 xandz = new Vector3(1, 0, 1);

    void Start()
    {
        
    }
    
    void Update()
    {
        Vector3 controlDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controlDirection = transform.TransformDirection(controlDirection);
        rb.AddForce(Vector3.Scale(xandz, controlDirection) * thrust * Time.deltaTime);



        if (Input.GetKeyDown(KeyCode.Space) && jumps < maxJumps)
        {
            jumps++;
            rb.AddForce(Vector3.up * thrust);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            ContactPoint contact = collision.contacts[0];
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5)
            {
                jumps = 0;
            }
        }
    }
}
