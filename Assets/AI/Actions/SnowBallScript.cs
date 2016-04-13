using UnityEngine;
using System.Collections;

public class SnowBallScript : MonoBehaviour 
{
	private GameObject m_player;
	private Vector3 m_distance;
	public float m_speed;
	
	public Rigidbody SetRigidbody()
	{
		return	GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () 
	{
		//locate player
		m_player = GameObject.Find ("Berserker");

		//get distance between the player postion and this game object
		m_distance = m_player.transform.position - transform.position;

		//rotate this object towards players location
		transform.rotation = Quaternion.LookRotation (m_distance);

		//make sure it only rotates y-axis
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);

		//set the gravity of this object to false
		SetRigidbody().useGravity = false;
	}

	void Update()
	{
		//set the gravity of this object to true
		SetRigidbody ().useGravity = true;

		//make this gameobject move forward
		transform.Translate(Vector3.forward * (m_speed * Time.deltaTime));

		//destory after certain time period 
		Invoke ("Destroy", 2.0f);
	}

	//if collide destroy this gameobject
	void OnCollisionEnter(Collision a_collision)
	{
		if(a_collision.gameObject.tag == "Player")
		{
			Destroy ();
		}
	}

	void Destroy()
	{
		Destroy (this.gameObject);
	}
}