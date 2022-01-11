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
		PlayerPrefs.SetInt("circle", 0);
		PlayerPrefs.SetInt("hexaDisappear", 0);
		PlayerPrefs.SetInt("txt1", 0);
		PlayerPrefs.SetInt("txt2", 0);
		PlayerPrefs.SetInt("txt3", 0);
		PlayerPrefs.SetInt("txt4", 0);
		PlayerPrefs.SetInt("txt5", 0);
		PlayerPrefs.SetInt("txt6", 0);
		PlayerPrefs.SetInt("txt7", 0);
		PlayerPrefs.SetInt("txt8", 0);
		PlayerPrefs.SetInt("txt9", 0);
		PlayerPrefs.SetInt("txt10", 0);
		PlayerPrefs.SetInt("txt11", 0);
		PlayerPrefs.SetInt("txt12", 0);
		PlayerPrefs.SetInt("txt13", 0);
		PlayerPrefs.SetInt("txt14", 0);
		PlayerPrefs.SetInt("txt15", 0);
		PlayerPrefs.SetInt("txt16", 0);
		PlayerPrefs.SetInt("txt17", 0);
		PlayerPrefs.SetInt("txt18", 0);
		PlayerPrefs.SetInt("txt19", 0);
		PlayerPrefs.SetInt("txt20", 0);
		PlayerPrefs.SetInt("txt21", 0);
		PlayerPrefs.SetInt("txt22", 0);
		PlayerPrefs.SetInt("txt23", 0);
		PlayerPrefs.SetInt("txt24", 0);
		PlayerPrefs.SetInt("txt25", 0);
		PlayerPrefs.SetInt("txt26", 0);
		PlayerPrefs.SetInt("txt27", 0);
		PlayerPrefs.SetInt("txt28", 0);
		PlayerPrefs.SetInt("txt29", 0);
		PlayerPrefs.SetInt("txt30", 0);
		PlayerPrefs.SetInt("txt31", 0);
		PlayerPrefs.SetInt("txt32", 0);
		PlayerPrefs.SetInt("txt33", 0);
		PlayerPrefs.SetInt("txt34", 0);
		PlayerPrefs.SetInt("txt35", 0);
		PlayerPrefs.SetInt("txt36", 0);
		PlayerPrefs.SetInt("txt37", 0);
		PlayerPrefs.SetInt("txt38", 0);
		PlayerPrefs.SetInt("txt39", 0);
		PlayerPrefs.SetInt("txt40", 0);
		PlayerPrefs.SetInt("txt41", 0);
		PlayerPrefs.SetInt("txt42", 0);
		PlayerPrefs.SetInt("txt43", 0);
		PlayerPrefs.SetInt("txt44", 0);
		PlayerPrefs.SetInt("txt45", 0);
		PlayerPrefs.SetInt("txt46", 0);
		PlayerPrefs.SetInt("txt47", 0);
		PlayerPrefs.SetInt("txt49", 0);
		PlayerPrefs.SetInt("txt50", 0);
		PlayerPrefs.SetInt("txt51", 0);
		PlayerPrefs.SetInt("txt52", 0);
		PlayerPrefs.SetInt("txt53", 0);
		PlayerPrefs.SetInt("txt54", 0);
		PlayerPrefs.SetInt("txt55", 0);
		PlayerPrefs.SetInt("txt56", 0);
		Screen.orientation = ScreenOrientation.Landscape;
		SceneManager.LoadScene(sceneID + 1);
	}
}
