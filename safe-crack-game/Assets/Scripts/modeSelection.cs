using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelection : MonoBehaviour
{

    public Image normalButtonImage;
    public Image endlessButtonImage;

    public Button normalButton;
    public Button endlessButton;

    public SceneManagerScript customSceneManager;

    public AudioSource audioSource;
    public AudioClip clip;

    int currentSelection = 0;

    void Setup()
    {
        //normalImage = normalButton.GetComponent<Image>();
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
            normalButtonImage.enabled = true;
            endlessButtonImage.enabled = false;
        }
        else if (currentSelection == 1)
        {
            normalButtonImage.enabled = false;
            endlessButtonImage.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentSelection == 0)
            {
                customSceneManager.LoadScene("Game");
            }
            else if (currentSelection == 1)
            {
                customSceneManager.LoadScene("GameEndless");
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
