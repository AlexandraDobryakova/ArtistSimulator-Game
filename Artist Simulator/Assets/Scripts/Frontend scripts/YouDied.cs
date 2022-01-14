using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDied : MonoBehaviour
{

    public GameObject panel_MakeCharacter;
    public GameObject currentPanel;
    public GameObject DiePanel;
    public GameObject panel_Job;
    public GameObject button_Work;
    public static bool IsDied = false;

    public void GoToMenu()
    {
        IsDied = true;
        SceneManager.LoadScene(0);
        currentPanel.SetActive(false);
        DiePanel.SetActive(false);
        panel_MakeCharacter.SetActive(true);
        Game.StartNewGame();
        //IsDied = false;
        ChooseCharacter.gameIsStarted = false;
        Game.GameIsStarted = false;
        Player.Name = null;
    }

    public void StartAgain()
    {
        Game.StartNewGame();
        IsDied = true;
        ChooseCharacter.gameIsStarted = false;
        currentPanel.SetActive(false);
        DiePanel.SetActive(false);
        //panel_Job.SetActive(false);
        //button_Work.transform.position = new Vector3(button_Work.transform.position.x, button_Work.transform.position.y - 0.1f, 0);
        panel_MakeCharacter.SetActive(true);
        //Game.StartNewGame();
        ChooseCharacter.gameIsStarted = false;
        Game.GameIsStarted = false;
        Player.Name = null;
        //FiveButtons.wor
        /*SceneManager.LoadScene(0);
        panel_MakeCharacter.SetActive(true);
        currentPanel.SetActive(false);
        SceneManager.LoadScene(1);*/
        //IsDied = false;
    }
}
