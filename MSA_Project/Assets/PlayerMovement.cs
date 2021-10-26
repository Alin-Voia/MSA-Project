using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class PlayerMovement : MonoBehaviour
{
    
     float speed = 50.0f;
     float jump = 40.0f;
     bool isGrounded;

    Rigidbody2D Player;


    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        Screen.orientation = ScreenOrientation.LandscapeLeft;


        Debug.Log("Hello: " + gameObject.name);
    }

    // Update is called once per frame
     void Update() {
        var moveHorizontal = new Vector3(Input.GetAxis("Horizontal"), 0);
        transform.position += moveHorizontal * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            if(isGrounded == true){
               Player.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            }
        }
     }


    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "Ground" || collider.gameObject.name == "SolidSquare")
        {
            isGrounded = true;
        }
    }
    
    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.name == "Ground" || collider.gameObject.name == "SolidSquare")
        {
            isGrounded = false;
        }
    }


}