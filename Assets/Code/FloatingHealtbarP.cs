using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FloatingHealtbarP : MonoBehaviour
{
    [SerializeField] private Slider slider;


    void Start()
    {
            if (SceneManager.GetActiveScene().name == "Dialogue")
            {
                gameObject.transform.parent.gameObject.SetActive(false);
                gameObject.SetActive(false);
                Debug.Log("Disable player healtbar.");
                
            }
                if (SceneManager.GetActiveScene().name == "Epilogue")
                {
                    gameObject.transform.parent.gameObject.SetActive(false);
                    gameObject.SetActive(false);
                    Debug.Log("Disable player healtbar.");
                }

                    else
                    {
                        gameObject.SetActive(true);
                        gameObject.transform.parent.gameObject.SetActive(true);
                    }
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

