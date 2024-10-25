using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceLights : MonoBehaviour
{
    //public Image redImage;
    //public Image blueImage;

    public Transform redTransform;
    public Transform blueTransform;

    Vector3 oldTransformRed = new Vector3();
    Vector3 oldTransformBlue = new Vector3();

    public float scalar = 10f;

    void Setup()
    {
        oldTransformRed = redTransform.position;
        oldTransformBlue = blueTransform.position;
    }
    // Update is called once per frame
    void Update()
    {
        moveLights();
    }


    void moveLights()
    {

        redTransform.Translate(oldTransformRed.x + Mathf.Sin(Time.time) * Time.deltaTime * scalar, oldTransformRed.y, 0);
        blueTransform.Translate(oldTransformBlue.x + Mathf.Sin(Time.time) * Time.deltaTime * scalar, oldTransformBlue.y, 0);
        
    }
}
