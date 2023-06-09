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
        /*if (!gameObject)
        {
            Instantiate(gameObject, initialPosition, Quaternion.identity);      Yritin aluksi liian monimutkaisesti. Saatan tarvita instantiatea jos saisin childit muuttamaan paikkaa.
            Debug.Log("Instantiate Initial position = " + initialPosition);
        }
        else*/
        
        Vector2 position = transform.position;

        position.x -= moveSpeed * Time.fixedDeltaTime;

        transform.position = position;

        if (position.x <-3)
        {
             transform.position = new Vector2(Random.Range(initialPosition.x - 1, initialPosition.x + 1), Random.Range(initialPosition.y - 1f, initialPosition.y + 2.5f));
        }
        }
    }
        
