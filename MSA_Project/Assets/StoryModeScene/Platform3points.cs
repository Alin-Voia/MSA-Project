using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform3points : MonoBehaviour
{
    public Transform pos1, pos2, pos3; //start and end pos of the platform
    public float speed;
    public Transform startPos;
    Vector3 nextPos;
    private float timee;
    private int a = 0;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }

        else if (transform.position == pos2.position && a == 0)
        {
            nextPos = pos3.position;
            a = 1;
        }

        else if (transform.position == pos3.position)
        {
            nextPos = pos2.position;
        }

        else if (transform.position == pos2.position && a == 1)
        {
            nextPos = pos1.position;
            a = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

    }
}
