using UnityEngine;
using System.Collections;

public  class followTarget : MonoBehaviour 
{
	public Transform m_lookAt;
	private Transform m_camTransform;

	private float m_distance = 4.0f;
	private float m_currentX = 0.01f;
	private float m_height = 3.0f;

	void Start()
	{
		m_camTransform = transform;
	}

	void Update()
	{
		m_currentX += Input.GetAxis("Mouse X");
	}

	private void LateUpdate()
	{
		// rotate the camera
		Vector3 dir = new Vector3 (2, m_height, -m_distance);
		Quaternion rotation = Quaternion.Euler(0 , -m_currentX , 0);
		m_camTransform.position = m_lookAt.position + rotation * dir;

		// Let camera lookat player
		m_camTransform.LookAt(m_lookAt.position);
	}
}