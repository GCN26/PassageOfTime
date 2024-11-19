using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public float startTimer;
    public bool started = false;
    public bool started2 = false;
    public GameObject startFlash;
    public GameObject controls;
    public GameObject credits;

    public void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void buttonPlay()
    {
        if (!started && !started2)
        {
            started = true;
        }
    }
    public void buttonPlay2()
    {
        if (!started && !started2)
        {
            started2 = true;
        }
    }
    public void quitButton()
    {
        Application.Quit();
    }
    public void Update()
    {
        if(started)
        {
            startTimer += Time.deltaTime;
            startFlash.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, startTimer);
            if(startTimer > 1.5) { SceneManager.LoadScene("Game"); }
        }
        if (started2)
        {
            startTimer += Time.deltaTime;
            startFlash.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, startTimer);
            if (startTimer > 1.5) { SceneManager.LoadScene("Level2"); }
        }
    }
    public void controlsButton()
    {
        credits.SetActive(false);
        if (controls.activeSelf == false)
        {
            controls.SetActive(true);
        }
        else
        {
            controls.SetActive(false);
        }
    }
    public void creditsButton() {
        controls.SetActive(false);
        if (credits.activeSelf == false)
        {
            credits.SetActive(true);
        }
        else
        {
            credits.SetActive(false);
        }
    }
    public void levelSelect()
    {
        //copy control and credits panel code
    }
}
