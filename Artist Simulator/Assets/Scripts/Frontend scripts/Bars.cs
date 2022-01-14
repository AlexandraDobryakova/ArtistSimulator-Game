using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bars : MonoBehaviour
{
    public Image FoodBar;
    public Image MoodBar;
    public Image EnergyBar;
    public Image ContractBar;

    public GameObject[] characters;

    public new Text name;


    public GameObject panel_YouDied;

    public Text contractName;
    public Text contractSalary;
    public Text contractPercent;


    void Start()
    {
        /*if (ChooseCharacter.gameIsStarted == true)
        {
            characters[1].SetActive(false);
            characters[2].SetActive(false);
            characters[3].SetActive(false);
            characters[0].SetActive(false);
            characters[ChooseCharacter.current_char].SetActive(true);
            name.text = ChooseCharacter.characterName;
        }*/

        characters[1].SetActive(false);
        characters[2].SetActive(false);
        characters[3].SetActive(false);
        characters[0].SetActive(false);
        //characters[Player.CharacterNum].SetActive(true); // here
        //name.text = Player.Name; // here 

        if (Player.Name != null)
        {
            name.text = Player.Name;
            characters[Player.CharacterNum].SetActive(true); // here
        }
        else
        {
            Player.Name = ChooseCharacter.characterName;
            Player.CharacterNum = ChooseCharacter.currentCharacter;

            name.text = Player.Name;
            characters[Player.CharacterNum].SetActive(true); // here
        }
    }
    
    void Update()
    {
        characters[1].SetActive(false);
        characters[2].SetActive(false);
        characters[3].SetActive(false);
        characters[0].SetActive(false);

        /*characters[ChooseCharacter.current_char].SetActive(true);
        name.text = ChooseCharacter.characterName;*/

        name.text = Player.Name;
        characters[Player.CharacterNum].SetActive(true); // here


        FoodBar.fillAmount = Player.Satiety.Value * 0.01f;
        MoodBar.fillAmount = Player.Happiness.Value * 0.01f;
        EnergyBar.fillAmount = Player.Energy.Value * 0.01f;

        if (Player.CurrentContract != null)
        {
            ContractBar.fillAmount = Player.CurrentContract.GetPercentExecution() * 0.01f;
        }
        else
        {
            ContractBar.fillAmount = 0;
            contractName.text = "---";
            contractSalary.text = "---";
            contractPercent.text = "---";
            //ContractBar.fillAmount = 0;
            Player.CurrentContract = null;
        }
        


        if ((FoodBar.fillAmount*100) == 0 || (MoodBar.fillAmount * 100) == 0 || (EnergyBar.fillAmount * 100) == 0)
        {
            panel_YouDied.SetActive(true);
        }

        /*if (Player.CurrentContract.GetPercentExecution() >= 100)
        {
            contractName.text = "---";
            contractSalary.text = "---";
            contractPercent.text = "---";
            ContractBar.fillAmount = 0;
            Player.CurrentContract = null;
        }*/
    }
}
