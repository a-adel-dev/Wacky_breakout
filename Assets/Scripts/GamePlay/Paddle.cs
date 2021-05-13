using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    /// <summary>
    /// The component that controls the paddle object
    /// </summary>


    float halfWidth;
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        halfWidth = (GetComponent<BoxCollider2D>().size.y )/2;
        Debug.Log($"{ScreenUtils.ScreenLeft}, halfWIDTH IS {halfWidth}");
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
}
