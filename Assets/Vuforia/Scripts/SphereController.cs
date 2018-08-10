using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {

    public float speed;
    public GameObject cube;
    private Rigidbody rb;
    private float distanceToTheBorder;
    private bool goToTheRight;

	// Use this for initialization
	void Start () {
        goToTheRight = true;
        rb = GetComponent<Rigidbody>();
        RectTransform rt = cube.GetComponent<RectTransform>();
        distanceToTheBorder = (rt.localScale.x * rt.sizeDelta.x) / 2;
	}
	
	void FixedUpdate () {
		if (goToTheRight)
        {
            Vector3 movement = new Vector3(distanceToTheBorder, 0.0f, 0.0f);
            rb.AddForce(movement * speed);

            if (IsInRightBorder()) goToTheRight = false;
        }
        else
        {
            Vector3 movement = new Vector3(-distanceToTheBorder, 0.0f, 0.0f);
            rb.AddForce(movement * speed);

            if (IsInLeftBorder()) goToTheRight = true;
        }
	}

    private bool IsInRightBorder ()
    {
        return transform.position.x == distanceToTheBorder;
    }

    private bool IsInLeftBorder ()
    {
        return transform.position.x == - distanceToTheBorder;
    }
}
