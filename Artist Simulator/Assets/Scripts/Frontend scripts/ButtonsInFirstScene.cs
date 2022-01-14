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

    public void ExitGame() // Выйти из игры 
    {
        Game.Save();
        Application.Quit();
    }

    public void StartNewGame() // Кнопка - начать новую игру
    {
        if (/*ChooseCharacter.gameIsStarted == false || */!Game.HasSave()) // если это первый запуск, то просто запускается первая сцена 
        {
            Game.StartNewGame();
            SceneManager.LoadScene(1);
        }
            
        else // если игра  была запущена ранее - открывается панель с вопросом - начать новую игру?
        {
            panelStartGame.SetActive(true);
        }
    }

    public void Yes_NewGame() // да, я хочу начать новую игру (стереть старую)
    {
        Game.StartNewGame();
        ChooseCharacter.gameIsStarted = false;
        Game.GameIsStarted = false;
        //ChangeBars.fill = 1f;
        SceneManager.LoadScene(1);
        Player.Name = null;
        //Game.StartNewGame(); // 06 jan
        ChooseCharacter.current_char = 0;
        ChooseCharacter.currentCharacter = 0;
    }

    public void No_NewGame() // нет, отмена - закрытие панели с вопросом - начать новую игру?
    {
        panelStartGame.SetActive(false);
    }

    public void ContinueGame() // кнопка - продолжить игру
    {
        if (/*ChooseCharacter.gameIsStarted == false || */!Game.HasSave()) // если игра не была ранее запушена, котрывается панель с текстом - у вас нет сохраненной игры, хотите начать новую?
        {
            panelContinueGame.SetActive(true);
        }

        else // если игра была ранее запущена, то просто откывается сцена 1 и загружаются данные 
        {
            Game.Load();
            ChooseCharacter.gameIsStarted = true;
            Pause.GameIsStarted_IsStopped = false;
            ChangeBars.saving = 1;
            SceneManager.LoadScene(1);
        }
    }

    public void Yes_ContinueGame() // да, я хочу начать новую игру
    {
        Game.StartNewGame();
        SceneManager.LoadScene(1);
        Player.Name = null;

    }

    public void No_ContinueGame() // нет, отмена - закрытие панели 
    {
        panelContinueGame.SetActive(false);
    }

    public void GoToSettings() // переход на панель с настройками 
    {
        canvasMenu.gameObject.SetActive(false);
        canvasSettings.gameObject.SetActive(true);
    }

    public void ReturnToMenu() // вернуться в меню из настроек 
    {
        canvasMenu.gameObject.SetActive(true);
        canvasSettings.gameObject.SetActive(false);
    }
}
