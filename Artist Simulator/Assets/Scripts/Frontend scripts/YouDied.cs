using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDied : MonoBehaviour
{

    public GameObject panel_MakeCharacter;
    public GameObject currentPanel;
    public GameObject DiePanel;


    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
        currentPanel.SetActive(false);
        DiePanel.SetActive(false);
        panel_MakeCharacter.SetActive(true);
        Player.Satiety.Value = 100;
        Player.Happiness.Value = 100;
        Player.Energy.Value = 100;
    }

    public void StartAgain()
    {
        currentPanel.SetActive(false);
        DiePanel.SetActive(false);
        panel_MakeCharacter.SetActive(true);
        Player.Money.Value = 1000;
        Player.Satiety.Value = 100;
        Player.Happiness.Value = 100;
        Player.Energy.Value = 100;
    }
}
