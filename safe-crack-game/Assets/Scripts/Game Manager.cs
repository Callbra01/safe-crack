using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public AudioClip[] voiceClips;
    public GameObject lightObject;
    CustomLight lightComponent;
    public int[] numberOptions;
    public int[] targetNumbers;
    int activeLights = 0;
    
    void Start()
    {
        UpdateTargetNumbers();
        lightComponent = lightObject.GetComponent<CustomLight>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            UpdateTargetNumbers();
        }

        if (activeLights != lightComponent.activeLights)
        {
            activeLights = lightComponent.activeLights;
        }
    }

    void UpdateTargetNumbers()
    {
        List<int> currentNumbers = new List<int>();
        do
        {
            int number = Random.Range(0, numberOptions.Length);
            if (!currentNumbers.Contains(number))
            {
                currentNumbers.Add(number);
            }

        } while (currentNumbers.Count < targetNumbers.Length);

        for (int num = 0; num < targetNumbers.Length; num++)
        {
            targetNumbers[num] = numberOptions[currentNumbers[num]];
        }
    }

    void SelectVoiceClips()
    {

    }
}
