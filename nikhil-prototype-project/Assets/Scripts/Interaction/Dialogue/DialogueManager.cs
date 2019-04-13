using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    private Queue<string> sentences;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Destroyed duplicate dialogue manager");
            Destroy(gameObject);
            return;
        }

        instance = this;

        sentences = new Queue<string>(); 
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear(); 

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); 
        }

        Debug.Log("Starting convo with: " + dialogue.interactableName); 
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return; 
        }

       string nextSentence = sentences.Dequeue();
        Debug.Log(nextSentence); 
    }

    public void EndDialogue()
    {
        Debug.Log("Convo over"); 
    }

}
