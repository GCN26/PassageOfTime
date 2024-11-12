using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void buttonPlay()
    {
        SceneManager.LoadScene("Game");
    }
    public void quitButton()
    {
        Application.Quit();
    }
}
