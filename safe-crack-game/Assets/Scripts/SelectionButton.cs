using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionButton : MonoBehaviour
{

    public bool playerSelected;
    public Transform buttonTransform;

    // Update is called once per frame
    void Update()
    {
        HandleSelection();

    }

    void HandleSelection()
    {
        if (Input.GetKeyDown(KeyCode.W) && playerSelected == false)
        {
            playerSelected = true;
            buttonTransform.Translate(-0.13f, 0, 0);
        }
    }

    public void ResetSelection()
    {
        playerSelected = false;
        buttonTransform.Translate(0.13f, 0, 0);
    }
}
