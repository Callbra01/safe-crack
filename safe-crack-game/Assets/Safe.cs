using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    [SerializeField]
    public Transform dialSpriteTransform;

    public int dialNumberCount = 20;
    public int dialNumber = 0;
    bool dialMovingRight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpinDial();
        //dialSpriteTransform.Rotate(0, 0, 4);
    }

    void SpinDial()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dialMovingRight = true;
            if (dialNumber < 20 && dialMovingRight)
            {
                dialSpriteTransform.Rotate(0, 0, -360 / dialNumberCount);
                dialNumber++;
            }
            else
            {
                dialSpriteTransform.Rotate(0, 0, -360 / dialNumberCount);
                dialNumber = 1;
            }
        }

    }
}
