using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;


public class PauseMenuSCRIPT : MonoBehaviour
{

    private Player playerScript;
    public TMPro.TMP_Text canvasPoints;


    public static bool GameIsPaused = false;

    public GameObject pausemenuUI;


    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        //FindObjectOfType<AudioManagerScript>().Play("Nappi");
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

    public void ResetAbilities()
    {
        playerScript = GameObject.Find("PikkuKala").GetComponent<Player>();
        //canvasPoints = GameObject.Find("ScoreNumber").GetComponent<UnityEngine.UI.Text>();
        canvasPoints = GameObject.Find("ScoreNumber").GetComponent<TMP_Text>();

        playerScript.hits = 3;
        playerScript.powerUpGunLevel = 0;
        playerScript.speedMultiplier = 1;

        canvasPoints.text = "";

                playerScript.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                playerScript.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                playerScript.gameObject.transform.GetChild(3).gameObject.SetActive(false);
                playerScript.gameObject.transform.GetChild(4).gameObject.SetActive(false);
                playerScript.gameObject.transform.GetChild(5).gameObject.SetActive(false);

                playerScript.DeactivateShield();

        //Debug.Log("Players hits  = " + playerScript.hits);
        //Debug.Log("Players Gunlevel  = " + playerScript.powerUpGunLevel);
        //Debug.Log("Players speed  = " + playerScript.speedMultiplier);
    }
}
