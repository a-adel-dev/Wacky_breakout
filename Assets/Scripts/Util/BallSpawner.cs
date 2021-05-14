using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    Timer timer;
    // Start is called before the first frame update


    private void Start()
    {
        timer = GetComponent<Timer>();
        RunSpawnTimer();
    }

    private void Update()
    {
        if (timer.Finished)
        {
            SpawnNewBall();
            RunSpawnTimer();
        }
    }
    public void SpawnNewBall()
    {
        Instantiate(ballPrefab, new Vector2(0f,0f), Quaternion.identity);
    }

    void RunSpawnTimer ()
    {
        timer.Duration = Random.Range(ConfigurationUtils.minSpawnTime,
                                        ConfigurationUtils.maxSpawnTime);
        timer.Run();
    }

    
}
