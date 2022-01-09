using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour
{
	private Rigidbody2D rb;
	private float moveInputHorizontal;
	public float moveSpeed = 10f;
    public float jumpForce = 9f;
    private float fallMultiplier = 2.5f;

    public LayerMask ground; //checks if its the ground layer so that the square can touch it
    public Transform groundCheck1;//object to check if square is touching ground
    public Transform groundCheck2;
    public Transform groundCheck3;
    public Transform groundCheck4;
    public float groundCheckRadius; //little area used to detect collisions
    private bool isGrounded1;
    private bool isGrounded2;
    private bool isGrounded3;
    private bool isGrounded4;

    public int maxNrJumps;
    private int nrJumps;

    SavePlayerPos playerPosData;


    
    //private float chY = 0;
    //Vector2 checkp;
    Vector2 checkpoint0;
    Vector2 checkpoint1;
    Vector2 checkpoint2;
    Vector2 checkpoint3;
    private int checkpointCheck = 0;

    private void Awake() {

        playerPosData = FindObjectOfType<SavePlayerPos>();
        playerPosData.PlayerPosLoad();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkpoint0 = new Vector2(0, 0);
        checkpoint1 = new Vector2(16, -1.3f);
        checkpoint2 = new Vector2(58, -1.3f);
        checkpoint3 = new Vector2(114, -1.3f);
        //checkp = new Vector2(0, 0)

        //Physics.gravity = new Vector3(0, -50, 0);
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {


    }*/



    void Update()
    {

        if (transform.position.x >= 103)
        {
            checkpointCheck = 3;
            //chY = transform.position.y;
            if (transform.position.y < -16 && checkpointCheck == 3)
            {
                //checkp = new Vector2(chX, chY);
                transform.position = checkpoint3;
            }

        }
        else if (transform.position.x >= 53.5)
        {
            checkpointCheck = 2;
            //chY = transform.position.y;
            if (transform.position.y < -16 && checkpointCheck == 2)
            {
                //checkp = new Vector2(chX, chY);
                transform.position = checkpoint2;
            }
                
        }
        else if (transform.position.x >= 16)
        {
            checkpointCheck = 1;
            //chY = transform.position.y;
            if (transform.position.y < -16 && checkpointCheck == 1)
            {
                //checkp = new Vector2(chX, chY);
                transform.position = checkpoint1;
            }
                
        }else if (transform.position.y < -16 && checkpointCheck == 0)
            transform.position = checkpoint0;



        /*if (transform.position.x >= -20 && transform.position.x < 80)
        {
            checkpointCheck = 2;
        }

        else if (transform.position.x >= -20 && transform.position.x < 53.5)
        {
            checkpointCheck = 1;
        }



        if (transform.position.y < -16 && checkpointCheck == 0)
            transform.position = checkpoint0;
        else if (transform.position.y < -16 && checkpointCheck == 1)
            transform.position = checkpoint1;
        else if (transform.position.y < -16 && checkpointCheck == 2)
            transform.position = checkpoint2;*/






        isGrounded1 = Physics2D.OverlapCircle(groundCheck1.position, groundCheckRadius, ground);
        isGrounded2 = Physics2D.OverlapCircle(groundCheck2.position, groundCheckRadius, ground);
        isGrounded3 = Physics2D.OverlapCircle(groundCheck3.position, groundCheckRadius, ground);
        isGrounded4 = Physics2D.OverlapCircle(groundCheck4.position, groundCheckRadius, ground);

        moveInputHorizontal = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(moveInputHorizontal, rb.velocity.y);

        if (isGrounded1 || isGrounded2 || isGrounded3 || isGrounded4)
        {
            nrJumps = maxNrJumps;
            
        }

        //if (CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0)
        if (CrossPlatformInputManager.GetButtonDown("Jump") && nrJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            nrJumps--;
            
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            //rb.AddForce(Vector2.up * jumpForce);

        }
        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;


    }
}
