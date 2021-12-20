using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bars : MonoBehaviour
{
    public Image FoodBar;
    public Image MoodBar;
    public Image EnergyBar;

    void Start()
    {
        
    }
    
    void Update()
    {
        FoodBar.fillAmount = Player.Satiety.Value * 0.01f;
        MoodBar.fillAmount = Player.Happiness.Value * 0.01f;
        EnergyBar.fillAmount = Player.Energy.Value * 0.01f;
    }
}
