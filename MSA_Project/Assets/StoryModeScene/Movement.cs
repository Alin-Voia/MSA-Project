using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour
{
	public Rigidbody2D rb;
	private float moveInputHorizontal;
	public float moveSpeed = 10f;
    public float jumpForce = 9f;
    //private float fallMultiplier = 2.5f;

    public LayerMask ground;
    //public LayerMask platform;//checks if its the ground layer so that the square can touch it
    public Transform groundCheck1;//object to check if square is touching ground
    public Transform groundCheck2;
    public Transform groundCheck3;
    public Transform groundCheck4;
    public Transform groundCheck5;//object to check if square is touching ground
    public Transform groundCheck6;
    public Transform groundCheck7;
    public Transform groundCheck8;
    /*public Transform platformCheck1;
    public Transform platformCheck2;
    public Transform platformCheck3;
    public Transform platformCheck4;*/
    public float groundCheckRadius; //little area used to detect collisions
    private bool isGrounded1;
    private bool isGrounded2;
    private bool isGrounded3;
    private bool isGrounded4;
    private bool isGrounded5;
    private bool isGrounded6;
    private bool isGrounded7;
    private bool isGrounded8;
    /*private bool isPlatform1;
    private bool isPlatform2;
    private bool isPlatform3;
    private bool isPlatform4;*/

    public int maxNrJumps;
    //private int nrJumpsGround;
    //private int nrJumpsPlatform;
    private int nrJumps;
    bool isGrounded;
    float mx;
    float jumpCooldown;
    int jumpCount;
    private float fallMultiplier = 2.5f;

    SavePlayerPos playerPosData;


    
    //private float chY = 0;
    //Vector2 checkp;
    Vector2 checkpoint0;
    Vector2 checkpoint1;
    Vector2 checkpoint2;
    Vector2 checkpoint3;
    Vector2 checkpoint4;
    Vector2 checkpoint5;
    Vector2 checkpoint6;
    Vector2 checkpoint7;
    Vector2 checkpoint8;
    private int checkpointCheck = 0;

    private void Awake() {

        playerPosData = FindObjectOfType<SavePlayerPos>();
        playerPosData.PlayerPosLoad();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkpoint0 = new Vector2(0, -1.3f);
        checkpoint1 = new Vector2(16, -1.3f);
        checkpoint2 = new Vector2(58, -1.3f);
        checkpoint3 = new Vector2(114, -1.3f);
        checkpoint4 = new Vector2(146, -1.3f);
        checkpoint5 = new Vector2(177, -0.8f);
        checkpoint6 = new Vector2(212, -2.8f);
        checkpoint7 = new Vector2(244, 52.5f);

    }



    void Update()
    {
        if (transform.position.x >= 271)
        {
            checkpointCheck = 7;

            if (transform.position.y < -16 && checkpointCheck == 7)
            {

                transform.position = checkpoint7;
            }

        }

        else if (transform.position.x >= 204)
        {
            checkpointCheck = 6;

            if (transform.position.y < -16 && checkpointCheck == 6)
            {

                transform.position = checkpoint6;
            }

        }
        else if (transform.position.x >= 172)
        {
            checkpointCheck = 5;

            if (transform.position.y < -16 && checkpointCheck == 5)
            {

                transform.position = checkpoint5;
            }

        }
        else if (transform.position.x >= 143)
        {
            checkpointCheck = 4;

            if (transform.position.y < -16 && checkpointCheck == 4)
            {

                transform.position = checkpoint4;
            }

        }
        else if (transform.position.x >= 103)
        {
            checkpointCheck = 3;
 
            if (transform.position.y < -16 && checkpointCheck == 3)
            {
                transform.position = checkpoint3;
            }

        }
        else if (transform.position.x >= 53.5)
        {
            checkpointCheck = 2;
            if (transform.position.y < -16 && checkpointCheck == 2)
            {
                transform.position = checkpoint2;
            }
                
        }
        else if (transform.position.x >= 16)
        {
            checkpointCheck = 1;
            if (transform.position.y < -16 && checkpointCheck == 1)
            {
                transform.position = checkpoint1;
            }
                
        }else if (transform.position.y < -16 && transform.position.x < 0)
            transform.position = checkpoint0;



        mx = CrossPlatformInputManager.GetAxis("Horizontal");
        if(CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        CheckGrounded();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx * moveSpeed, rb.velocity.y);
        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

    }

    void Jump()
    {
        if(isGrounded || jumpCount < maxNrJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
    }

    void CheckGrounded()
    {
        if(Physics2D.OverlapCircle(groundCheck1.position, groundCheckRadius, ground) || Physics2D.OverlapCircle(groundCheck2.position, groundCheckRadius, ground) 
            || Physics2D.OverlapCircle(groundCheck3.position, groundCheckRadius, ground) || Physics2D.OverlapCircle(groundCheck4.position, groundCheckRadius, ground)
            || Physics2D.OverlapCircle(groundCheck5.position, groundCheckRadius, ground) || Physics2D.OverlapCircle(groundCheck6.position, groundCheckRadius, ground)
            || Physics2D.OverlapCircle(groundCheck7.position, groundCheckRadius, ground) || Physics2D.OverlapCircle(groundCheck8.position, groundCheckRadius, ground))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCooldown = Time.time + 0.2f;
        }
        else if(Time.time < jumpCooldown)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}







/*using UnityEngine;
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

    public LayerMask ground;
    //public LayerMask platform;//checks if its the ground layer so that the square can touch it
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


    SavePlayerPos playerPosData;


    
    //private float chY = 0;
    //Vector2 checkp;
    Vector2 checkpoint0;
    Vector2 checkpoint1;
    Vector2 checkpoint2;
    Vector2 checkpoint3;
    Vector2 checkpoint4;
    private int checkpointCheck = 0;

    private void Awake() {

        playerPosData = FindObjectOfType<SavePlayerPos>();
        playerPosData.PlayerPosLoad();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkpoint0 = new Vector2(0, -1.3f);
        checkpoint1 = new Vector2(16, -1.3f);
        checkpoint2 = new Vector2(58, -1.3f);
        checkpoint3 = new Vector2(114, -1.3f);
        checkpoint4 = new Vector2(143, -1.3f);

    }





    void Update()
    {

        if (transform.position.x >= 143)
        {
            checkpointCheck = 4;
            //chY = transform.position.y;
            if (transform.position.y < -16 && checkpointCheck == 4)
            {
                //checkp = new Vector2(chX, chY);
                transform.position = checkpoint4;
            }

        }
        else if (transform.position.x >= 103)
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
                
        }else if (transform.position.y < -16 && transform.position.x < 0)
            transform.position = checkpoint0;








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

        }
        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;


    }
}*/