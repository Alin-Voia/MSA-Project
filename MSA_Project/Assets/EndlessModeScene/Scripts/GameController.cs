using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text scoreText;

    public Text musicTitle;

    public Text bestScore;
    public Text currentScore;

    int score = 0;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver() {
        Invoke("ShowOverPanel", 1.0f);
    }

    public void Restart() {
        //Initiate.Fade(Application.loadedLevelName,Color.white,2.0f);
        Application.LoadLevel(Application.loadedLevelName);
    }

    
    void ShowOverPanel() {
        scoreText.gameObject.SetActive(false);
        

        if (score > PlayerPrefs.GetInt("Best", 0))
        {
            PlayerPrefs.SetInt("Best", score);
        }

        bestScore.text = "Top Score : " + PlayerPrefs.GetInt("Best", 0).ToString();
        currentScore.text = "Current Score : " + score.ToString();

        
        
        gameOverPanel.SetActive(true);
        
    } 

    public void IncrementScore() {
        score++;
        scoreText.text = score.ToString();
    
    }

    public void showMusicTitle(string musicTitle)
    {
        this.musicTitle.text = musicTitle;
        this.musicTitle.enabled = true;
        this.musicTitle.CrossFadeAlpha(0.0f, 0.0f, false);
        this.musicTitle.CrossFadeAlpha(1.0f, 1.5f, false);

        Invoke("disableMusicTitle", 3f);
    }

    private void disableMusicTitle()
    {
        this.musicTitle.CrossFadeAlpha(0.0f, 1.5f, false);
    }
}
