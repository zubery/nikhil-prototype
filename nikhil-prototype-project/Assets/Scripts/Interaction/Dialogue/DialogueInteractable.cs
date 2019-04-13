using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : Interactable
{
    public Dialogue dialogue;
    public Memory memory; 

    public override void Interact()
    {
        base.Interact();
        DialogueManager.instance.StartDialogue(dialogue);
    }

    private void Remember()
    {
        Notebook.instance.Add(memory); 
    }
}
