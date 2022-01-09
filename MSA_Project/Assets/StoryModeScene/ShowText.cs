using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowText : MonoBehaviour
{

    public float squarePosX;
    float textX;
    float textY;
    float squareX;
    float squareY;
    private static int a = 0;
    public GameObject square;
    //public string textValue;
    public TextMeshProUGUI textElement;
 
    // Start is called before the first frame update
    void Start()
    {
        //textElement = GetComponent<TextMeshProUGUI>();
        textElement.enabled = false;
        //yield return new WaitForSeconds(5);
        //textElement.enabled = false;
        //textElement.text = textValue;
        //textElement2.text = textValue;
        //StartCoroutine(WaitBeforeShow());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(square.transform.position.x >= squarePosX && a == 0)
        {
            StartCoroutine(WaitBeforeShow());
            a = 1;
        }
        //textElement.transform.position = square.transform.position;

        textX = square.transform.position.x;
        textY = square.transform.position.y;
        textElement.transform.position = new Vector3(textX, textY + 1.8f, 1f);
        //textElement.transform.position.y = textY;
    }

    private IEnumerator WaitBeforeShow()
    {
        textElement.enabled = true;

        yield return new WaitForSeconds(5);

        textElement.enabled = false;
    }
}
