using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public GameObject a_gameObject;

	// Use this for initialization
	void Start () 
	{	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.P))
		{
			a_gameObject.SetActive (false);
			Debug.Log ("destroyed");
		}

		if (Input.GetKey (KeyCode.L)) 
		{
			a_gameObject.SetActive (true);
			//Instantiate (a_gameObject, new Vector3 (-5f, 0.5f, 11f), Quaternion.identity);
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Translate (Vector3.right * 10 * Time.deltaTime);
		}

		else if (Input.GetKey(KeyCode.A))
		{
			transform.Translate (Vector3.left * 10 * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.W)) 
		{
			transform.Translate (Vector3.forward * 10 * Time.deltaTime);
		}

		else if (Input.GetKey(KeyCode.S))
		{
			transform.Translate (Vector3.back * 10 * Time.deltaTime);
		}
	
	}
}
