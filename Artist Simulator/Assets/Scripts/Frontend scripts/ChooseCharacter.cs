using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacter : MonoBehaviour
{
    static public int current_char = 0;
    static bool clicked_button = false;
    static public string characterName;
    static public int currentCharacter = 0;
    [SerializeField] GameObject[] characters;
    [SerializeField] GameObject[] charactersGame;
    public InputField nameOf;
    public Canvas canvasChooseCharacter;
    public Canvas canvasGame;
    public GameObject Button_StartGame;
    public static bool youInChoosing = false;

    public static bool gameIsStarted;

    public Text nameOfPlayer;
    void Start()
    {
        characters[0].SetActive(true);
        characters[1].SetActive(false);
        characters[2].SetActive(false);
        characters[3].SetActive(false);
        current_char = 0;
        youInChoosing = true;
        if (gameIsStarted)
        {
            canvasGame.gameObject.SetActive(true);
            canvasChooseCharacter.gameObject.SetActive(false);
        }
        nameOf.text = "";

        if (Pause.GameIsStarted_IsStopped == false)
        {
            Player.Satiety.Value = Pause.Satiety_Save;
            Player.Happiness.Value = Pause.Happiness_Save;
            Player.Energy.Value = Pause.Energy_Save;
            Player.Money.Value = Pause.Money_Save;
        }
    }

    private void Update()
    {
        if (nameOf.text.Length > 0)
        {
            Button_StartGame.SetActive(true);
        }
        else
        {
            Button_StartGame.SetActive(false);
        }
    }

    public void ClickOnLeftButton()
    {
        if (current_char == 0 /*&& clicked_button == false*/)
        {
            characters[current_char].SetActive(false);

            current_char = characters.Length - 1;
            characters[current_char].SetActive(true);
            currentCharacter = current_char;
        }
        else
        {
            characters[current_char].SetActive(false);

            current_char--;
            characters[current_char].SetActive(true);
            currentCharacter = current_char;
        }
        currentCharacter = current_char;
    }

    public void ClickOnRightButton()
    {
        if (current_char == characters.Length - 1)
        {
            characters[current_char].SetActive(false);

            current_char = 0;
            characters[current_char].SetActive(true);
            currentCharacter = current_char;
        }
        else
        {
            characters[current_char].SetActive(false);

            current_char++;
            characters[current_char].SetActive(true);
            currentCharacter = current_char;
        }
        currentCharacter = current_char;
    }

    public void StartGame()
    {
        gameIsStarted = true;
        canvasChooseCharacter.gameObject.SetActive(false);
        canvasGame.gameObject.SetActive(true);
        nameOfPlayer.text = characterName;
        charactersGame[currentCharacter].SetActive(true);
        gameIsStarted = true;
        Pause.GameIsStarted_IsStopped = false;
        ChooseCharacter.gameIsStarted = true;
        youInChoosing = false;
        //characters[ChooseCharacter.current_char].SetActive(true);
        /*Bars.characters[0].SetActive(false);
        Bars.characters[1].SetActive(false);
        Bars.characters[2].SetActive(false);
        Bars.characters[3].SetActive(false);
        Bars.characters[currentCharacter].SetActive(true);*/
    }

    public void GetName()
    {
        if (nameOf.text.Length > 0)
        {
            characterName = nameOf.text;
            Button_StartGame.SetActive(true);
        }
    }
}
