using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	float speed = 0.04f;
	float zoomSpeed = 10;
	float rotateSpeed = 0.001f;

	float maxHeight = 20;
	float minHhieght = 4;

	Vector2 p1;
	Vector2 p2;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
        if (Input.GetKey(KeyCode.LeftShift)){
			speed = 0.1f;
			zoomSpeed = 20.0f;
        }

		float hms = transform.position.y * speed * Input.GetAxis("Horizontal");
		float vms = transform.position.y * speed * Input.GetAxis("Vertical");
		float scrollSpeed = -zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

		//checking if in the range of heights
		if((transform.position.y >= maxHeight)&&(scrollSpeed > 0))
        {
			scrollSpeed = 0;
        }
		else if((transform.position.y <= minHhieght)&&(scrollSpeed > 0)){
			scrollSpeed = 0;
        }
        if((transform.position.y + scrollSpeed) > maxHeight)
        {
			scrollSpeed = transform.position.y - maxHeight;
        }
		else if ((transform.position.y + scrollSpeed) < minHhieght)
        {
			scrollSpeed = minHhieght + 1;

		}


			Vector3 verticalMove = new Vector3(0, scrollSpeed, 0);
		Vector3 lateralMove = hms * transform.right;
		Vector3 forwardMove = transform.forward;
		forwardMove.y = 0;
		forwardMove.Normalize();
		forwardMove *= vms;

		Vector3 move = verticalMove + lateralMove + forwardMove;
		transform.position += move;

		GetCameraRot();
	}

	void GetCameraRot()
    {
        if (Input.GetMouseButtonDown(2))
        {
			p1 = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
			p2 = Input.mousePosition;

			float dx = (p2 - p1).x * rotateSpeed;
			float dy = (p2 - p1).y * rotateSpeed;

			transform.rotation *= Quaternion.Euler(new Vector3(0, dx, 0));
			transform.GetChild(0).transform.rotation *= Quaternion.Euler(new Vector3(-dy, 0, 0));

        }
    }
}
