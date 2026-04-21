using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastcheckpointPos; // storing position of checkpoint

    void Awake()
    {   
        if(instance == null) // checking if there is an instance
        {
            instance = this; // swapping instances
            DontDestroyOnLoad(instance); // stores the object throughout scenes
        }
        else
        {
            Destroy(this.gameObject);
        }
        // The statements above ensure that there will not be more than one 
        // gamemaster object. When the scene is reloaded to spawn at the last checkpoint
        // from the PlayerPos script, another GameMaster will be created, hence the code
        // will destroy the newly created GameMaster if the GameMaster already exists.
        // Keeping the prexisting GameMaster keeps the data of lastcheckpointPos
    } 


}
