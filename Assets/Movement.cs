using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float playerSpeed = 8f;

    private Rigidbody myRigidBody;
    private Camera mainCamera;
    public ProjectileFire gun; //Can change this later

    private Vector3 moveInput;
    private Vector3 moveVelocity;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        ///Move
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * playerSpeed;

        //Ray Cast Aim
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

            //Rotate Player towards lookat location, but hold on Y rotation
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if (Input.GetMouseButton(0))
        {
            gun.isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            gun.isFiring = false;
        }
    }

    private void FixedUpdate()
    {
        myRigidBody.velocity = moveVelocity; 
    }
}
