using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsInFirstScene : MonoBehaviour
{
    public Canvas canvasMenu;
    public Canvas canvasSettings;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToSettings()
    {
        canvasMenu.gameObject.SetActive(false);
        canvasSettings.gameObject.SetActive(true);
    }

    public void ReturnToMenu()
    {
        canvasMenu.gameObject.SetActive(true);
        canvasSettings.gameObject.SetActive(false);
    }
}
