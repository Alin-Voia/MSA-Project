using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowTextNarrator2 : MonoBehaviour
{

    public float squareStartPosX;
    public float squareEndPosX;
    public float squarePosY;

    public string txt1;
    public float nrOfSecondsBefore;
    public float nrOfSecondsAfter;

    public GameObject square;

    public TextMeshProUGUI textElement;

    // Start is called before the first frame update
    void Start()
    {

        textElement.enabled = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (square.transform.position.x >= squareStartPosX && square.transform.position.x <= squareEndPosX && square.transform.position.y <= squarePosY && PlayerPrefs.GetInt(txt1, 0) != 1)
        {
            StartCoroutine(WaitBeforeShow());
            PlayerPrefs.SetInt(txt1, 1);
        }
   

    }

    private IEnumerator WaitBeforeShow()
    {
        yield return new WaitForSeconds(nrOfSecondsBefore);

        textElement.enabled = true;

        yield return new WaitForSeconds(nrOfSecondsAfter);

        textElement.enabled = false;
    }
}