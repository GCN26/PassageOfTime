using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    public TextMeshProUGUI TimeJumps;
    public TextMeshProUGUI Resets;
    public TextMeshProUGUI TimeJumpsDS;
    public TextMeshProUGUI ResetsDS;

    public GameObject mmbutton,rbutton;
    public TextMeshProUGUI mmbuttontext,rbuttontext;

    public float alpha = -2;

    public Image rankImage;
    public Sprite srank, arank, brank, crank, drank, splusrank;
    public TextMeshProUGUI Rank, RankDS;

    public float mmtimer = 0;
    public bool gotoMenu = false;
    public bool gotoLast = false;

    public GameObject finalFlash;
    public bool rainbow = false;

    public float redF = 255;
    public float greenF = 0;
    public float blueF = 0;

    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        TimeJumps.text = "Time Jumps: " + TrackJumps.timeJumps;
        Resets.text = "Resets: " + TrackJumps.deathSlashReset;
        TimeJumpsDS.text = "Time Jumps: " + TrackJumps.timeJumps;
        ResetsDS.text = "Resets: " + TrackJumps.deathSlashReset;

        if (TrackJumps.deathSlashReset == 0 && TrackJumps.timeJumps < 3)
        {
            rankImage.GetComponent<Image>().overrideSprite = splusrank;
            rainbow = true;
        }
        else if (TrackJumps.deathSlashReset == 0) rankImage.GetComponent<Image>().overrideSprite = srank;
        else if (TrackJumps.deathSlashReset == 1) rankImage.GetComponent<Image>().overrideSprite = arank;
        else if (TrackJumps.deathSlashReset == 2) rankImage.GetComponent<Image>().overrideSprite = brank;
        else if (TrackJumps.deathSlashReset == 3) rankImage.GetComponent<Image>().overrideSprite = crank;
        else if (TrackJumps.deathSlashReset >= 4) rankImage.GetComponent<Image>().overrideSprite = drank;

        

        TrackJumps.resetTotals();
    }
    private void Update()
    {
        if(gotoMenu == false && gotoLast == false) { alpha += Time.deltaTime; }
        if(alpha > 1) { alpha = 1; }

        TimeJumps.color = new Color(1, 1, 1, alpha);
        TimeJumpsDS.color = new Color(0, 0, 0, alpha);
        Resets.color = new Color(1, 1, 1, alpha);
        ResetsDS.color = new Color(0, 0, 0, alpha);
        mmbutton.GetComponent<Image>().color = new Color(1, 1, 1, alpha);
        mmbuttontext.color = new Color(0, 0, 0, alpha);
        rbutton.GetComponent<Image>().color = new Color(1, 1, 1, alpha);
        rbuttontext.color = new Color(0, 0, 0, alpha);
        if (rainbow == false) rankImage.color = new Color(1, 1, 1, alpha);
        Rank.color = new Color(1, 1, 1, alpha);
        RankDS.color = new Color(0, 0, 0, alpha);

        if(gotoMenu == true)
        {
            alpha -= Time.deltaTime;
            mmtimer += Time.deltaTime;
            finalFlash.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, mmtimer-.65f);
            if (mmtimer > 1.75f)
            {
                TrackJumps.resetTotals();
                SceneManager.LoadScene("MainMenu");
            }
        }
        if (gotoLast == true)
        {
            alpha -= Time.deltaTime;
            mmtimer += Time.deltaTime;
            finalFlash.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, mmtimer - .65f);
            if (mmtimer > 1.75f)
            {
                TrackJumps.resetTotals();
                SceneManager.LoadScene(TrackJumps.lastRoom);
            }
        }

        if (rainbow == true)
        {
            if (blueF == 0 && greenF != 255) greenF += Time.deltaTime*255;
            if (greenF == 255 && redF != 0) redF -= Time.deltaTime * 255;
            if (redF == 0 && blueF != 255) blueF += Time.deltaTime * 255;
            if(blueF == 255 && greenF != 0) greenF -= Time.deltaTime * 255;
            if (greenF == 0 && redF != 255) redF += Time.deltaTime * 255;
            if(redF == 255 && blueF != 0) blueF -= Time.deltaTime * 255;
            if (greenF > 255) greenF = 255;
            if (redF > 255) redF = 255;
            if (blueF > 255) blueF = 255;
            if(greenF < 0) greenF = 0;
            if (redF < 0) redF = 0;
            if (blueF < 0) blueF = 0;
            rankImage.GetComponent<Image>().color = new Color(redF / 255, blueF / 255, greenF / 255,alpha);
        }
    }

    public void mainMenu()
    {
        if(gotoMenu != true)
        {
            gotoMenu = true;
        }
        
    }
    public void restartLevel()
    {
        if(gotoLast != true)
        {
            gotoLast = true;
        }
    }
}
