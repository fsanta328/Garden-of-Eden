using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
	public GameObject m_cam,m_weapon;
	public float m_speed;
	private Animator m_animator;

	PlayerBehaviour m_playerBehaviour;

	// Use this for initialization
	void Start () 
	{
		m_animator = GetComponent<Animator> ();
		m_playerBehaviour = new PlayerBehaviour (m_animator,transform,m_speed,m_cam);
	}

	// Update is called once per frame
	void Update () 
	{
		m_playerBehaviour.CombatState ();

		//is enemy near
		if (Input.GetKey (KeyCode.D) && GetComponent<TargetLock> ().m_distance.magnitude <= 5)
		{
			m_playerBehaviour.LockOnMovement ();
		}
		else if(!Input.GetKey(KeyCode.D) || GetComponent<TargetLock> ().m_distance.magnitude >= 5)
		{
			m_playerBehaviour.FreeMovement ();
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			GetComponent<Health>().ApplyDamage();
		}
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