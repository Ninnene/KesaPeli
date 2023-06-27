using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    GameOver gameOver;
    bool moveGameOverTextToView = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver.gameOver == true)
        {
            moveGameOverTextToView = true;
        }
    }
}
