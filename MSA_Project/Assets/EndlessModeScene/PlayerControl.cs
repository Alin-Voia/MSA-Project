using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float jump = 10.0f;
    Rigidbody2D playerBody;
    bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        playerBody = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            playerBody.AddForce(Vector3.up * (jump * playerBody.mass * playerBody.gravityScale * 20.0f));
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {

        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
        }

    }
}
