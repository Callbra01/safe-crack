using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUGMENU : MonoBehaviour
{
    public GUIStyle myStyle = new GUIStyle();
    public int currKnobPos;
    public int[] currentTargetPos = {0, 0, 0};
    public int currLights;
    public float timeRemaining;
    string returnString = string.Empty;
    public bool isEndless = false;
    public GameManager gm;
    public bool isScoreScreen = false;
    public float timeDone = 0f;

    public void OnGUI()
    {
        myStyle.fontSize = 30;
        GUI.color = Color.white;
        /*
        GUI.Label(new Rect(800, 10, 260, 700), "DEBUG MENU", myStyle);

        GUI.Label(new Rect(800, 50, 260, 700), $"CURR. KNOB POS: {currKnobPos}", myStyle);

        GUI.Label(new Rect(800, 100, 260, 700), $"TAR. POS': {currentTargetPos[0]}, {currentTargetPos[1]}, {currentTargetPos[2]}", myStyle);

        GUI.Label(new Rect(800, 150, 260, 700), $"CURR. LIGHTS: {currLights}", myStyle);

        GUI.Label(new Rect(800, 200, 260, 700), $"TIME REMAIN:: {timeRemaining}", myStyle);
        */

        if (isScoreScreen == false)
        {
            myStyle.fontSize = 30;
            GUI.Label(new Rect(800, 10, 260, 700), $"TIME LEFT: {TimeSpan.FromSeconds(Mathf.Floor(timeRemaining))}", myStyle);

            if (isEndless)
            {
                myStyle.fontSize = 30;
                GUI.Label(new Rect(800, 40, 260, 700), $"CRACKED SAFES: {gm.safesCracked}", myStyle);
            }
        }
        else
        {
            myStyle.fontSize = 60;
            int playerScore = PlayerPrefs.GetInt("safesCracked");

            if (playerScore == 1)
            {
                GUI.Label(new Rect(250, 120, 260, 260), $"YOU CRACKED {playerScore} SAFE!!", myStyle);
            }
            else
            {
                GUI.Label(new Rect(250, 120, 260, 260), $"YOU CRACKED {playerScore} SAFES!!", myStyle);
            }
            
        }
    }
}
