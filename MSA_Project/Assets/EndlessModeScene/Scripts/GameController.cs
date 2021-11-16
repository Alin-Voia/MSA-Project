using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;


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
        // scoreText.gameObject.SetActive(false);

        // if (score > PlayerPrefs.GetInt("Best", 0))
        // {
        //     PlayerPrefs.SetInt("Best", score);
        //     newAlert.SetActive(true);
        // }

        // bestText.text = "Best Score : " + PlayerPrefs.GetInt("Best", 0).ToString();
        // currentText.text = "Current Score : " + score.ToString();

        // gameOverPanel.SetActive(true);
        
        gameOverPanel.SetActive(true);
    } 
}
