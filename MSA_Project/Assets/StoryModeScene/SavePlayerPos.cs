using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPos : MonoBehaviour
{
    public GameObject player;
    public string coordX;
    public string coordY;
    public string Saved;
    public string TimeToLoad;

    private void Start() {

        if (PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1) {

            float pX = player.transform.position.x; 
            float pY = player.transform.position.y;
            pX = PlayerPrefs.GetFloat("p_X");
            pY = PlayerPrefs.GetFloat("p_Y");
            player.transform.position = new Vector2(pX, pY);
            PlayerPrefs.SetInt(TimeToLoad, 0);
            PlayerPrefs.Save();
        }
    }
    public void PlayerPosSave() {
        PlayerPrefs.SetFloat("p_X", player.transform.position.x);
        PlayerPrefs.SetFloat("p_Y", player.transform.position.y);
        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save();
    }

    public void PlayerPosLoad()
    {

        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }
    
}
