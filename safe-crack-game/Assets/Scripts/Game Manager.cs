using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip correctAnswer;
    public AudioClip closeAnswer;
    public AudioClip wrongAnswer;
    public AudioClip[] voiceClips;

    public GameObject lightObject;
    public GameObject safeObject;
    public GameObject selectionButtonObject;

    CustomLight lightComponent;
    Safe safeComponent;
    SelectionButton selectionButtonComponent;
    CustomTimer timerComponent;
    DEBUGMENU DEBUGMENUVAR;

    public int[] numberOptions;
    public int[] targetNumbers;
    int activeLights = 0;

    int currentSafeNumber = 0;
    
    void Start()
    {
        UpdateTargetNumbers();
        lightComponent = lightObject.GetComponent<CustomLight>();
        safeComponent = safeObject.GetComponent<Safe>();
        selectionButtonComponent = selectionButtonObject.GetComponent<SelectionButton>();
        timerComponent = GetComponent<CustomTimer>();
        DEBUGMENUVAR = GetComponent<DEBUGMENU>();

        AudioSource.volume = 0.4f;
    }

    void Update()
    {

        DEBUGMENUVAR.currKnobPos = safeComponent.dialNumber;
        DEBUGMENUVAR.currentTargetPos = targetNumbers;
        DEBUGMENUVAR.timeRemaining = timerComponent.targetTime;
        DEBUGMENUVAR.currLights = activeLights;


        if (Input.GetKeyDown(KeyCode.Z))
        {
            UpdateTargetNumbers();
        }

        if (activeLights != lightComponent.activeLights)
        {
            activeLights = lightComponent.activeLights;
        }

        CheckForSelection();

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
        {
            if (safeComponent.dialNumber == targetNumbers[currentSafeNumber])
            {
                safeComponent.audioSource.PlayOneShot(safeComponent.safeClick);
            }
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

    void CheckForSelection()
    {
        // If current safe number is as large as targetNumbers.length, all correct inputs have been done
        if (currentSafeNumber >= targetNumbers.Length)
        {
            currentSafeNumber = 0;
            UpdateTargetNumbers();
            lightComponent.activeLights = 0;
        }

        
        if (selectionButtonComponent.playerSelected == true)
        {
            if (safeComponent.dialNumber == targetNumbers[currentSafeNumber])
            {
                HandleCorrectSelection();

            }
            else if (safeComponent.dialNumber != targetNumbers[currentSafeNumber])
            {
                HandleWrongSelection();
            }
        }
    }

    void HandleCorrectSelection()
    {
        lightComponent.activeLights += 1;
        selectionButtonComponent.ResetSelection();
        AudioSource.PlayOneShot(correctAnswer);
        currentSafeNumber++;
    }

    void HandleWrongSelection()
    {
        selectionButtonComponent.ResetSelection();
        AudioSource.PlayOneShot(wrongAnswer);
    }

    void SelectVoiceClips()
    {

    }
}
