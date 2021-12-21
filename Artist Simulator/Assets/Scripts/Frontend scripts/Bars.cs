using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bars : MonoBehaviour
{
    public Image FoodBar;
    public Image MoodBar;
    public Image EnergyBar;

    public GameObject panel_YouDied;
    void Start()
    {
        
    }
    
    void Update()
    {
        FoodBar.fillAmount = Player.Satiety.Value * 0.01f;
        MoodBar.fillAmount = Player.Happiness.Value * 0.01f;
        EnergyBar.fillAmount = Player.Energy.Value * 0.01f;


        if ((FoodBar.fillAmount*100) == 0 || (MoodBar.fillAmount * 100) == 0 || (EnergyBar.fillAmount * 100) == 0)
        {
            panel_YouDied.SetActive(true);
        }
    }
}
