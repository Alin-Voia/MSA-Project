using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform pos1, pos2; //start and end pos of the platform
    public float speed;
    public Transform startPos;
    Vector3 nextPos;
    private float timee;

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

        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }
            
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        
    }
}
