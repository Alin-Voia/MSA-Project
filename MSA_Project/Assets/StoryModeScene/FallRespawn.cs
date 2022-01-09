using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Vector2 checkpointPosition;


    // Start is called before the first frame update
    void Start()
    {
        checkpointPosition = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -16)
            transform.position = checkpointPosition;
    }
}
