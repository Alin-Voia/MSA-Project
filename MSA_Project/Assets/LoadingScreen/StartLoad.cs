using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
		FindObjectOfType<ProgressSceneLoader>().LoadScene("endlessMode");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
