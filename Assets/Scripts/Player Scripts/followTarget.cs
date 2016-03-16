using UnityEngine;
using System.Collections;

public  class followTarget : MonoBehaviour 
{
	public Transform lookAt;
	private Transform camTransform;

	private float distance = 1.5f;
	private float currentX = 0.01f;

	public float zoom = 5f;

	void Start()
	{
		camTransform = transform;
	}

	void Update()
	{
		currentX += Input.GetAxis("Mouse X");
	}

	private void LateUpdate()
	{
		// rotate the camera
		Vector3 dir = new Vector3 (2,1.5f, -distance);
		Quaternion rotation = Quaternion.Euler(0 , -currentX , 0);
		camTransform.position = lookAt.position + rotation * dir;

		// Let camera lookat player
		camTransform.LookAt(lookAt.position);
	}
}