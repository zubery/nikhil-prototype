using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : MonoBehaviour
{
    public Dialogue dialogue; 

    public void TriggerInteraction()
    {
        DialogueManager.instance.StartDialogue(dialogue); 
    }

}
