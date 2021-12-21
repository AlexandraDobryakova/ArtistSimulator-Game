using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ContractPoolText : MonoBehaviour
{
    public int contractNumber;
    public Text textObject;
    public Values showingValue;

    public enum Values
    {
        NONE,
        Reward,
        Difficulty,
        Required_Technique,
        Required_Genre,
        DaysLeft,
        PercentExecution
    };

    // Update is called once per frame
    void Update()
    {
        if (contractNumber < 0 || contractNumber > 5)
            throw new ArgumentException($"contractNumber can be only in range[0, {Game.ContractsPool.Length}]");

        switch (showingValue)
        {
            case Values.Reward:
                textObject.text = $"{Game.ContractsPool[contractNumber].ContractPrice}ð";
                break;

            case Values.Difficulty:
                textObject.text = $"{Game.ContractsPool[contractNumber].Difficulty}";
                break;

            case Values.DaysLeft:
                if(Player.CurrentContract != null)
                    textObject.text = $"{Player.CurrentContract.GetDaysLeft()}";
                break;

            case Values.PercentExecution:
                if (Player.CurrentContract != null)
                    textObject.text = $"{Player.CurrentContract.GetPercentExecution()}%";
                break;

            case Values.Required_Technique:
                textObject.text = $"{GameConstants.techniquesNames[(int)Game.ContractsPool[contractNumber].requiredTechnique]}";
                break;

            case Values.Required_Genre:
                textObject.text = textObject.text = $"{GameConstants.genresNames[(int)Game.ContractsPool[contractNumber].requiredGenre]}";
                break;

            default:
                throw new ArgumentException("Select a showing value");

        }
    }
}
