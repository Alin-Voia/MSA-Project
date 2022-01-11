using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossControl : MonoBehaviour
{
    public GameObject hexagon;
    public GameObject square;
    public float squarePosX;
    //public string txt1;
    public string txt2;
    public float nrOfSecondsBefore;
    public float nrOfSecondsAfter;
    float textX;
    float textY;
    //public TextMeshProUGUI textElement;
    //int a = 0;
    //bool bossEnabler;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt(txt2, 1) != 0)
            hexagon.SetActive(true);
        /*if (a == 0)
            bossEnabler = true;
        else if (a == 1)
            bossEnabler = false;
        hexagon.SetActive(bossEnabler);*/
    }

    void FixedUpdate()
    {


        if (square.transform.position.x >= squarePosX && PlayerPrefs.GetInt(txt2, 0) != 1)
        {
            //bossEnabler = false;
            StartCoroutine(WaitBeforeShow());
            //PlayerPrefs.GetInt(txt1, 1);
            PlayerPrefs.GetInt(txt2, 1);
        }
        //textX = hexagon.transform.position.x;
        //textY = hexagon.transform.position.y;
        //textElement.transform.position = new Vector3(textX, textY + 1.8f, 1f);

    }

    private IEnumerator WaitBeforeShow()
    {
        yield return new WaitForSeconds(nrOfSecondsBefore);

        //textElement.enabled = true;

        yield return new WaitForSeconds(nrOfSecondsAfter);
       
        //textElement.enabled = false;

        hexagon.SetActive(false);
    }
}
