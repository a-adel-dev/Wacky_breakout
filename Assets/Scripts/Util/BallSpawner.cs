using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    Timer timer;

    bool retrySpawn = false;
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;
    // Start is called before the first frame update


    private void Start()
    {
        timer = GetComponent<Timer>();
        RunSpawnTimer();

        GameObject tempBall = Instantiate<GameObject>(ballPrefab);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(
            tempBall.transform.position.x - ballColliderHalfWidth,
            tempBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);
    }

    private void Update()
    {
        if (timer.Finished)
        {
            SpawnNewBall();
            RunSpawnTimer();
        }

        if (retrySpawn)
        {
            SpawnNewBall();
        }

    }
    public void SpawnNewBall()
    {
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
            retrySpawn = false;
            Instantiate(ballPrefab);
        }
        else
        {
            retrySpawn = true;
        }
    }

    void RunSpawnTimer ()
    {
        timer.Duration = Random.Range(ConfigurationUtils.minSpawnTime,
                                        ConfigurationUtils.maxSpawnTime);
        timer.Run();
    }

    
}
