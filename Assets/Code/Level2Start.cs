using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Start : MonoBehaviour
{
    float speed = 5f;
    Vector2 textStartingPlace;
    Vector2 textHiddenPlace = new Vector2(0,-356);


    void Start()
    {
        textStartingPlace = transform.position; // Tekstin aloituspaikka 
    }

   

    void Awake() 
    {
    }


    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
        StartCoroutine(Level2StartTextMove());
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
        //StartCoroutine(Level2StartTextMove());
        Debug.Log("LEVEL2 Coroutine Start!");
        }

    }

    public IEnumerator Level2StartTextMove()
{
    yield return new WaitForSeconds (2);

    transform.position = Vector3.MoveTowards(transform.position, textHiddenPlace, speed * Time.deltaTime);

    // Declare a boolean variable to check if the text has started
    bool isTextStarted = false;

    if (SceneManager.GetActiveScene().name == "Level2" || SceneManager.GetActiveScene().name == "Boss" )
    {
        // Check if the text has not started yet
        if (!isTextStarted)
        {
            // Set the transform position to textStartingPlace
            transform.position = textStartingPlace;

            // Change the variable to true
            isTextStarted = true;

            yield return new WaitForSeconds (2);

            transform.position = Vector3.MoveTowards(transform.position, textHiddenPlace, speed * Time.deltaTime);
        }

        yield return null;

        transform.position = Vector3.MoveTowards(transform.position, textHiddenPlace, speed * Time.deltaTime);

        yield return null;
    }

    yield return null;
}
}
