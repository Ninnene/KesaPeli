using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Animator animator;


    private Queue<string> sentences;  // Queue toimii hieman kuten listat ([]). 
                                    //Se on "FIFO" = First in, first out - tyyppinen metodi. Se lataa aina seuraavan, tässä tapauksessa tekstin, listan lopusta.
    void Start()
    {
        sentences = new Queue<string>();
    }

   public void StartDialogue(Dialogue dialogue)
   {
    
        animator.SetBool("IsOpen", true); // Aktivoidaan animator-komponentti

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
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence; (Kutsutaan tämän sijaan co-routine TypeSentenceä)
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence) // Luodaan co-routine TypeSentence()
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) // ToCharArray() on metodi joka muuttaa stringin kirjainlistaksi
        {
            dialogueText.text += letter;
            yield return null; //Odotetaan yksi frame
        }
        
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation");
        animator.SetBool("IsOpen", false);
        
    }
}
