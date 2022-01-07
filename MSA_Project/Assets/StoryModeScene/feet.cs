using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feet : MonoBehaviour
{
    public GameObject player;
    Movement playerCtrl;


    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GetComponentInParent<Movement>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //if (isGrounded1 || isGrounded2 || isGrounded3 || isGrounded4)
        if (other.gameObject.CompareTag("Ground") && playerCtrl.isJumping)
        {
            //nrJumps = maxNrJumps;
            playerCtrl.isJumping = false;
            //player.transform.parent = other.gameObject.transform;

        }
        if (other.gameObject.CompareTag("Platform") && playerCtrl.isJumping)
        {
            //nrJumps = maxNrJumps;
            playerCtrl.isJumping = false;
            player.transform.parent = other.gameObject.transform;

        }
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        //if (isGrounded1 || isGrounded2 || isGrounded3 || isGrounded4)
        if (other.gameObject.CompareTag("Platform"))
        {
            //nrJumps = maxNrJumps;
            player.transform.parent = null;

        }
    }
}
