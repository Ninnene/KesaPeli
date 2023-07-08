using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLevelText : MonoBehaviour
{
    float speed = 5f;
    Vector3 bossTextStartingPlace;
    Vector3 bossSecondTextStartingPlace = new Vector2(8.90f, 5.00f);
    Vector3 textHiddenPlace = new Vector2(0,-356);

    GameObject getCoordinates;

    Vector3 secondCoordinates;

    bool placeIsSet = false;

    public BossLevelStart bossLevelStart;



    private void Start() 
    {
    if (SceneManager.GetActiveScene().name == "Level1")
    {
    bossTextStartingPlace = transform.position; 
    }
    }

    void Awake()
    {   
        bossSecondTextStartingPlace = transform.position;
        bossTextStartingPlace = transform.position; // Tekstin aloituspaikka



        if (SceneManager.GetActiveScene().name == "Level1")
        {
            transform.position = textHiddenPlace;

                if (SceneManager.GetActiveScene().name == "Boss")
                {
                    textHiddenPlace = secondCoordinates;
                }
        }

        if (SceneManager.GetActiveScene().name == "Boss")
        {
            getCoordinates = GameObject.Find("GetTheCoordinates");

            secondCoordinates = getCoordinates.transform.position;
            transform.position = getCoordinates.transform.position;
            placeIsSet = true;

            Debug.Log("Level2 text starting position is = " + transform.position);

            if(placeIsSet == true)
            {
            StartCoroutine(BossLevelStartTextMove());
            }
        }

    }

    // Update is called once per frame
    void Update()
    {   
        //StartCoroutine(BossLevelStartTextMove());
/*
        if (SceneManager.GetActiveScene().name == "Boss" && !bossLevelStart)
        {
                    {
                        Debug.Log("Scenemanager = Boss");

                        BossLevelStart[] allObjects = Resources.FindObjectsOfTypeAll<BossLevelStart>();
                        foreach (BossLevelStart obj in allObjects)
                            {
                                Debug.Log("FindObjectsOfTypeAll start");

                                    if (obj.CompareTag("Boss"))
                                        {
                                            Debug.Log("Tag found");
                                            Debug.Log("obj.gameObject is = " + obj.gameObject);
                                            Debug.Log("obj.gameObject is active before = " + obj.gameObject.activeSelf);
                                            obj.gameObject.SetActive(true);
                                            Debug.Log("obj.gameObject is active after = " + obj.gameObject.activeSelf);

                                                
                                            break;
                                        }
                                }

                    StartCoroutine(BossLevelStartTextMove());

                    }
        }*/

        

    }

    public IEnumerator BossLevelStartTextMove()
    {
        yield return new WaitForSeconds (2);

        transform.position = Vector2.MoveTowards(transform.position, textHiddenPlace, speed * Time.deltaTime);
        
        yield return null;
        
    }
}
