using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideHealthBar : MonoBehaviour
{

    Vector3 startingPlace = new Vector3(0,0,0);

    Vector3 hiddenPlace = new Vector3(-10,20,0);
    
    public FloatingHealtbarP floatingHealthBar;

    // Start is called before the first frame update
    void Start()
    { 
        floatingHealthBar = GameObject.Find("PHP SLD").GetComponent<FloatingHealtbarP>();


        if (SceneManager.GetActiveScene().name == "Dialogue")
            {
                floatingHealthBar.gameObject.SetActive(false);   
            }

                if (SceneManager.GetActiveScene().name == "Epilogue")
                    {
                    floatingHealthBar.gameObject.SetActive(false);
                    }

                        else
                        {
                        floatingHealthBar.gameObject.SetActive(true);
                        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
