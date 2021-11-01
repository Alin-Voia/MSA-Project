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
		SceneManager.LoadScene(sceneID + 1);
	}
}
