using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFunction : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0f;
            Debug.Log("Paused the game");

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            Debug.Log("Resumed the game");
        }
    }
}
