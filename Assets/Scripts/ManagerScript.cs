using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public int currentEra = 0;
    public bool eraChange = false;
    public float timer = 0;
    public bool paused = false;
    public GameObject pausePanel;

    private void Start()
    {
        pausePanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (eraChange)
        {
            timer += Time.deltaTime;
            if(timer > .1) eraChange = false;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        if (paused)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
