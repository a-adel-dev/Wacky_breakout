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
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
            ConfigurationUtils.ballImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.ballImpulseForce * Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(force);
        Debug.Log(ConfigurationUtils.ballImpulseForce.ToString());
        timer.Duration = ConfigurationUtils.ballLifeTimeInSeconds;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnNewBall(transform.position);
            Destroy(gameObject);
        }
    }

    internal void SetDirection(Vector2 direction)
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }
}
