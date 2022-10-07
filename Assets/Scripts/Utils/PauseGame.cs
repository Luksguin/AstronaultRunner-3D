using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 0;
    }

    /*public void Pause()
    {
        Time.timeScale = 0;
    }*/

    public void PlayGame()
    {
        Time.timeScale = 1;
    }
}
