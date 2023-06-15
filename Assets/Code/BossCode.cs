using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCode : MonoBehaviour
{

    Vector3 spawnPosition;
    Vector3 attackPositionStart;

    Vector3 moveTillUp;

    Vector3 moveTillDown;

    float iPKSpeed = 5;

    bool spawnIPK = true;




    bool attackMiddle = false;
    float repeatMiddleAttack = 0;



    bool attackUp = false;
    bool attackDown = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnIPK == true)
        {
        attackPositionStart = new Vector3(24.3f,5.07f,-5.236f);

        transform.position = Vector3.MoveTowards(transform.position, attackPositionStart, iPKSpeed * Time.deltaTime);
        }


    if (transform.position == attackPositionStart && !attackMiddle)
    {
    
    
    spawnIPK = false;

    Debug.Log("spawnIPK = " + spawnIPK);

    attackMiddle = true;

    

    StartCoroutine(AttackMiddle()); // start the coroutine
    }
        
    }

    IEnumerator AttackMiddle()
    {    
        while (repeatMiddleAttack <10)
        {

        repeatMiddleAttack++;

        moveTillUp = new Vector3(24.2999992f,10.1800003f,-5.23600006f);

        Debug.Log("moveTillUp = " + moveTillUp);

        while (transform.position != moveTillUp)
        {
        transform.position = Vector3.MoveTowards(transform.position, moveTillUp, iPKSpeed * Time.deltaTime);
        yield return null;
        }
            
            
            
        if(transform.position == moveTillUp)
        
        moveTillDown = new Vector3(24.2999992f,1.71000004f,-5.23600006f);

        Debug.Log("moveTillDown = " + moveTillDown);

        while (transform.position != moveTillDown)
        {
        transform.position = Vector3.MoveTowards(transform.position, moveTillDown, iPKSpeed * Time.deltaTime);
        yield return null;
        }
            if(transform.position == moveTillDown)
        {
        repeatMiddleAttack++;

        Debug.Log("Repeat is : " + repeatMiddleAttack);


        if (repeatMiddleAttack >=10)
        {
        
        Debug.Log("Return to spawnposition");

        while (transform.position != spawnPosition)
        {
        transform.position = Vector3.MoveTowards(transform.position, spawnPosition, iPKSpeed * Time.deltaTime);
        yield return null;
        }
            if(transform.position == spawnPosition && repeatMiddleAttack >= 10)
            {
            Debug.Log("Yield break!");
            yield break;
            }
        }
        }
        }

        /*Debug.Log("Start : moveTillUp = " + moveTillUp);

            if(transform.position == moveTillUp) 
            {
                attackMiddle = false;
                 yield break;
            }*/
    }



    /*IEnumerator AttackMiddle()
        {
        Debug.Log("Middle attack start!");

        while (attackMiddle) // loop until attackMiddle is false
        {
            Vector3 position = transform.position;

            position.y -= iPKSpeed * Time.fixedDeltaTime;

            transform.position = position;

            // Check if position.y is too low
            if(position.y < 1.38)
            {
                Debug.Log("Position Y is " + position.y);

                // Move up
                position.y += iPKSpeed * Time.fixedDeltaTime;

                transform.position = position;

                // Check if position.y is too high
                if(position.y > 10.75)
                {
                    // Increment repeat counter
                    ++repeatMiddleAttack;

                    // Check if repeat limit is reached
                    if(repeatMiddleAttack >= 5)
                    {
                        // Stop the attack
                        attackMiddle = false;
                        yield break; // end the coroutine
                    }

                    // Move down
                    position.y -= iPKSpeed * Time.fixedDeltaTime;
                    
                    transform.position = position;
                }
            }
            else
            {
                // Break the loop if position.y is out of range
                break;
            }

            yield return null; // wait for the next frame
        } 
    }*/
    
    /*void AttackMiddle()
        {
            Debug.Log("Middle attack start!");

        while (attackMiddle == true)
            {
                Vector3 position = transform.position;

                position.y -= iPKSpeed * Time.fixedDeltaTime;

                transform.position = position;

                if(position.y <1.38)
                {
                    position.y += iPKSpeed * Time.fixedDeltaTime;

                        transform.position = position;
                        attackMiddle = false;
                        break;
                }
        }
     }*/

    
}