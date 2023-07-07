using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLevelStart : MonoBehaviour
{
    float speed = 5f;
    Vector2 bossTextStartingPlace;
    Vector2 textHiddenPlace = new Vector2(0,-356);

    public BossLevelStart bossLevelStart;


    void Start()
    {   
        bossTextStartingPlace = transform.position; // Tekstin aloituspaikka

        if (SceneManager.GetActiveScene().name == "level1")
        {
            bossLevelStart = GameObject.Find("Level2Start!").GetComponent<BossLevelStart>();

            Debug.Log("BossStart found!");

            bossLevelStart.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        

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
        }

        

    }

    public IEnumerator BossLevelStartTextMove()
    {
        yield return new WaitForSeconds (2);

        transform.position = Vector2.MoveTowards(transform.position, textHiddenPlace, speed * Time.deltaTime);
        
        yield return null;
    }
}
