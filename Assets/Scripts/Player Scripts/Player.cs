using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
	public GameObject m_cam,m_weapon, m_aura;
	public float m_speed;
	private Animator m_animator;
	private float timer;
	private Vector3 jumpVelocity = new  Vector3(0, 4.50f, 0);
	bool m_actionMovement;

	PlayerBehaviour m_playerBehaviour;

	// Use this for initialization
	void Start () 
	{
		timer = 0;
		m_actionMovement = false;
		m_animator = GetComponent<Animator> ();
		m_playerBehaviour = new PlayerBehaviour (m_animator,transform,m_speed,m_cam);
	}

	// Update is called once per frame
	void Update ()
	{
		m_playerBehaviour.Behaviour ();
		
		if (Input.GetKeyUp (KeyCode.Space)) 
		{
			GetComponent<Health> ().ApplyDamage ();
		}

		if (Input.GetKey (KeyCode.Q) && m_playerBehaviour.m_hit == 0) 
		{
			m_aura.SetActive (true);
			timer += Time.deltaTime;

			if (timer >= 3) 
			{
				m_animator.SetTrigger ("Charged");
				Invoke ("ActionMovement", 0.5f);
				Invoke ("DisableChargeAttack", 1.5f);
			}

		} 
		else if (Input.GetKeyUp (KeyCode.Q)) 
		{
			timer = 0;
			m_aura.SetActive (false);
		}	
		

		if (Input.GetKeyDown (KeyCode.Space) && m_actionMovement == false) 
		{
			m_actionMovement = true;
			m_animator.SetTrigger ("Jump");
			Invoke ("jump", 0.5f);
		}

		if (m_actionMovement == true) 
		{
			ActionMovement ();
			Invoke ("ActionMovementmentDisable", 1f);
		}
	}

	void ActionMovement()
	{
		transform.Translate (Vector3.forward * 4 * Time.deltaTime);
	}

	void DisableChargeAttack()
	{
		m_actionMovement = false;
		m_animator.ResetTrigger ("Charged");
		timer = 0;
		m_aura.SetActive (false);
	}

	void jump()
	{
		GetComponent<Rigidbody>().AddForce (jumpVelocity, ForceMode.VelocityChange);
	}

	void ActionMovementmentDisable()
	{
		m_actionMovement = false;
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "PickUpWeapon")
		{
			m_weapon.SetActive (true);
			collision.gameObject.SetActive(false);
		}
	}
}