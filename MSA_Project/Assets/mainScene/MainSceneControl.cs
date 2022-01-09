using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneControl : MonoBehaviour
{
	int sceneID;
	
	//initializes sceneID with 0
	void Start() 
	{
		Screen.orientation = ScreenOrientation.Portrait;
		sceneID = SceneManager.GetActiveScene().buildIndex;
	}
	
	//for each frame
	void Update()
	{
		//if back button is pressed,  the game exits
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
	
	//if Story Mode button is pressed, the next level is loaded
    public void LoadNextLevel() 
	{
		Screen.orientation = ScreenOrientation.Landscape;
		SceneManager.LoadScene(sceneID + 1);
	}

	public void LoadEndlessMode() 
	{
		Screen.orientation = ScreenOrientation.Landscape;
		FindObjectOfType<ProgressSceneLoader>().LoadScene("endlessMode");
	}

	public void NewGame()
    {
		PlayerPrefs.DeleteKey("p_x");
		PlayerPrefs.DeleteKey("p_y");
		PlayerPrefs.DeleteKey("TimeToLoad");
		PlayerPrefs.DeleteKey("Saved");
		PlayerPrefs.SetInt("ch1", 0);
		Screen.orientation = ScreenOrientation.Landscape;
		SceneManager.LoadScene(sceneID + 1);
	}
}
