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
    }



    private void FixedUpdate()
    {
        if (!gameObject)
        {
            Instantiate(gameObject, initialPosition, Quaternion.identity);
        }
        else
        {

        Vector2 position = transform.position;

        position.x -= moveSpeed * Time.fixedDeltaTime;

        transform.position = position;

        if (position.x <-3)
        {
            Destroy(gameObject);
            
            return;
        }
        }
    }
        
}