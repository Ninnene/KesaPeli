using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreInDialogue : MonoBehaviour
{
    LevelController epilogueScoreNumber;

    public TMP_Text epilogueScoreNumberValue; 

    public TMP_Text scoreNumberLevel2; 
    int epilogueScore = 0;
    int level2Score = 0;



    // Start is called before the first frame update
    void Start()
    {
        

        Debug.Log("scoreNumberLevel2 = " + scoreNumberLevel2);
    }

    // Update is called once per frame
    void Update()
    {
        epilogueScoreNumber = GameObject.Find("---------------LevelController---------").GetComponent<LevelController>();
        
        epilogueScore = epilogueScoreNumber.score;
        level2Score =  epilogueScoreNumber.score;
        

        if((SceneManager.GetActiveScene().name == "Epilogue"))
        {
        epilogueScoreNumberValue.text = epilogueScore.ToString();
        }

        if((SceneManager.GetActiveScene().name == "Level2"))
        {
        scoreNumberLevel2.text = level2Score.ToString();
        }
    }
}
