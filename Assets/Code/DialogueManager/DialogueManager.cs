using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    DialogueTrigger dialogueTrigger;
    bool keyPress;
    bool startDialogue = false;

    public Text nameText;
    public Text dialogueText;
    public Animator textBox;
    public Animator iPK;
    public Animator player;
    public Animator thanksForPlaying;


    public Image blackImage;

    // Duration of the fade in seconds
    public float fadeDuration = 1f;
    //public Animator animator4;


    private Queue<string> sentences;  // Queue toimii hieman kuten listat ([]). 
                                    //Se on "FIFO" = First in, first out - tyyppinen metodi. Se lataa aina seuraavan, tässä tapauksessa tekstin, listan alusta.
    void Start()
    {
        sentences = new Queue<string>();
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
    }

    void Update() 
    {
        //keyPress = Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Return);

        if (Input.anyKeyDown && !keyPress)
        {
            keyPress = true;
            DisplayNextSentence();
            keyPress = false;
        }
    }

    
   public void StartDialogue(Dialogue dialogue)
   {
    

        startDialogue = true;
    
        textBox.SetBool("IsOpen", true); // Aktivoidaan animator-komponentti
        iPK.SetBool("IsOpen", true);
        //animator4.SetBool("IsOpen", true);
        

        nameText.text = dialogue.name;

        sentences.Clear(); //Tyhjennetään (Clear();) sentences jotka saadaan Dialogue-luokalta. 

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

   }
    
    public void DisplayNextSentence()
    {      
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        
        if(sentences.Count == 5)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
            iPK.SetBool("IsOpen", false);
            player.SetBool("IsOpen", true);
        }

        if(sentences.Count <= 2)
        {   
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            //gameObject.transform.GetChild(2).gameObject.SetActive(true);
            iPK.SetBool("IsOpen", true);
            player.SetBool("IsOpen", false);
        }


        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        //Tässä huonompi tapa : "dialogueText.text = sentence;" (Kutsutaan tämän sijaan co-routine TypeSentenceä)
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence) // Luodaan co-routine TypeSentence()
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) // ToCharArray() on metodi joka muuttaa stringin kirjainlistaksi
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f);  //Odotetaan yksi frame
        }
        
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation");
        textBox.SetBool("IsOpen", false);
        iPK.SetBool("IsOpen", false);
        StartCoroutine(FadeImage());
        StartCoroutine(WaitAndLoadNextScene());    
    }

        IEnumerator WaitAndLoadNextScene()
        {
            // Wait for X seconds
            yield return new WaitForSeconds(1f);
            // Load the next scene

                if(SceneManager.GetActiveScene().name != "Epilogue")
                {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            
                    if(SceneManager.GetActiveScene().name == "Epilogue")
                    {
                        thanksForPlaying.SetBool("IsOpen",true);
                    }
        }

         IEnumerator FadeImage()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);

        if(thanksForPlaying == true)
        {
            fadeDuration = 500;
        }

            // Loop from 0 to 1 in fadeDuration seconds
            for (float t = 0f; t < 1f; t += Time.deltaTime / fadeDuration)
            {
                // Set the alpha value of the image based on t
                Color newColor = blackImage.color;
                newColor.a = t;
                blackImage.color = newColor;

                // Wait for one frame
                yield return null;
            }

            // Make sure the image is fully opaque at the end
            Color finalColor = blackImage.color;
            finalColor.a = 1f;
            blackImage.color = finalColor;
    }
}
