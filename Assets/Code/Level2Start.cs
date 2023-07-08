using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Start : MonoBehaviour
{
    float speed = 5f;
    Vector3 textStartingPlace;
    Vector3 textHiddenPlace = new Vector3(0,-356,0);
    
    private bool isCoroutineRunning = false; // Estetään useampi BossTextMove - coroutine

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

        if (SceneManager.GetActiveScene().name == "Boss" && (!isCoroutineRunning))
        {
        StartCoroutine(BossTextMove());
        isCoroutineRunning = true;
        }
    }

    public IEnumerator Level2StartTextMove()
{
    yield return new WaitForSeconds (2);

    transform.position = Vector3.MoveTowards(transform.position, textHiddenPlace, speed * Time.deltaTime);

    // Declare a boolean variable to check if the text has started
    bool isTextStarted = false;

    if (SceneManager.GetActiveScene().name == "Level2")   //  || SceneManager.GetActiveScene().name == "Boss"   Tällä saa tekstin näkymään bossissa
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


    public IEnumerator BossTextMove()
    {
        transform.position = textStartingPlace;

    yield return new WaitForSeconds (2);

    // Use a while loop to check the distance between the gameobject and the target position
    while (Vector3.Distance(transform.position, textHiddenPlace) > 0.1f)
    {
        // Move the gameobject towards the target position using MoveTowards
        transform.position = Vector3.MoveTowards(transform.position, textHiddenPlace, speed * Time.deltaTime);

        // Yield until the next frame
        yield return null;


         if(Vector3.Equals(transform.position, textHiddenPlace))
        {
            gameObject.SetActive(false);
            StopCoroutine(BossTextMove());
            isCoroutineRunning = false;
        }

    }
    }

}
