using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorOfButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buttonsInWork0(Button button)
    {
        if (Game.ContractsPool[0].IsTaken == true)
        {
            button.gameObject.GetComponent<Image>().color = Color.grey;
            button.GetComponent<Button>().interactable = false;
            Debug.Log("works");
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
    }
    public void buttonsInWork2(Button button)
    {
        if (Game.ContractsPool[2].IsTaken == true)
        {
            button.gameObject.GetComponent<Image>().color = Color.grey;
            button.GetComponent<Button>().interactable = false;
            Debug.Log("works");
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
    }
}
