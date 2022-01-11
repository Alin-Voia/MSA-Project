using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject startGameFade;

    public Text scoreText;

    public Text musicTitle;

    public Text bestScore;
    public Text currentScore;

    ObstacleControl myObstacleControl;

    float obstacleSpeed;
    int score = 0;

    public static bool gameIsPaused;

    void Start()
    {
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        startGameFade.SetActive(false);
        myObstacleControl = GameObject.FindObjectOfType<ObstacleControl>();
        obstacleSpeed = myObstacleControl.scrollSpeed;
        StartGameFade();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver() {
        ShowOverPanel();
    }

    public void Restart() {
		SceneManager.LoadScene(2);
    }

    public void ExitToMainMenu() {
		SceneManager.LoadScene(0);
    }

    public void StartGameFade()
    {
        Invoke("StartGameFadeEnd",2f);
        startGameFade.SetActive(true);
        StartCoroutine(fadeInAndOut(startGameFade,false, 2f));
    }

    public void StartGameFadeEnd()
    {
        startGameFade.SetActive(false);
    }

    void ShowOverPanel() {
        scoreText.gameObject.SetActive(false);
        PlayerPrefs.SetInt("CurrentPlayerScore", score);

        if (score > PlayerPrefs.GetInt("Best", 0))
        {
            PlayerPrefs.SetInt("Best", score);
        }

        bestScore.text = "Top Score : " + PlayerPrefs.GetInt("Best", 0).ToString();
        currentScore.text = "Current Score : " + score.ToString();

        
        
        gameOverPanel.SetActive(true);
        StartCoroutine(fadeInAndOut(gameOverPanel,true, 1.2f));
        
    } 

    private void EndPanel() {
        gameOverPanel.SetActive(false);
        
    } 
    public void ClosePanel() {

        StartCoroutine(fadeInAndOut(gameOverPanel,false, 1.0f));
        Invoke("EndPanel", 1.0f);
        
    } 

    public void IncrementScore() {
        score++;
        scoreText.text = score.ToString();
    
    }

    public void showMusicTitle(string musicTitle)
    {
        this.musicTitle.text ="- " + musicTitle + " -";
        this.musicTitle.enabled = true;
        this.musicTitle.CrossFadeAlpha(0.0f, 0.0f, false);
        this.musicTitle.CrossFadeAlpha(1.0f, 1.5f, false);

        Invoke("disableMusicTitle", 3f);
    }

    private void disableMusicTitle()
    {
        this.musicTitle.CrossFadeAlpha(0.0f, 1.5f, false);
    }


    public void PauseGame()
    {
        
        gameIsPaused = !gameIsPaused;
        pausePanel.SetActive(true);

        AudioListener.pause = true;
        Time.timeScale = 0f;

    }


    public void StopPauseGame()
    {
        gameIsPaused = !gameIsPaused;
        pausePanel.SetActive(false);

        AudioListener.pause = false;
        Time.timeScale = 1;
        
        StartGameFade();
    }


    IEnumerator fadeInAndOut(GameObject objectToFade, bool fadeIn, float duration)
    {
        float counter = 0f;

        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0;
            b = 1;
        }
        else
        {
            a = 1;
            b = 0;
        }

        int mode = 0;
        Color currentColor = Color.clear;

        SpriteRenderer tempSPRenderer = objectToFade.GetComponent<SpriteRenderer>();
        Image tempImage = objectToFade.GetComponent<Image>();
        RawImage tempRawImage = objectToFade.GetComponent<RawImage>();
        MeshRenderer tempRenderer = objectToFade.GetComponent<MeshRenderer>();
        Text tempText = objectToFade.GetComponent<Text>();
        CanvasGroup tempGroup = objectToFade.GetComponent<CanvasGroup>();

        //Check if this is a Sprite
        if (tempSPRenderer != null)
        {
            currentColor = tempSPRenderer.color;
            mode = 0;
        }
        //Check if Image
        else if (tempImage != null)
        {
            currentColor = tempImage.color;
            mode = 1;
        }
        //Check if RawImage
        else if (tempRawImage != null)
        {
            currentColor = tempRawImage.color;
            mode = 2;
        }
        //Check if Text 
        else if (tempText != null)
        {
            currentColor = tempText.color;
            mode = 3;
        }

        //Check if 3D Object
        else if (tempRenderer != null)
        {
            currentColor = tempRenderer.material.color;
            mode = 4;

            //ENABLE FADE Mode on the material if not done already
            tempRenderer.material.SetFloat("_Mode", 2);
            tempRenderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            tempRenderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            tempRenderer.material.SetInt("_ZWrite", 0);
            tempRenderer.material.DisableKeyword("_ALPHATEST_ON");
            tempRenderer.material.EnableKeyword("_ALPHABLEND_ON");
            tempRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            tempRenderer.material.renderQueue = 3000;
        }
        else
        {
            yield break;
        }

        if (tempGroup != null)
        {
            mode = 5;
        }
        else
        {
            yield break;
        }

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            switch (mode)
            {
                case 0:
                    tempSPRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                    break;
                case 1:
                    tempImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                    break;
                case 2:
                    tempRawImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                    break;
                case 3:
                    tempText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                    break;
                case 4:
                    tempRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                    break;
                case 5:
                    tempGroup.alpha = alpha;
                    break;    
            }
            yield return null;
        }
    }

}
