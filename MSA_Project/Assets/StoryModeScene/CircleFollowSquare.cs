using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFollowSquare : MonoBehaviour
{
    public float squarePosX;
    float textX;
    float textY;
    public string txt1;
    public float nrOfSecondsBefore;
    //public float nrOfSecondsAfter;
    public GameObject square;
    public GameObject circle;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        circle.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (square.transform.position.x >= squarePosX && PlayerPrefs.GetInt(txt1, 0) != 1)
        {
            StartCoroutine(WaitBeforeShow());
            PlayerPrefs.SetInt(txt1, 1);
        }
        textX = square.transform.position.x;
        textY = square.transform.position.y;
        circle.transform.position = new Vector3(textX - 0.9f, textY + 0.6f, 1f);

        Vector3 desiredPosition = square.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(circle.transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
    private IEnumerator WaitBeforeShow()
    {
        yield return new WaitForSeconds(nrOfSecondsBefore);

        circle.SetActive(true);

        //yield return new WaitForSeconds(nrOfSecondsAfter);

        //textElement.enabled = false;
    }
}
