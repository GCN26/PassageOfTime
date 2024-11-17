using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void buttonPlay()
    {
        SceneManager.LoadScene("Game");
    }
    public void quitButton()
    {
        Application.Quit();
    }
}
