using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowTextBoss : MonoBehaviour
{

    public float squarePosX;
    float textX;
    float textY;
    public string txt1;
    public float nrOfSecondsBefore;
    public float nrOfSecondsAfter;

    public GameObject square;
    public GameObject hexagon;

    public TextMeshProUGUI textElement;

    // Start is called before the first frame update
    void Start()
    {

        textElement.enabled = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (square.transform.position.x >= squarePosX && PlayerPrefs.GetInt(txt1, 0) != 1)
        {
            StartCoroutine(WaitBeforeShow());
            PlayerPrefs.SetInt(txt1, 1);
        }
        textX = hexagon.transform.position.x;
        textY = hexagon.transform.position.y;
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
