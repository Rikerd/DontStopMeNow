using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float movementSpeed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (transform.childCount != 0)
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }
    }
}
