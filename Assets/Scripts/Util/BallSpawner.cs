using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    // Start is called before the first frame update

    public void SpawnNewBall(Vector2 position)
    {
        Instantiate(ballPrefab, position, Quaternion.identity);
    }
}
