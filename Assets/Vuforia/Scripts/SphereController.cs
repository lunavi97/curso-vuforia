using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float horizontalAcceleration;
    public GameObject ground;
    private Rigidbody rb;
    private float distanceToTheBorder;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RectTransform rt = ground.GetComponent<RectTransform>();
        distanceToTheBorder = (rt.localScale.x * rt.sizeDelta.x) / 2;
        rb.AddForce(horizontalAcceleration, 0, 0);
    }

    private void FixedUpdate()
    {
        if (IsInRightBorder())
        {
            rb.AddForce(-horizontalAcceleration * 2, 0, 0);
        }

        else if (IsInLeftBorder())
        {
            rb.AddForce(horizontalAcceleration * 2, 0, 0);
        }
    }

    private bool IsInRightBorder()
    {
        return rb.transform.position.x >= distanceToTheBorder;
    }

    private bool IsInLeftBorder()
    {
        return rb.transform.position.x <= -distanceToTheBorder;
    }
}
