using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideHealthBar : MonoBehaviour
{

    Vector3 startingPlace = new Vector3(0,0,0);

    Vector3 hiddenPlace = new Vector3(-10,20,0);
    
    public FloatingHealtbarP floatingHealthBar;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    { 

        if (SceneManager.GetActiveScene().name == "Dialogue")
            {
                floatingHealthBar = GameObject.Find("PHP SLD").GetComponent<FloatingHealtbarP>();

                floatingHealthBar.gameObject.SetActive(false);
                //floatingHealthBar.transform.Translate(hiddenPlace);
                
            }

                if (SceneManager.GetActiveScene().name == "Epilogue")
                    {
                    floatingHealthBar = GameObject.Find("PHP SLD").GetComponent<FloatingHealtbarP>();

                    floatingHealthBar.gameObject.SetActive(false);
                    //floatingHealthBar.transform.Translate(hiddenPlace);
                    }

                        /*if (SceneManager.GetActiveScene().name == "Level1")
                        {
                        //floatingHealthBar.gameObject.SetActive(true);
                        //floatingHealthBar.transform.Translate(startingPlace);
                        } */

                            if(SceneManager.GetActiveScene().name == "Level1")
                            {
                                Debug.Log("Scenemanager = Level1");

                                FloatingHealtbarP[] allObjects = Resources.FindObjectsOfTypeAll<FloatingHealtbarP>();
                                foreach (FloatingHealtbarP obj in allObjects)
                                {
                                    Debug.Log("FindObjectsOfTypeAll start");

                                    if (obj.CompareTag("PHP SLD"))
                                    {
                                        Debug.Log("Tag found");
                                        Debug.Log("obj.gameObject is = " + obj.gameObject);
                                        Debug.Log("obj.gameObject is active before = " + obj.gameObject.activeSelf);
                                        obj.gameObject.SetActive(true);
                                        Debug.Log("obj.gameObject is active after = " + obj.gameObject.activeSelf);

                                        
                                        break;
                                    }
        }


    }

    // Update is called once per frame
    void Update()
    {   /*
        floatingHealthBar = GameObject.Find("PHP SLD").GetComponent<FloatingHealtbarP>();

        if (SceneManager.GetActiveScene().name == "Level1")
                        {
                        //floatingHealthBar.gameObject.SetActive(true);
                        floatingHealthBar.transform.Translate(startingPlace);
                        } 

                        if (SceneManager.GetActiveScene().name == "Dialogue")
                        {
                            //floatingHealthBar.gameObject.SetActive(false);
                            floatingHealthBar.transform.Translate(hiddenPlace);
                        }*/

                    /*
                    floatingHealthBar = GameObject.Find("PHP SLD").GetComponent<FloatingHealtbarP>();


                        if (SceneManager.GetActiveScene().name == "Dialogue")
                        {
                        float maxDistanceDelta = speed * Time.deltaTime;
                        floatingHealthBar.transform.position = Vector3.MoveTowards(transform.position, hiddenPlace, maxDistanceDelta);
                        }

                            if (SceneManager.GetActiveScene().name == "Level1")
                            {
                            float maxDistanceDelta = speed * Time.deltaTime;
                            floatingHealthBar.transform.position = Vector3.MoveTowards(transform.position, startingPlace, maxDistanceDelta);
                            } 
                            */
                
            }
    }          
}
