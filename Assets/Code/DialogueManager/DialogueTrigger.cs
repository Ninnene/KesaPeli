using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
   public Dialogue dialogue;    // Tämä luonnollisesti lainaa Dialogue-luokkaa (Dialogue-Koodissa) joka nimetään dialogueksi tässä. (Siellä on nimi ja)

   public void TriggerDialogue()
   {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue); // Etsitään DialogueManager-luokka
   }
}
