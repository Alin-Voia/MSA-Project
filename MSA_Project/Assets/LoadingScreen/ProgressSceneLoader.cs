using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressSceneLoader : MonoBehaviour
{
	[SerializeField]
	private Text progressText;
	[SerializeField]
	private Slider slider;

	private AsyncOperation operation;
	private Canvas canvas;

	private void Awake()
	{
		canvas = GetComponentInChildren<Canvas>(true);
		DontDestroyOnLoad(gameObject);
	}

	public void LoadScene(string sceneName)
	{
		UpdateProgressUI(0);
		canvas.gameObject.SetActive(true);
		
		StartCoroutine(BeginLoad(sceneName));
	}

	private IEnumerator BeginLoad(string sceneName)
	{

		yield return new WaitForSeconds(1);

		operation = SceneManager.LoadSceneAsync(sceneName);

		while (!operation.isDone)
		{
			UpdateProgressUI(operation.progress);
			yield return null;
		}

		UpdateProgressUI(operation.progress);
		operation = null;
		canvas.gameObject.SetActive(false);
	}

	private void UpdateProgressUI(float progress)
	{
		slider.value = progress;
		progressText.text = (int)(progress * 100f) + "%";
	}
}