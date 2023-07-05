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
        floatingHealthBar = GameObject.Find("PHP SLD").GetComponent<FloatingHealtbarP>();


        if (SceneManager.GetActiveScene().name == "Dialogue")
            {
                //floatingHealthBar.gameObject.SetActive(false);
                //floatingHealthBar.transform.Translate(hiddenPlace);
                
            }

                if (SceneManager.GetActiveScene().name == "Epilogue")
                    {
                    floatingHealthBar.gameObject.SetActive(false);
                    //floatingHealthBar.transform.Translate(hiddenPlace);
                    }

                        if (SceneManager.GetActiveScene().name == "Level1")
                        {
                        //floatingHealthBar.gameObject.SetActive(true);
                        //floatingHealthBar.transform.Translate(startingPlace);
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
