using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    public static bool GameIsStarted_IsStopped;

    public void ClickOnPauseButton()
    {
        panel.SetActive(true);
        GameIsStarted_IsStopped = true;
    }

    public void ContinueGame()
    {
        panel.SetActive(false);
        GameIsStarted_IsStopped = false;
    }

    public void GoToMenu()
    {

        SceneManager.LoadScene(0);
        GameIsStarted_IsStopped = true;

    }
}
