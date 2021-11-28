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
        TIME,
        ENERGY
    };

    private static readonly string[] techniquesNames =
    {
        "Кисти и холст",
        "Графический планшет",
        "Баллончик с краской",
        "Карандаш"
    };

    private static readonly string[] genresNames =
    {
        "Граффити",
        "Натюрморт",
        "Пейзаж",
        "Портрет",
        "Современное искусство"
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

            default:
                textObject.text = "-";
                break;

        }
    }
}
