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
                textObject.text = $"{PlayerStats.Money.Value}{PlayerStats.Money.Dimension}";
                break;

            default:
                textObject.text = "-";
                break;

        }
    }
}
