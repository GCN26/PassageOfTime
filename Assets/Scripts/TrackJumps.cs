using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrackJumps
{
    public static int deathSlashReset;
    public static int timeJumps;
    //make this persistent through resets

    public static void resetTotals()
    {
        deathSlashReset = 0;
        timeJumps = 0;
    }
}
