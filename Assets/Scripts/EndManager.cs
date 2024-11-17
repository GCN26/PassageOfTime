using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using TMPro;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public TextMeshProUGUI TimeJumps;
    public TextMeshProUGUI Resets;

    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        TimeJumps.text = "Time Jumps: " + TrackJumps.timeJumps;
        Resets.text = "Resets: " + TrackJumps.deathSlashReset;
        TrackJumps.resetTotals();
    }
}
