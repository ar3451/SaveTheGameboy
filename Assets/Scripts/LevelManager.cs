using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Transform mainMenu, instructionsPage;

    //changes scene when you press the buttons
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void InstructionsPage(bool clicked)
    {
        if (clicked == true)
        {
            instructionsPage.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(false);
        }
        else
        {
            instructionsPage.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(true);
        }
    }
}