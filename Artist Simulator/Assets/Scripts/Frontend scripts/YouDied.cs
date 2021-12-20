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
    }

    public void StartAgain()
    {
        currentPanel.SetActive(false);
        DiePanel.SetActive(false);
        panel_MakeCharacter.SetActive(true);
        Player.Money.Value = 1000; 
    }
}
