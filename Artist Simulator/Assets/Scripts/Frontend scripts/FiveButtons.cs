using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveButtons : MonoBehaviour
{
    private bool buttonIsClicked = false;
    public GameObject[] panels;
    public GameObject[] buttons;
    private int current_char = 0;
    private float yKoord = -5;
    public void Click1Button()
    {
        if (buttonIsClicked == false)
        {
            
            buttonIsClicked = true;
            current_char = 0;
            panels[current_char].SetActive(true);
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, buttons[current_char].transform.position.z);
        }
        else
        {
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y - 0.1f, 0);
            panels[current_char].SetActive(false);
            current_char = 0;
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, 0);
        }
        panels[current_char].SetActive(true);
    }

    public void Click2Button()
    {
        if (buttonIsClicked == false)
        {
            
            buttonIsClicked = true;
            current_char = 1;
            panels[current_char].SetActive(true);
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, buttons[current_char].transform.position.z);
        }
        else
        {
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y - 0.1f, 0);
            panels[current_char].SetActive(false);
            current_char = 1;
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, 0);
        }
        panels[current_char].SetActive(true);
    }

    public void Click3Button()
    {
        if (buttonIsClicked == false)
        {

            buttonIsClicked = true;
            current_char = 2;
            panels[current_char].SetActive(true);
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, buttons[current_char].transform.position.z);
        }
        else
        {
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y - 0.1f, 0);
            panels[current_char].SetActive(false);
            current_char = 2;
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, 0);
        }
        panels[current_char].SetActive(true);
    }

    public void Click4Button()
    {
        if (buttonIsClicked == false)
        {
            
            buttonIsClicked = true;
            current_char = 3;
            panels[current_char].SetActive(true);
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, buttons[current_char].transform.position.z);
        }
        else
        {
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y - 0.1f, 0);
            panels[current_char].SetActive(false);
            current_char = 3;
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, 0);
        }
        panels[current_char].SetActive(true);
    }

    public void Click5Button()
    {
        if (buttonIsClicked == false)
        {
            
            buttonIsClicked = true;
            current_char = 4;
            panels[current_char].SetActive(true);
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, buttons[current_char].transform.position.z);
        }
        else
        {
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y - 0.1f, 0);
            panels[current_char].SetActive(false);
            current_char = 4;
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, 0);
        }
        panels[current_char].SetActive(true);
    }

    public void CloseThePanel()
    {
        buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y - 0.1f, 0);
        panels[current_char].SetActive(false);
        current_char = 0;
        buttonIsClicked = false;
    }
}