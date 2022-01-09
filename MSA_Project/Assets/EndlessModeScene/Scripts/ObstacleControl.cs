using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{

    public float scrollSpeed = 5.0f;

    private GameObject[] obstacles;

    public GameObject[] SmObstacles;

    public GameObject[] SpObstacles;

    public GameObject[] FObstacles;

    public GameObject[] WObstacles;
    public float frequency = 0.5f;
    float counter = 0.0f;
    public Transform obstacleSpawnLocation;
    bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        if (counter <= 0.0f)
        {
            GenerateRandomObstacle();
        }
        else {
            counter -= Time.deltaTime * frequency;
        }

        GameObject currentChild;
        for (int i = 0; i < transform.childCount; i++) {
            currentChild = transform.GetChild(i).gameObject;
            ScrollObstacle(currentChild);
            if (currentChild.transform.position.x <= -35.0f) {
                Destroy(currentChild);
            }
        }
    }

    void ScrollObstacle(GameObject currentObstacle) {
        currentObstacle.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }

    void GenerateRandomObstacle() {
        if(obstacles != null){
            GameObject newObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], obstacleSpawnLocation.position, Quaternion.identity) as GameObject;
            newObstacle.transform.parent = transform;
            counter = 1.0f;
        }
    }

    public void GameOver() {
        isGameOver = true;
        transform.GetComponent<GameController>().GameOver();
    }


    public void pauseObstacle()
    {
        obstacles = null;
    }

    public void changeObstacles(int season)
    {
        switch(season){
            case 0:
                obstacles = SmObstacles;
                break;
            case 1:
                obstacles = FObstacles;
                break;
            case 2:
                obstacles = WObstacles;
                break;
            case 3:
                obstacles = SpObstacles;
                break;
            default:
                obstacles = null;
                break;
        }

    }

}
