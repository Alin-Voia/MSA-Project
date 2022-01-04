using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour
{
	private Rigidbody2D rb;
	private float moveInputHorizontal;
	public float moveSpeed = 10f;
    public float jumpForce = 9f;
    private float fallMultiplier = 2.5f;

    public LayerMask ground; //checks if its the ground layer so that the square can touch it
    public Transform groundCheck; //object to check if square is touching ground
    public float groundCheckRadius; //little area used to detect collisions
    private bool isGrounded;

    public int maxNrJumps;
    private int nrJumps;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Physics.gravity = new Vector3(0, -50, 0);
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {


    }*/


    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);

        moveInputHorizontal = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(moveInputHorizontal, rb.velocity.y);

        if (isGrounded){
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
