using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacter : MonoBehaviour
{
    private int current_char;
    static public string characterName;
    static public int currentCharacter;
    [SerializeField] GameObject[] characters;
    [SerializeField] GameObject[] charactersGame;
    public InputField nameOf;
    public Canvas canvasChooseCharacter;
    public Canvas canvasGame;


    public Text nameOfPlayer;


    public void ClickOnLeftButton()
    {
        if (current_char == 0)
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
        canvasChooseCharacter.gameObject.SetActive(false);
        canvasGame.gameObject.SetActive(true);
        nameOfPlayer.text = characterName;
        charactersGame[currentCharacter].SetActive(true);
    }

    public void GetName()
    {
        characterName = nameOf.text;
    }
}
