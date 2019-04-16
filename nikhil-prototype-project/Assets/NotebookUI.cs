using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookUI : MonoBehaviour
{
    public Transform noteParent;
    NotebookEntry[] entries;
    public GameObject notebookUI; 

    Notebook notebook; 

    // Start is called before the first frame update
    void Start()
    {
        notebook = Notebook.instance;
        notebook.onRemembranceCallback += UpdateUI;

        entries = noteParent.GetComponentsInChildren<NotebookEntry>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Notebook"))
        {
            notebookUI.SetActive(!notebookUI.activeSelf); 
        }
    }

    void UpdateUI()
    {
        for(int i = 0; i < entries.Length; i++)
        {
            if(i < notebook.memories.Count)
            {
                entries[i].AddMem(notebook.memories[i]); 
            }
        }
    }

}
