using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * BASIC RADIO CLASS, HAS BASIC MOVEMENT
 * TODO: ADD PHYSICAL SWITCH INPUT AND MANIPULATE NEEDLE POSITION BASED ON THAT NUMBER
 * */
public class Radio : MonoBehaviour
{
    public Transform frequencyNeedleTransform;

    float currentValue;
    public float maxFreqValue = 2.5f;
    public float minFreqValue = 0f;
    public float tuneSpeed = 0.15f;


    void Setup()
    {
        currentValue = frequencyNeedleTransform.position.x;
    }


    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentValue > minFreqValue)
            {
                frequencyNeedleTransform.Translate(-tuneSpeed, 0, 0);
                currentValue -= tuneSpeed;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentValue < maxFreqValue)
            {
                frequencyNeedleTransform.Translate(tuneSpeed, 0, 0);
                currentValue += tuneSpeed;
            }
        }
    }
}
