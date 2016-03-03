using UnityEngine;
using System.Collections;

public  class followTarget : MonoBehaviour 
{
	private const float Y_Angle_MIN = -50f;
	private const float Y_Angle_MAX = 0f;

	public Transform lookAt;
	private Transform camTransform;

	private Camera cam;

	private float distance = 1.5f;
	private float currentX = 0.01f;
	private float currentY = 0.01f;

	public float zoom = 5f;

	Rigidbody rigibody;


	void Start()
	{
		camTransform = transform;
		cam = Camera.main;
	}

	void Update()
	{
		currentX += Input.GetAxis("Mouse X");
		currentY += Input.GetAxis("Mouse Y");

		// Restrict the mouse rotation movement.
		currentY = Mathf.Clamp(currentY, Y_Angle_MIN , Y_Angle_MAX);
	}

	private void LateUpdate()
	{
		// rotate the camera
		Vector3 dir = new Vector3 (0,2.5f, -distance);
		Quaternion rotation = Quaternion.Euler(currentY , -currentX , 0);
		camTransform.position = lookAt.position + rotation * dir;

		// Let camera lookat player
		camTransform.LookAt(lookAt.position);
	}

	void OnCollisionEnter(Collision obj)
	{
		Debug.Log("Rr");
		currentX = 0;
		currentY = 0;

		rigibody.velocity = Vector3.zero; 
	}

}
