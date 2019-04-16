using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator; 

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
        Debug.Log("Interaction");
        //animator.SetBool("IsOpen", true);  

        nameText.text = dialogue.interactableName; 

        sentences.Clear(); 

        foreach(string sentence in dialogue.sentences)
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

        string nextSentence = sentences.Dequeue();

        StopAllCoroutines(); 
        StartCoroutine(TypeSentence(nextSentence)); 
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = ""; 
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null; 
        }
    }

    public void EndDialogue()
    {
        Debug.Log("Convo over");
        //animator.SetBool("IsOpen", false);
    }

}
