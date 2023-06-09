using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackroundSpawner : MonoBehaviour
{
   
   public float moveSpeed = 5;
   Vector2 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        Debug.Log("Start Initial position = " + initialPosition);
    }



    private void FixedUpdate()
    {
        Debug.Log("Fixed update Initial position = " + initialPosition);

        /*if (!gameObject)
        {
            Instantiate(gameObject, initialPosition, Quaternion.identity);      Yritin aluksi ihann liian monimutkaisesti.
            Debug.Log("Instantiate Initial position = " + initialPosition);
        }
        else*/
        
        Vector2 position = transform.position;

        position.x -= moveSpeed * Time.fixedDeltaTime;

        transform.position = position;

        if (position.x <-3)
        {
            transform.position = initialPosition;
            Debug.Log("Destroyed Initial position = " + initialPosition);
            return;
        }
        }
    }
        
