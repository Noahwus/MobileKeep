using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour {

    public GameObject target;
    public Vector3 offset;
    public float lerpSpeed = .125f;

    public bool lookAt = true;

	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, lerpSpeed);

        transform.position = smoothPosition;

        if (lookAt)
        {
            transform.LookAt(target.transform.position);
        }
	}
}
