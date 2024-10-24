using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// WB-CALLBRA01
public class Safe : MonoBehaviour
{
    public GameManager gm;
    public Transform dialSpriteTransform;
    public AudioSource audioSource;
    public AudioClip normalSafeClick;
    public AudioClip safeClick;
    public float audioVolume = 0.4f;

    // Max dial count
    // Current dial count
    public int dialNumberCount = 20;
    public int dialNumber = 0;

    // Spin dial if input is pressed
    // TODO: Add physical dial input and manipulate rotation based on that number
    void Update()
    {
        SpinDial();
        HandleAudio();
    }

    void HandleAudio()
    {
        audioSource.volume = audioVolume;
    }

    void SpinDial()
    {
        // If Input 1, rotate the dial clockwise, if past max value, reset
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (dialNumber + 5 == gm.targetNumbers[gm.currentSafeNumber])
            {
                audioSource.PlayOneShot(safeClick);
            }
            else
            {
                audioSource.PlayOneShot(normalSafeClick);
            }

            if (dialNumber < 100)
            {
                dialSpriteTransform.Rotate(0, 0, -360 / dialNumberCount);
                dialNumber += 5;
            }
            else
            {
                dialSpriteTransform.Rotate(0, 0, -360 / dialNumberCount);
                dialNumber = 5;
            }
        }

        // If Input 2, rotate the dial clockwise, if past max value, reset
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (dialNumber - 5 == gm.targetNumbers[gm.currentSafeNumber])
            {
                audioSource.PlayOneShot(safeClick);
            }
            else
            {
                audioSource.PlayOneShot(normalSafeClick);
            }


            if (dialNumber > 5)
            {
                dialSpriteTransform.Rotate(0, 0, 360 / dialNumberCount);
                dialNumber -= 5;
            }
            else
            {
                dialSpriteTransform.Rotate(0, 0, 360 / dialNumberCount);
                dialNumber = 100;
            }
        }
    }
}