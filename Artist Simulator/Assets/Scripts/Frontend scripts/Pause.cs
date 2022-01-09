using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    public static bool GameIsStarted_IsStopped;

    public static int Satiety_Save = 100;
    public static int Happiness_Save = 100;
    public static int Energy_Save = 100;
    public static int Money_Save = 20;
    
    public void ClickOnPauseButton() // открывается панель с паузой 
    {
        panel.SetActive(true);
        GameIsStarted_IsStopped = true;
    }

    public void ContinueGame() // закрыть панель с паузой и продолжить игру
    {
        panel.SetActive(false);
        GameIsStarted_IsStopped = false;
    }

    public void GoToMenu() // выйти из игры в главное меню 
    {
        Game.Save();
        SceneManager.LoadScene(0);
        GameIsStarted_IsStopped = true;
        Satiety_Save = Player.Satiety.Value;
        Happiness_Save = Player.Happiness.Value;
        Energy_Save = Player.Energy.Value;
        Money_Save = Player.Money.Value;
    }
}
