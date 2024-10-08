using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MCDialougeManager : MonoBehaviour
{
   public Text dialogueText;
   public Text nameText;
  [SerializeField] private AudioSource thinkingSound;
   public Animator boxAnim;
   public Animator startAnim;

   private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        thinkingSound.Play();
        boxAnim.SetBool("boxOpen", true);
        startAnim.SetBool("MCthink", false);
        nameText.text = dialogue.name;
        
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
        
        thinkingSound.Play();
        string sentence = sentences.Dequeue();
        thinkingSound.Play();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
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
        boxAnim.SetBool("boxOpen", false);
    }

}

