using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
	SavePlayerPos playerPosData;
	//SaveText textData;

	void Start() {
		playerPosData = FindObjectOfType<SavePlayerPos>();
		//textData = FindObjectOfType<SaveText>();
	}

	public void LoadScene (string sceneName)
	{
		playerPosData.PlayerPosSave();

		//textData.TextSave();

		SceneManager.LoadScene(sceneName);
		Screen.orientation = ScreenOrientation.Portrait;
	}

}
