using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBars : MonoBehaviour
{
    public Image FoodBar;
    public Image HealthBar;
    public Image MoodBar;
    public Image EnergyBar;
    public Image XpBar;

    [SerializeField] GameObject[] characters;
    
    public Text FoodText;
    public Text HealthText;
    public Text MoodText;
    public Text EnergyText;
    public Text XpText;
    
    public new Text name;
    /*
    float Food;
    float Health;
    float Mood;
    float Painting;
    */
    public static int saving = 0;
    /*
    static public float fill = 1f;
    static float fill1;
    */

    


    void Start()
    {
        if (ChooseCharacter.gameIsStarted == true)
        {
            characters[ChooseCharacter.current_char].SetActive(true);
            name.text = ChooseCharacter.characterName;
        }

        

    }


    void Update()
    {/*
        if (saving == 1)
        {
            fill = fill1;
            ChooseCharacter.gameIsStarted = true;
            Pause.GameIsStarted_IsStopped = false;
            saving = 0;
        }
        */
        string food = FoodText.ToString();
        string health = HealthText.ToString();
        string mood = MoodText.ToString();
        string energy = EnergyText.ToString();
        /*
        FoodBar.fillAmount = float.Parse(food.Remove(0, food.Length-1));
        HealthBar.fillAmount = float.Parse(health.Remove(0, health.Length - 1));
        MoodBar.fillAmount = float.Parse(mood.Remove(0, mood.Length - 1));
        EnergyBar.fillAmount = float.Parse(energy.Remove(0, energy.Length - 1));
        */
        FoodBar.fillAmount = Player.Satiety.Value*0.01f;
        /*
        if (ChooseCharacter.gameIsStarted == true && fill >= 0 && Pause.GameIsStarted_IsStopped == false && saving == 0)
        {
            //fill -= Time.deltaTime * 0.01f;
            
            /*
            FoodText.text = Mathf.Round(FoodBar.fillAmount * 100f).ToString() + '%';
            HealthText.text = Mathf.Round(HealthBar.fillAmount * 100f).ToString() + '%';
            MoodText.text = Mathf.Round(MoodBar.fillAmount * 100f).ToString() + '%';
            PaintingText.text = Mathf.Round(PaintingBar.fillAmount * 100f).ToString() + '%';*/
        //fill1 = fill;

    }
}
