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
    public SceneManagerScript sms;

    public int[] numberOptions;
    public int[] targetNumbers;
    int activeLights = 0;

    public int currentSafeNumber = 0;
    public bool endlessMode = true;
    public int safesCracked = 0;
    
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


        if (activeLights != lightComponent.activeLights)
        {
            activeLights = lightComponent.activeLights;
        }

        CheckForSelection();
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
        if (currentSafeNumber >= targetNumbers.Length && endlessMode)
        {
            currentSafeNumber = 0;
            safesCracked++;
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
        if (endlessMode)
        {
            currentSafeNumber++;
        }
        else
        {
            if (currentSafeNumber < targetNumbers.Length -1)
            {
                currentSafeNumber++;
            }
            else if (currentSafeNumber == targetNumbers.Length -1)
            {
                sms.LoadScene("WinScreen");
            }
        }

    }

    void HandleWrongSelection()
    {
        selectionButtonComponent.ResetSelection();
        AudioSource.PlayOneShot(wrongAnswer);
    }
}
