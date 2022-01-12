using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorOfButtons : MonoBehaviour
{
    public Button[] permJob;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkLevel();
    }

    public void buttonsInWork0(Button button)
    {
        if (Game.ContractsPool[0].IsTaken == true)
        {
            button.gameObject.GetComponent<Image>().color = Color.grey;
            button.GetComponent<Button>().interactable = false;
            Debug.Log("works");
        }
        else
        {
            button.gameObject.GetComponent<Image>().color = Color.white;
            button.GetComponent<Button>().interactable = true;
        }
    }
    public void buttonsInWork1(Button button)
    {
        if (Game.ContractsPool[1].IsTaken == true)
        {
            button.gameObject.GetComponent<Image>().color = Color.grey;
            button.GetComponent<Button>().interactable = false;
            Debug.Log("works");
        }
        else
        {
            button.gameObject.GetComponent<Image>().color = Color.white;
            button.GetComponent<Button>().interactable = true;
        }
    }
    public void buttonsInWork2(Button button)
    {
        if (Game.ContractsPool[2].IsTaken == true)
        {
            button.gameObject.GetComponent<Image>().color = Color.grey;
            button.GetComponent<Button>().interactable = false;
            Debug.Log("works");
        }
        else
        {
            button.gameObject.GetComponent<Image>().color = Color.white;
            button.GetComponent<Button>().interactable = true;
        }
    }
    public void buttonsInWork3(Button button)
    {
        if (Game.ContractsPool[3].IsTaken == true)
        {
            button.gameObject.GetComponent<Image>().color = Color.grey;
            button.GetComponent<Button>().interactable = false;
            Debug.Log("works");
        }
        else
        {
            button.gameObject.GetComponent<Image>().color = Color.white;
            button.GetComponent<Button>().interactable = true;
        }
    }

    public void checkLevel()
    {
        int num = 0; ;
        for (int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case 0:
                    num = 15;
                    break;
                case 1:
                    num = 25;
                    break;
                case 2:
                    num = 20;
                    break;
                case 3:
                    num = 25;
                    break;
                case 4:
                   
                    num = 10;
                    break;
            }

            if (Player.ArtSkills.GetMinSkillLvl() >= num)
            {
                permJob[i].GetComponent<Button>().interactable = true;
                permJob[i].gameObject.GetComponent<Image>().color = Color.white;
            }
            else
            {
                permJob[i].GetComponent<Button>().interactable = false;
                permJob[i].gameObject.GetComponent<Image>().color = Color.grey;
            }
        }
            

    }

}
