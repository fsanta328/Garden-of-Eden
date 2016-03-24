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
		m_player = GameObject.FindGameObjectWithTag ("Player");

		m_distance = m_player.transform.position - transform.position;

		transform.rotation = Quaternion.LookRotation (m_distance);

		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);

		SetRigidbody().useGravity = false;
	}

	void Update()
	{
		SetRigidbody ().useGravity = true;

		transform.Translate(Vector3.forward * (m_speed * Time.deltaTime));

		Invoke ("Destroy", 2.0f);
	}

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