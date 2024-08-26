using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public Transform player;
    public int index;

    void Awake()
    {
        player = GameObject.Find("Hero").transform;
        if(DataContainer.checkpointIndex == index)
        {
            player.position = transform.position;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Hero")
        {
            DataContainer.checkpointIndex = index;
        }
    }
}
