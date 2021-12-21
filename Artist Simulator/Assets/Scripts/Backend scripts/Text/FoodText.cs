using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FoodText : MonoBehaviour
{
    public int number;
    public Text textObject;
    public Values showingValue;

    public enum Values
    {
        NONE,
        Name,
        Price,
    };

    // Update is called once per frame
    void Update()
    {
        
        if (number < 0 || number > GameConstants.FoodVariants.Length)
            throw new ArgumentException($"Food number can be only in range[0, {GameConstants.FoodVariants.Length}]");

        switch (showingValue)
        {
            case Values.Name:
                textObject.text = $"{GameConstants.FoodVariants[number].Name}";
                break;

            case Values.Price:
                textObject.text = $"{GameConstants.FoodVariants[number].Price}";
                break;

            default:
                throw new ArgumentException("Select a showing value");

        }
    }
}
