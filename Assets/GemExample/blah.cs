using UnityEngine;
using System.Collections;

public class blah : MonoBehaviour {
	public float speed =5;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		float horiz = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float verti = Input.GetAxis("Vertical") * speed * Time.deltaTime;

		Vector3 pos = new Vector3 (horiz , 0 , verti);
		transform.Translate (pos);
	
	}
}
