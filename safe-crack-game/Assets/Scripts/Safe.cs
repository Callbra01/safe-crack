using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// WB-CALLBRA01
public class Safe : MonoBehaviour
{
    public Transform dialSpriteTransform;

    // Max dial count
    // Current dial count
    public int dialNumberCount = 20;
    public int dialNumber = 0;

    // Spin dial if input is pressed
    // TODO: Add physical dial input and manipulate rotation based on that number
    void Update()
    {
        SpinDial();
    }

    void SpinDial()
    {
        // If Input 1, rotate the dial clockwise, if past max value, reset
        if (Input.GetMouseButtonDown(0))
        {
            if (dialNumber < dialNumberCount)
            {
                dialSpriteTransform.Rotate(0, 0, -360 / dialNumberCount);
                dialNumber++;
            }
            else
            {
                dialSpriteTransform.Rotate(0, 0, -360 / dialNumberCount);
                dialNumber = 1;
            }
        }

        // If Input 2, rotate the dial clockwise, if past max value, reset
        if (Input.GetMouseButtonDown(1))
        {
            if (dialNumber > 1)
            {
                dialSpriteTransform.Rotate(0, 0, 360 / dialNumberCount);
                dialNumber--;
            }
            else
            {
                dialSpriteTransform.Rotate(0, 0, 360 / dialNumberCount);
                dialNumber = dialNumberCount;
            }
        }
    }
}