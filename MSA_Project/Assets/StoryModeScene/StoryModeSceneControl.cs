using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryModeSceneControl : MonoBehaviour
{
	int sceneID;
	
    //initializes sceneID with 0
    void Start()
    {
    	sceneID = SceneManager.GetActiveScene().buildIndex;    
    }

    //each frame
    void Update()
    {
		//if back button is pressed, the previous scene will be loaded
        if(Input.GetKeyDown(KeyCode.Escape))
			SceneManager.LoadScene(sceneID - 1);
    }
}
