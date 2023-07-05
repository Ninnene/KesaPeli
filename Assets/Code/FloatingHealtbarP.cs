using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FloatingHealtbarP : MonoBehaviour
{
    // Piilotetaan hiparipalkki Dialogue- ja Epilogue sceneissä.
    Vector3 startingPlace = new Vector3(0,0,0);

    Vector3 hiddenPlace = new Vector3(-10,20,0);
    // /
    [SerializeField] private Slider slider;


    void Start()
    {   /*
         if (SceneManager.GetActiveScene().name == "Dialogue")
            {
                transform.Translate(hiddenPlace);
                Debug.Log("I am at : " + transform.position);    
            }

                if (SceneManager.GetActiveScene().name == "Epilogue")
                {
                    transform.Translate(hiddenPlace);
                    Debug.Log("I am at : " + transform.position); 
                }

                    else if (SceneManager.GetActiveScene().name == "Level1")
                    {
                        transform.Translate(startingPlace);
                        Debug.Log("I am at : " + transform.position); 
                    }   */
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
    // Update is called once per frame


    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
                        {
                            gameObject.SetActive(true);
                        } 
    }

    void Update()
    {
       if (SceneManager.GetActiveScene().name == "Dialogue")
            {
                gameObject.SetActive(false);   
            }

                if (SceneManager.GetActiveScene().name == "Epilogue")
                    {
                    gameObject.SetActive(false);
                    }


                    
    }
}


                // Vanha tapa

                /*gameObject.transform.parent.gameObject.SetActive(false);
                gameObject.SetActive(false);
                Debug.Log("Disable player healtbar.");

                    gameObject.transform.parent.gameObject.SetActive(false);
                    gameObject.SetActive(false);
                    Debug.Log("Disable player healtbar.");

                        gameObject.SetActive(true);*/

                        // /