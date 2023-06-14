using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuScript : MonoBehaviour
{
    public void PlayGame ()
    {
        //play nappi siirtyy build menussa seuraavana olevaan sceneen
        //eli nykyinen scene + 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        //Debug.Log ("Quit");
        Application.Quit();
    }

}
