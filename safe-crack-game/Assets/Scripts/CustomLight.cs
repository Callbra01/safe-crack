using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLight : MonoBehaviour
{
    public int numberOfLights = 3;
    public GameObject[] lightOnSprites;
    public int activeLights = 0;

    // Update is called once per frame
    void Update()
    {
        HandleInput();

        if (activeLights == 0)
        {
            DeactivateLight(lightOnSprites[0]);
            DeactivateLight(lightOnSprites[1]);
            DeactivateLight(lightOnSprites[2]);
        }

        if (activeLights == 1)
        {
            ActivateLight(lightOnSprites[0]);
            DeactivateLight(lightOnSprites[1]);
            DeactivateLight(lightOnSprites[2]);
        }

        if (activeLights == 2)
        {
            ActivateLight(lightOnSprites[0]);
            ActivateLight(lightOnSprites[1]);
            DeactivateLight(lightOnSprites[2]);
        }

        if (activeLights == 3)
        {
            ActivateLight(lightOnSprites[2]);
        }

        // MIGHT HAVE TO REMOVE
        if (activeLights > numberOfLights)
        {
            activeLights = numberOfLights;
        }
    }

    // TODO: CHANGE
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (activeLights < numberOfLights)
            {
                activeLights++;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (activeLights > 0)
            {
                activeLights--;
            }
        }
    }

    void ActivateLight(GameObject light)
    {
        SpriteRenderer lightSprite = light.GetComponent<SpriteRenderer>();
        Color color = lightSprite.color;
        color.a = 1f;
        lightSprite.color = color;
    }

    void DeactivateLight(GameObject light)
    {
        SpriteRenderer lightSprite = light.GetComponent<SpriteRenderer>();
        Color color = lightSprite.color;
        color.a = 0f;
        lightSprite.color = color;
    }
}
