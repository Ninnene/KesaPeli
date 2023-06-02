using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float moveSpeed = 3;

    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        Vector2 move = Vector2.zero;

    if (moveUp)
    {
        move.y += moveAmount;
    }
    if (moveDown)
    {
        move.y -= moveAmount;
    }
    if (moveLeft)
    {
        move.x -= moveAmount;
    }
    if (moveRight)
    {
        move.x += moveAmount;
    }

    pos += move;

    transform.position = pos;



    }


}
