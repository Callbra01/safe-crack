using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuSelection : MonoBehaviour
{

    public Image startButtonImage;
    public Image exitButtonImage;

    public Button startButton;
    public Button exitButton;

    public SceneManagerScript customSceneManager;

    public AudioSource audioSource;
    public AudioClip clip;

    int currentSelection = 0;

    void Setup()
    {
        //startImage = startButton.GetComponent<Image>();
        audioSource.volume = 0.4f;
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
            startButtonImage.enabled = true;
            exitButtonImage.enabled = false;
        }
        else if (currentSelection == 1)
        {
            startButtonImage.enabled = false;
            exitButtonImage.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentSelection == 0)
            {
                customSceneManager.LoadScene("Game");
            }
            else if (currentSelection == 1)
            {
                Application.Quit();
            }
        }
    }

    void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            currentSelection = 0;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            currentSelection = 1;
        }
    }
}
