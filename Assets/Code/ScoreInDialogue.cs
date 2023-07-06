using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreInDialogue : MonoBehaviour
{
    LevelController epilogueScoreNumber;

    public TMP_Text epilogueScoreNumberValue; 
    int epilogueScore = 0;



    // Start is called before the first frame update
    void Start()
    {
        epilogueScoreNumber = GameObject.Find("---------------LevelController---------").GetComponent<LevelController>();
        
        epilogueScore = epilogueScoreNumber.score;
        
        epilogueScoreNumberValue.text = epilogueScore.ToString();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
