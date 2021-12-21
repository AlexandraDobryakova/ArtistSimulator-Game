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

    [SerializeField] GameObject[] characters;

    public new Text name;


    public GameObject panel_YouDied;

    void Start()
    {
        if (ChooseCharacter.gameIsStarted == true)
        {
            characters[ChooseCharacter.current_char].SetActive(true);
            name.text = ChooseCharacter.characterName;
        }
    }
    
    void Update()
    {
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
        }
        


        if ((FoodBar.fillAmount*100) == 0 || (MoodBar.fillAmount * 100) == 0 || (EnergyBar.fillAmount * 100) == 0)
        {
            panel_YouDied.SetActive(true);
        }
    }
}
