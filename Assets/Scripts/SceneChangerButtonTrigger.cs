using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangerButtonTrigger : MonoBehaviour
{
    public Animator anim;  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetTrigger("scenechagertriggered");

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetTrigger("scenechagertriggered");
            
        }
    }
}
