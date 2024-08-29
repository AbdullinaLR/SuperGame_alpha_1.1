using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<MCDialougeManager>().StartDialogue(dialogue);
    }
}

