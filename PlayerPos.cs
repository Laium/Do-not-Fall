using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastcheckpointPos;
    }
    // When the scene starts the gamemaster is set to the object with the "GM" tag
    // the coordinates stored in lastcheckpointPos is set to the position of the player
    // spawming the player at the last checkpoint triggered from the Checkpoint script.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        // This if Statement is used to reset the scene to spawn at the last checkpoint
    }
}
