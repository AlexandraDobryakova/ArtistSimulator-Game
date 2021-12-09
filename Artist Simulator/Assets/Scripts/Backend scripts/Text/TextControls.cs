using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextControls : MonoBehaviour
{
    //[HideInInspector]
    public enum Values
    {
        MONEY,
        HAPPINESS,
        ENERGY,
        SATIETY,
        TIME
    };

   

    public Text textObject;
    public Values showingValue;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (showingValue)
        {
            case Values.MONEY:
                textObject.text = $"{Player.Money.Value}{Player.Money.Dimension}";
                break;

            case Values.ENERGY:
                textObject.text = $"{Player.Energy.Value}{Player.Energy.Dimension}";
                break;

            case Values.HAPPINESS:
                textObject.text = $"{Player.Happiness.Value}{Player.Happiness.Dimension}";
                break;

            case Values.SATIETY:
                textObject.text = $"{Player.Satiety.Value}{Player.Satiety.Dimension}";
                break;

            case Values.TIME:
                textObject.text = $"days: {Game.Time.Days} time: {Game.Time.Hours}";
                break;

            default:
                textObject.text = "---";
                break;

        }
    }
}
