using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCDialogueAnimator : MonoBehaviour
{
  public Animator startAnim;
  public MCDialougeManager dm2;

 public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            startAnim.SetBool("MCthink", true);
        }
    }
  

   public void OnTriggerExit2D(Collider2D other)
  {
    startAnim.SetBool("MCthink", false);
    dm2.EndDialogue();
  }
}
