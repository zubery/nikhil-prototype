using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : Interactable
{
    public Dialogue dialogue;
    public Memory memory;
    public bool isMemory;
    public bool isFixable;  

    public override void Interact()
    {
        base.Interact();
        DialogueManager.instance.StartDialogue(dialogue);

        if(isMemory)
        {
            Remember(); 
        }
        else if(isFixable)
        {

        }
    }

    private void Remember()
    {
        Notebook.instance.Add(memory); 
    }
}
