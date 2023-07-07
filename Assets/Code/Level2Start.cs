using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Start : MonoBehaviour
{
    float speed = 5f;
    Vector2 textStartingPlace;
    Vector2 textHiddenPlace = new Vector2(0,-356);


    void Start()
    {
        textStartingPlace = transform.position; // Tekstin aloituspaikka
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Level2StartTextMove());
    }

    public IEnumerator Level2StartTextMove()
    {
        yield return new WaitForSeconds (2);

        transform.position = Vector3.MoveTowards(transform.position, textHiddenPlace, speed * Time.deltaTime);
        
        yield return null;
    }
}
