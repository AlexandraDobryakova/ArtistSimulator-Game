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

    public Text FoodText;
    public Text HealthText;
    public Text MoodText;
    public Text PaintingText;

    public float fill;

    void Start()
    {
        fill = 1f;
    }


    void Update()
    {
        if (ChooseCharacter.gameIsStarted == true && fill >= 0)
        {
            fill -= Time.deltaTime * 0.01f;
            FoodBar.fillAmount = fill;
            HealthBar.fillAmount = fill;
            MoodBar.fillAmount = fill;
            PaintingBar.fillAmount = fill;

            FoodText.text = Mathf.Round(FoodBar.fillAmount * 100f).ToString() + '%';
            HealthText.text = Mathf.Round(HealthBar.fillAmount * 100f).ToString() + '%';
            MoodText.text = Mathf.Round(MoodBar.fillAmount * 100f).ToString() + '%';
            PaintingText.text = Mathf.Round(PaintingBar.fillAmount * 100f).ToString() + '%';
        }
    }
}
