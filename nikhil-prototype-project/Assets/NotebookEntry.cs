using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class NotebookEntry : MonoBehaviour
{
    Memory memory;
    public Image icon; 

    public void AddMem(Memory newMem)
    {
        memory = newMem;

        icon.sprite = memory.icon;
        icon.enabled = true; 
    }

    public void Remember()
    {
        if(memory != null)
        {

        }
    }
}
