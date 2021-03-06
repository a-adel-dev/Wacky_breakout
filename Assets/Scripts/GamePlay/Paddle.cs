using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    /// <summary>
    /// The component that controls the paddle object
    /// </summary>

    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;
    float halfWidth;
    Rigidbody2D rigidBody;
    float halfColliderHeight;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        halfWidth = (GetComponent<BoxCollider2D>().size.y )/2;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveCorrected(halfWidth);
    }

    void MoveCorrected(float possibleXPos)
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        Vector2 targetPosition = rigidBody.position +
                                new Vector2((horizontalMovement * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.fixedDeltaTime),
                                                0f);
        if (targetPosition.x - possibleXPos < ScreenUtils.ScreenLeft)
        {
            targetPosition.x = ScreenUtils.ScreenLeft + possibleXPos ;
        }

        if (targetPosition.x + possibleXPos > ScreenUtils.ScreenRight)
        {
            targetPosition.x = ScreenUtils.ScreenRight - possibleXPos;
        }

        rigidBody.MovePosition(targetPosition);
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball")
            && TopCollision(coll))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }
    /// <summary>
    /// Checks for a collision on the top of the paddle
    /// </summary>
    /// <returns><c>true</c>, if collision was on the top of the paddle, <c>false</c> otherwise.</returns>
    /// <param name="coll">collision info</param>
    bool TopCollision(Collision2D coll)
    {
        ContactPoint2D[] contacts = new ContactPoint2D[2];
        // on top collisions, both contact points are at the same y location
        coll.GetContacts(contacts);
        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < Mathf.Epsilon;
    }
}
