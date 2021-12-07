using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float jump = 10.0f;
    Rigidbody2D playerBody;
    bool isGrounded = false;
    float posX = 0.0f;

    bool isGameOver = false;
    ObstacleControl myObstacleControl;

    GameController myGameController;

        
    AudioSource myAudioPlayer;

    public AudioClip jumpSound;
    public AudioClip scoreSound;
    public AudioClip deadSound;
    public AudioClip backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
        myObstacleControl = GameObject.FindObjectOfType<ObstacleControl>();
        myGameController = GameObject.FindObjectOfType<GameController>();
        myAudioPlayer = GameObject.FindObjectOfType<AudioSource>();
        myAudioPlayer.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded && !isGameOver) {
            playerBody.AddForce(Vector3.up * (jump * playerBody.mass * playerBody.gravityScale * 20.0f));
            myAudioPlayer.PlayOneShot(jumpSound);
            isGrounded = false;
        }
        if (transform.position.x < posX && !isGameOver) {
            GameOver();
        }
    }


    void OnCollisionStay2D(Collision2D other)
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

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.tag == "Death")
        {
            GameOver();
        }

    }

    void GameOver() {
        isGameOver = true;
        myAudioPlayer.PlayOneShot(deadSound);
        myAudioPlayer.Stop();
        myObstacleControl.GameOver();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Point") {
            myGameController.IncrementScore();
            myAudioPlayer.PlayOneShot(scoreSound);
            Destroy(other.gameObject);
        }
    }

}
