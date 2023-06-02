using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Gun[] guns;

    public float moveSpeed = 3;

    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    bool speedUp;

    bool shoot;




    void Start()
    {   
        // Kun Player luodaan sceneen etsitään kaikki aseet jotka ovat siinä kiinni (in children)
        guns = transform.GetComponentsInChildren<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        speedUp = Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift);


        //Space ampuu kerran & LCTRL ampuu sarjaa
        shoot = Input.GetKeyDown(KeyCode.Space)||Input.GetKey(KeyCode.LeftControl);
        if (shoot)
        {
            shoot = false;
            foreach(Gun gun in guns)
            {
                gun.Shoot();
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        if (speedUp)
    {
        moveAmount *= 3;
    }
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


// Alla olevalla koodilla estetään liikkumisnopeuden kasvaminen jos liikutaan kahteen suuntaan yhtä aikaa:
    float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
    if (moveMagnitude > moveAmount)
    {
        float ratio = moveAmount / moveMagnitude;
        move *= ratio;
    }
    moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);

    pos += move;








//Rajoitetaan liikkuminen kameran alueelle:
    if (pos.x <= 1.685599f )
    {
        pos.x = 1.685599f;
    }
    if (pos.x >= 15.6856f )
    {
        pos.x = 15.6856f;
    }

if (pos.y <= 1.159951f )
    {
        pos.y = 1.159951f;
    }
    if (pos.y >= 9.15995f )
    {
        pos.y = 9.15995f;
    }
    transform.position = pos;



    }


}
