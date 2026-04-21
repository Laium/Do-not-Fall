using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>(); // sets the GameMaster to the object with the GM tag (checkpoints)
    }
    void OnTriggerEnter2D(Collider2D other) // action when checkpoint collides with another object (other) in the scene
    {
        if (other.CompareTag("Player")) 
        {
            gm.lastcheckpointPos = transform.position; 
            // When the checkpoint collides with an object with the player tag
            // it will change the stored variable of the checkpoint within the 
            // GameMaster script with the current coordinates of its position

            
        }
    }
    
        
    
}
