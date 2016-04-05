using UnityEngine;
using System.Collections;

public class rotationForMenu : MonoBehaviour {

	float speed = 10f;




	// Update is called once per frame
	void Update () {

		transform.Rotate(Vector3.up *speed *Time.deltaTime);



	
	}
}
