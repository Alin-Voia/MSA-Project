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

    SeasonChanger mySeasonChanger;

        
    AudioSource soundEffectPlayer;
    AudioSource musicPlayer;
    public AudioClip jumpSound;
    public AudioClip scoreSound;
    public AudioClip deadSound;
    public AudioClip[] backgroundMusic;
    public int currentSong;

    private float seasonDuration = 20.0f;

    // Start is called before the first frame update
    void Start()
    {

        Screen.orientation = ScreenOrientation.Landscape;


        playerBody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
        myObstacleControl = GameObject.FindObjectOfType<ObstacleControl>();
        myGameController = GameObject.FindObjectOfType<GameController>();
        mySeasonChanger = GameObject.FindObjectOfType<SeasonChanger>();

        ShuffleMusic();
        soundEffectPlayer = GameObject.FindGameObjectWithTag("SoundEffects").GetComponent<AudioSource>();
        musicPlayer = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        PlayNextTrack();
  
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded && !isGameOver) {
            playerBody.AddForce(Vector3.up * (jump * playerBody.mass * playerBody.gravityScale * 20.0f));
            soundEffectPlayer.PlayOneShot(jumpSound,1.0f);
            isGrounded = false;
            mySeasonChanger.changeSeason(1);
        }
        else if(Input.touchCount > 0 && isGrounded && !isGameOver) {
            playerBody.AddForce(Vector3.up * (jump * playerBody.mass * playerBody.gravityScale * 20.0f));
            soundEffectPlayer.PlayOneShot(jumpSound,1.0f);
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
        soundEffectPlayer.PlayOneShot(deadSound,1.0f);
        musicPlayer.Stop();
        myObstacleControl.GameOver();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Point") {
            myGameController.IncrementScore();
            soundEffectPlayer.PlayOneShot(scoreSound,1.0f);
            Destroy(other.gameObject);
        }
    }

    void PlayNextTrack()
    {
        if(!isGameOver) 
        {
           

            if(currentSong >= backgroundMusic.Length) currentSong = 0;
            musicPlayer.clip = backgroundMusic[currentSong];
            musicPlayer.Play();
            myGameController.showMusicTitle(backgroundMusic[currentSong].name);
            currentSong++;
            // if(!isGameOver) Invoke( "PlayNextTrack", backgroundMusic[currentSong].length );
            Invoke( "PlayNextTrack", seasonDuration );
        }
        else
        {
            musicPlayer.Stop();
        }
    }

    public void ShuffleMusic() {

        AudioClip aux;
        for (int i = 0; i < backgroundMusic.Length; i++) {
            int rnd = Random.Range(0, backgroundMusic.Length);
            aux = backgroundMusic[rnd];
            backgroundMusic[rnd] = backgroundMusic[i];
            backgroundMusic[i] = aux;
        }
     }

}
