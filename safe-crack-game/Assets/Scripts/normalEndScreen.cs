using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class normalEndScreen : MonoBehaviour
{
    public Image playAgainImage;
    public Image exitImage;

    public Button playAgainButton;
    public Button exitButton;

    public SceneManagerScript sms;

    public AudioSource audioSource;
    public AudioClip clip;

    int currentSelection = 0;

    void Setup()
    {
        audioSource.volume = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        HandleCurrentSelection();
        HandleInput();
    }

    void HandleCurrentSelection()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
        {
            audioSource.PlayOneShot(clip);
        }
        if (currentSelection == 0)
        {
            playAgainImage.enabled = true;
            exitImage.enabled = false;
        }
        else if (currentSelection == 1)
        {
            playAgainImage.enabled = false;
            exitImage.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentSelection == 0)
            {
                sms.LoadScene("modeSelection");
            }
            else if (currentSelection == 1)
            {
                Application.Quit();
            }
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentSelection = 0;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            currentSelection = 1;
        }
    }
}
