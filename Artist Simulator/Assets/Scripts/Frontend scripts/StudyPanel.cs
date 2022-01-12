using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyPanel : MonoBehaviour
{
    public GameObject[] studyScrolls;
    private int currentPanel = 0;
    public GameObject button_BackToScroll;
    private string variant;
    public void button_PracticeDrawing()
    {
        studyScrolls[0].SetActive(false);
        studyScrolls[1].SetActive(true);
        button_BackToScroll.SetActive(true);
        currentPanel = 1;
        variant = "freeDrawing";
    }

    public void button_DrawYouTube()
    {
        studyScrolls[0].SetActive(false);
        studyScrolls[2].SetActive(true);
        button_BackToScroll.SetActive(true);
        currentPanel = 2;
        variant = "watchingYoutube";
    }

    public void button_DrawingCourse()
    {
        studyScrolls[0].SetActive(false);
        studyScrolls[3].SetActive(true);
        button_BackToScroll.SetActive(true);
        currentPanel = 3;
        variant = "expressCourse";
    }

    public void button_BackToMainScroll()
    {
        studyScrolls[0].SetActive(true);
        studyScrolls[currentPanel].SetActive(false);
        currentPanel = 0;
        button_BackToScroll.SetActive(false);
    }

    public void all_buttons(GameObject learnButton)
    {
        Actions.LearnTechnique(learnButton.name  + " " + variant);
    }
}
