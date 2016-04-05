using UnityEngine;
using System.Collections;

public class rotationForMenu : MonoBehaviour
{

	float speed = 10f;

	void Start()
	{
		Player.m_weaponEquipped = 0;
	}


	// Update is called once per frame
	void Update () {

		transform.Rotate(Vector3.up *speed *Time.deltaTime);



	
	}
}
