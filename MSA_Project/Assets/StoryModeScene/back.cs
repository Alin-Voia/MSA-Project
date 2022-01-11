using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
	SavePlayerPos playerPosData;


	void Start() {
		playerPosData = FindObjectOfType<SavePlayerPos>();

	}


		public void LoadScene(string sceneName)
		{
			playerPosData.PlayerPosSave();


			SceneManager.LoadScene(sceneName);
			Screen.orientation = ScreenOrientation.Portrait;
		}

	
}
