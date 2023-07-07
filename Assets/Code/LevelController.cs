using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      // Tämä on uusi kirjasto
using UnityEngine.UI;
using TMPro;
using System;

public class LevelController : MonoBehaviour
{
    public static LevelController instance; // Luodaan luokka "LevelController" jossa on "instance"-muuttuja jota muut luokat voivat käyttää

    public int numDestructables = 0;
    bool startNextLevel = false;
    float nextLevelTimer = 3;

    string[] levels = {"Menu","Dialogue","Level1","Level2","Boss","Epilogue"};
    int currentLevel = 3;



    
    public int score = 0;
    public TMP_Text scoreNumber; 
    Vector3 scoreNumberVector = new Vector3 (880.4655151367188f,464.5318298339844f,1.7107543945313f);



    private void Awake()        // Kun tämä koodi luodaan tarkistetaan onko instancella arvoa. Jos ei,  asetetaan instance-muuttujan arvoksi ".this" - eli ymmärtääkseni koko koodi. 
    {                           // Seuraavaksi suojataan gameObject tuhoamiselta. Else taas tuhoaa gameObjectin jos niitä on sceneä ladatessa useita
        if(instance == null)
        {
        instance = this;
        DontDestroyOnLoad(gameObject);          // Tämä koodi käyttää Awake-metodissa DontDestroyOnLoad-metodia(gameObject) 
        
        scoreNumber = GameObject.Find("ScoreNumber").GetComponent<TextMeshProUGUI>();  // En tiedä millä komennolla löydetään tekstikomponentti TMP:stä, joten tässä käytetty tavallista tekstiä.
        }
        else
        {
            Destroy(gameObject);
        }

    }
        

// Erilaisia TMP - formaatteja (GetComponent<>) :
//<TMPro.TextMeshPro>()  TAI
//<TMPro.TextMeshProUGUI>()



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startNextLevel)
        {
            if (nextLevelTimer <= 0)
            {
                currentLevel++;
                if (currentLevel <= levels.Length)
                {
                    string sceneName = levels[currentLevel -1];
                    SceneManager.LoadSceneAsync(sceneName);                //LoadSceneAsync lataa levelin taustalla. (LoadScene lataa levelin vasta kun ehto täyttyy)
                }
                else
                {
                    Debug.Log ("Game over");
                }
                nextLevelTimer = 3;
                startNextLevel = false;
            }
            else
            {
                nextLevelTimer -= Time.deltaTime;           // Else on tässä kätevä. nextLevelTimeriä vähennetään kunnes edeltävä ehto täyttyy.
            }
        }

        if (SceneManager.GetActiveScene().name == "Epilogue")
            {
                scoreNumber.transform.position = scoreNumberVector;
            }



    }

    public void ResetLevel()
    {
        Debug.LogFormat("ResetLevel");

        foreach(Bullet b in GameObject.FindObjectsOfType<Bullet>())  // Etsitään kaikki luodit scenestä jotta ne voidaan hävittää.
        {
            Destroy(b.gameObject);
        }
        numDestructables = 0;
        score = 0;
        AddScore(score);
        string sceneName = levels[currentLevel -1];
        SceneManager.LoadScene(sceneName);  
    }


    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        scoreNumber.text = score.ToString();
    }

    public void AddDestructable()
    {
        numDestructables++;
        Debug.Log("Add destructable");

    }

    public void RemoveDestructable()
    {
        numDestructables--;
        Debug.Log("Destructables left " + numDestructables);

        if(numDestructables ==0)
        {
            startNextLevel = true;
        }
    }



}
