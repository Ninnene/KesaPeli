using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
   public Dialogue dialogue;    // Tämä luonnollisesti lainaa Dialogue-luokkaa (Dialogue-Koodissa) joka nimetään dialogueksi tässä.
   bool dialogueIsTriggered = false;
   bool keyboardForward;

   void Update() 
    {
        //keyboardForward = Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Return);

        if(Input.anyKeyDown && !dialogueIsTriggered)
        {
         TriggerDialogue();
         dialogueIsTriggered = true;
        }
    }

    

   public void TriggerDialogue()
   {
      dialogueIsTriggered = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue); // Etsitään DialogueManager-luokka

   }

}
