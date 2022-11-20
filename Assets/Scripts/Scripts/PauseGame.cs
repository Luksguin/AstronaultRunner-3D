using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public PlayerController playerController;

    /*public void Start()
    {
        Time.timeScale = 1;
    }

    public void Play()
    {
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }*/

    public void PlayGame()
    {
        playerController._inGame = true;
    }
}
