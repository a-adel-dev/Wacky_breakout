using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Ball</c> controls the bouncy
/// ball.
/// </summary>
public class Ball : MonoBehaviour
{
    Timer timer;
    Timer spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        spawnTimer = GetComponent<Timer>();
        timer.Duration = ConfigurationUtils.ballLifeTimeInSeconds;
        timer.Run();
        spawnTimer.Duration = 1f;
        spawnTimer.Run();
        StartCoroutine(PushBall());
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnNewBall();
            Destroy(gameObject);
        }
    }
    IEnumerator PushBall()
    {
        yield return new WaitForSecondsRealtime(1);
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
            ConfigurationUtils.ballImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.ballImpulseForce * Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    internal void SetDirection(Vector2 direction)
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }

    private void OnBecameInvisible()
    {
        if (transform.position.y < ScreenUtils.ScreenBottom)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnNewBall();
            Destroy(gameObject);
        }
        
    }
}
