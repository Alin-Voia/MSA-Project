using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryModeSceneControl : MonoBehaviour
{
	int sceneID;
	
	private PlayerAnimation playerAnim;
	private Rigidbody2D myBody;
	
	private float speed = 2f;
	private float jumpForce = 5f;
	
	private bool moveLeft;
	private bool dontMove;
	private bool canJump;
	
    //initializes sceneID with 0
    void Start()
    {
		playerAnim = GetComponent<PlayerAnimation>();
		myBody = GetComponent<Rigidbody2D>();
	
    	sceneID = SceneManager.GetActiveScene().buildIndex;    
    }

    //each frame
    void Update()
    {
		//if back button is pressed, the previous scene will be loaded
        if(Input.GetKeyDown(KeyCode.Escape))
			SceneManager.LoadScene(sceneID - 1);
			
		HandleMoving();
    }
	
	void HandleMoving() 
	{
		if (dontMove) 
		{
			StopMoving();
		} else {
			if (moveLeft) 
			{
				MoveLeft();
			} 
		else if (!moveLeft) 
		{
			MoveRight();
		}
	} // handle moving

	void AllowMovement(bool movement) 
	{
		dontMove = false;
		moveLeft = movement;
	}

	void DontAllowMovement() 
	{
		dontMove = true;
	}


	void Jump() 
	{
		if(canJump)
			myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
	}

// PREVIOUS FUNCTIONS

	void MoveLeft() 
	{
		myBody.velocity = new Vector2(-speed, myBody.velocity.y);
		playerAnim.ZombieWalk(true, true);
	}

	void MoveRight() 
	{
		myBody.velocity = new Vector2(speed, myBody.velocity.y);
		playerAnim.ZombieWalk(true, false);
	}


	void StopMoving() 
	{
		playerAnim. ZombieStop();
		myBody.velocity = new Vector2(0f,myBody.velocity.y);
	}

	void DetectInput() 
	{
		float x = Input.GetAxisRaw("Horizontal");

		if(x > 0)
			MoveRight();
		else if (x < 0)
			MoveLeft();
		else
			StopMoving();
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		if(collision.gameObject.tag == "Ground") 
			canJump = true;
	}


	void OnCollisionExit2D(Collision2D collision) 
	{
		if (collision.gameObject.tag == "Ground") 
			canJump = false;
	}
}
}