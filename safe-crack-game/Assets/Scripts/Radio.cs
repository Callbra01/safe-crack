using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * BASIC RADIO CLASS, HAS BASIC MOVEMENT
 * TODO: ADD PHYSICAL SWITCH INPUT AND MANIPULATE NEEDLE POSITION BASED ON THAT NUMBER
 * TODO: QUANITFY FREQUENCY NEEDLE MOVEMENT TO BETTER SYNC  
 */
public class Radio : MonoBehaviour
{
    public Transform frequencyNeedleTransform;

    float currentFreqValue;
    public float maxFreqValue = 2.5f;
    public float minFreqValue = 0f;
    public float tuneSpeed = 0.15f;

    public float targetFrequency = 1f;

    public AudioSource staticSource;
    public float staticClipMaxVolume = 0.4f;


    void Update()
    {
        HandleInput();
        HandleAudio();
    }

    // TODO: UPDATE INPUT FROM Q AND E TO LINEAR SLIDER
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentFreqValue > minFreqValue)
            {
                frequencyNeedleTransform.Translate(-tuneSpeed, 0, 0);
                currentFreqValue -= tuneSpeed;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentFreqValue < maxFreqValue)
            {
                frequencyNeedleTransform.Translate(tuneSpeed, 0, 0);
                currentFreqValue += tuneSpeed;
            }
        }
    }

    // TODO: ADD SINE WAVE TO AUTOMATICALLY ADJUST TARGET FREQ
    // Changes the target frequency to a given frequency between 0.1f, and 2.5f
    void UpdateTargetFrequency(float newFrequency)
    {
        targetFrequency = newFrequency;
    }

    // TODO: ADD VOCAL TRACK ONE SHOTS AND SET VOLUME TO OPPOSITE OF STATIC VOLUME
    void HandleAudio()
    {
        // Get the difference between current freq and tar freq, adjust volume accordingly
        float freqDifference = Mathf.Abs(currentFreqValue - targetFrequency);
 
        staticSource.volume = (freqDifference * 0.5f);

        // Clamp static volume to a minimum and maximum volume
        if (staticSource.volume > staticClipMaxVolume)
        {
            staticSource.volume = staticClipMaxVolume;
        }
        else if (staticSource.volume < 0.1f)
        {
            staticSource.volume = 0.1f;
        }
    }
}
