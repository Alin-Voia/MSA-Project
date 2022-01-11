using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowText2 : MonoBehaviour
{

    public float squareStartPosX;
    public float squareEndPosX;
    public float squarePosY;
    float textX;
    float textY;
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
        textX = square.transform.position.x;
        textY = square.transform.position.y;
        textElement.transform.position = new Vector3(textX, textY + 1.8f, 1f);

    }

    private IEnumerator WaitBeforeShow()
    {
        yield return new WaitForSeconds(nrOfSecondsBefore);

        textElement.enabled = true;

        yield return new WaitForSeconds(nrOfSecondsAfter);

        textElement.enabled = false;
    }
}
