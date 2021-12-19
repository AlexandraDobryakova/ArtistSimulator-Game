using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsInFirstScene : MonoBehaviour
{
    public Canvas canvasMenu;
    public Canvas canvasSettings;
    public GameObject panelStartGame;
    public GameObject panelContinueGame;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartNewGame()
    {
        if (ChooseCharacter.gameIsStarted == false)
        {
            SceneManager.LoadScene(1);
        }
            
        else
        {
            panelStartGame.SetActive(true);
        }
    }

    public void Yes_NewGame()
    {
        ChooseCharacter.gameIsStarted = false;
        //ChangeBars.fill = 1f;
        SceneManager.LoadScene(1);
    }

    public void No_NewGame()
    {
        panelStartGame.SetActive(false);
    }

    public void ContinueGame()
    {
        if (ChooseCharacter.gameIsStarted == false)
        {
            panelContinueGame.SetActive(true);
        }

        else
        {
            ChooseCharacter.gameIsStarted = true;
            Pause.GameIsStarted_IsStopped = false;
            ChangeBars.saving = 1;
            SceneManager.LoadScene(1);
            

        }
    }

    public void Yes_ContinueGame()
    {
        SceneManager.LoadScene(1);
    }

    public void No_ContinueGame()
    {
        panelContinueGame.SetActive(false);
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
