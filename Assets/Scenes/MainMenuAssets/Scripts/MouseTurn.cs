using UnityEngine;
using System.Collections;

public class MouseTurn : MonoBehaviour {

	public float lookSensitivity = 5f;
	public float xRotation;
	public float yRotation;
	public float currentXRotation;
	public float currentYRotation;
	public float xRotationV;
	public float yRotationV;
	public float lookSmoothDamp = 0.1f;

	// Use this for initialization
	void Start () {
	



	}
	
	// Update is called once per frame
	void Update () {
	
		xRotation -= Input.GetAxis ("Mouse Y") * lookSensitivity;
		yRotation += Input.GetAxis ("Mouse X") * lookSensitivity;

		xRotation = Mathf.Clamp (xRotation, -20, 20);
		yRotation = Mathf.Clamp (yRotation, -45, 45);

		//currentXRotation = Mathf.SmoothDamp (currentXRotation, currentXRotation, ref xRotationV, lookSmoothDamp);
		//currentYRotation = Mathf.SmoothDamp (currentYRotation, currentYRotation, ref yRotationV, lookSmoothDamp);

		transform.rotation = Quaternion.Euler (xRotation, yRotation, 0);
	}
}
