using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuSCRIPT : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pausemenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //eli kun esc näppäintä painetaan tapahtuu...
        {
            if (GameIsPaused) // onko peli pausetettu? jos oli...
            {
                Resume(); // jatketaan
            }
            else // ei ollut pausetettu...
            {
            Pause(); // pausetetaan
            }
        }
    }

    public void Resume() // metodi pelin jatkamiselle
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() // metodi pelin pausettamiselle
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void OptionsMenu()
    {
        Time.timeScale = 1f;
        Resume();
        SceneManager.LoadScene(0);
        //Debug.Log("OptionsMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
