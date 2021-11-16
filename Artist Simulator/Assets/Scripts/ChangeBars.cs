using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBars : MonoBehaviour
{
    public Image FoodBar;
    public Image HealthBar;
    public Image MoodBar;
    public Image PaintingBar;

    public float fill;

    void Start()
    {
        fill = 1f;
    }


    void Update()
    {
        if (ChooseCharacter.gameIsStarted == true && fill >= 0)
        {
            fill -= Time.deltaTime * 0.1f;
            FoodBar.fillAmount = fill;
            HealthBar.fillAmount = fill;
            MoodBar.fillAmount = fill;
            PaintingBar.fillAmount = fill;
        }
    }
}
