using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	
	// a public variable allowing the user to change the speed option within unity.
	public float speed = 10f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// Using the horizontal "A-D, or left and right keys" will allow the player to move left and right with a certain speed
		float h = Input.GetAxis("Horizontal")* speed * Time.deltaTime;
		// Using the vertical "W and S, or up and down keys" will allow the player to move up and down with a certain speed.
		float v = Input.GetAxis("Vertical")* speed * Time.deltaTime;
		
		// Every frame the new position will be called decided by the change in horizontal and vertical movement the Y axis is set to 0 in order to keep the player from moving up and down on the Y axis. 
		Vector3 newPos = new Vector3 (h, 0, v); 
		
		
		// allows the player to move to the new position every frame. 
		transform.Translate (newPos); 
		
	}
}
