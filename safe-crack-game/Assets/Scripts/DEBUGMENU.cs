using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUGMENU : MonoBehaviour
{
    GUIStyle myStyle = new GUIStyle();
    public int currKnobPos;
    public int[] currentTargetPos = {0, 0, 0};
    public int currLights;
    public float timeRemaining;

    public void OnGUI()
    {
        myStyle.fontSize = 50;
        GUI.color = Color.white;
        GUI.Label(new Rect(800, 10, 260, 700), "DEBUG MENU", myStyle);

        GUI.Label(new Rect(800, 50, 260, 700), $"CURR. KNOB POS: {currKnobPos}", myStyle);

        GUI.Label(new Rect(800, 100, 260, 700), $"TAR. POS': {currentTargetPos[0]}, {currentTargetPos[1]}, {currentTargetPos[2]}", myStyle);

        GUI.Label(new Rect(800, 150, 260, 700), $"CURR. LIGHTS: {currLights}", myStyle);

        GUI.Label(new Rect(800, 200, 260, 700), $"TIME REMAIN:: {timeRemaining}", myStyle);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
