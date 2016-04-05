﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	public GameObject m_cam,m_weapon, m_aura;
	private Animator m_animator;
	public Inventory m_inventory;
	public GameObject m_inventoryCanvas;
	public bool m_inventoryNotOpen;
	public float m_visible;
	public float m_health, m_attack, m_defence;
	public int collected = 0;
	public bool invu;
	public static float m_weaponEquipped = 0;
	public int m_weaponOn = 0;
	public int m_pauldronOn = 0;
	public int m_armGuardOn = 0;
	public int m_kneeGuardOn = 0;
	public Slider m_healthSlider;
	public Image m_edenPortrait;
	PlayerBehaviour m_playerBehaviour;
	public List<Sprite> m_edenFaces;

	// Use this for initialization
	void Start () 
	{
		m_animator = GetComponent<Animator> ();
		m_playerBehaviour = new PlayerBehaviour (m_animator,transform,m_cam, m_aura);

		m_inventoryNotOpen = false;
		m_visible = m_inventoryCanvas.GetComponent<CanvasGroup> ().alpha;
		m_healthSlider = GameObject.FindObjectOfType<Slider> ();
		//m_edenPortrait = GameObject.FindObjectOfType<Image> ();
		m_health = 100;
		m_attack = 10;
		m_defence = 5;
	}

	// Update is called once per frame
	void Update ()
	{ 
		if (m_health > 0) 
		{
			if (Input.GetKeyUp (KeyCode.M)) 
			{
				invu = true;
			}
		
			if (Input.GetKeyUp (KeyCode.N)) 
			{
				invu = false;
			}

			//key to open or close inv
			if (Input.GetKeyUp (KeyCode.I)) 
			{
				//hiding inv
				if (m_inventoryNotOpen == true)
				{
					m_inventoryCanvas.GetComponent<CanvasGroup> ().alpha = 0;
					m_inventoryCanvas.GetComponent<CanvasGroup> ().interactable = false;
					m_visible = m_inventoryCanvas.GetComponent<CanvasGroup> ().alpha;
					m_inventoryNotOpen = false;
				}

				//opening inv
				else if (m_inventoryNotOpen == false) 
				{
					m_inventoryCanvas.GetComponent<CanvasGroup> ().alpha = 1;
					m_inventoryCanvas.GetComponent<CanvasGroup> ().interactable = true;
					m_visible = m_inventoryCanvas.GetComponent<CanvasGroup> ().alpha;
					m_inventoryNotOpen = true;
				}		
			}

			if ((Input.GetKeyUp (KeyCode.L)) && (m_visible == 1)) 
			{
				m_inventory.AddItem (0);
				m_inventory.AddItem (1);
				m_inventory.AddItem (2);
				m_inventory.AddItem (3);
				m_inventory.AddItem (4);
				m_inventory.AddItem (5);
				m_inventory.AddItem (6);
				m_inventory.AddItem (7);
				m_inventory.AddItem (8);
			}

			m_playerBehaviour.Behaviour ();
		}

		Death ();

	}



	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "gem") 
		{
			m_weapon.SetActive (true);
			collision.gameObject.SetActive (false);
			collected = 1;
			collision.gameObject.tag = "Weapon";
			m_inventory.AddItem (0);
		}

		if (collision.gameObject.tag == "sword") 
		{
			//collision.gameObject.
			m_inventory.AddItem (0);
			Debug.Log ("sword");

			Destroy (collision.gameObject);
		}

		if (collision.gameObject.tag == "armour") 
		{
			m_inventory.AddItem (1);
			Debug.Log ("armour");
			Destroy (collision.gameObject);
		}

		if (collision.gameObject.tag == "food") 
		{
			m_inventory.AddItem (2);
			Debug.Log ("food");
			Destroy (collision.gameObject);
		}


		if (collision.gameObject.tag == "Enemy") 
		{
			if (invu == false) 
			{
				m_health = m_health - 10;
				m_healthSlider.value = m_health;
				ChangeImage (m_healthSlider.value);
			} 

			else 
			{
				ApplyDamage (collision); 					
			}
		}

		foreach (ContactPoint c in collision.contacts) 
		{
			if ((c.thisCollider.tag == "Weapon") && (collision.gameObject.tag == "Enemy"))
			{
				Debug.Log ("swordhit");
				ApplyDamage (collision);
			}

			else if ((c.thisCollider.tag == "Weapon") && (collision.gameObject.tag == "Boss"))
			{
				Debug.Log ("bossDMG");
				ApplyDamage (collision);
			}

			else if ((c.thisCollider.tag == "Weapon") && (collision.gameObject.tag == "mBoss"))
			{
				Debug.Log ("minibosshit");
				ApplyDamage (collision);
			}
		}
	}

	public void RestoreHealth(float a_health)
	{
		m_health = m_health + a_health;
		m_healthSlider.value = m_health;
		ChangeImage (m_healthSlider.value);
	}

	public float damageCalc()
	{
		float wepAttack;
		float dmg;
		if (collected == 0) 
		{
			wepAttack = 0;
			return dmg = m_attack + wepAttack;
		} 

		else 
		{
			wepAttack = 10;
			return dmg = m_attack + wepAttack;
		}
	}

	public void ApplyDamage(Collision a_collision)
	{
		if (a_collision.gameObject.tag == "Enemy")
		{
			a_collision.gameObject.GetComponent<EnemiesLife> ().g_currentHealth = 
								a_collision.gameObject.GetComponent<EnemiesLife> ().g_currentHealth - damageCalc ();
		}
			
		else if (a_collision.gameObject.tag == "Boss")
		{
			a_collision.gameObject.GetComponent<Boss> ().g_currentHealth = 
								a_collision.gameObject.GetComponent<Boss> ().g_currentHealth - damageCalc ();
		}

		else if (a_collision.gameObject.tag == "mBoss")
		{
			a_collision.gameObject.GetComponent<mBoss> ().g_currentHealth = 
								a_collision.gameObject.GetComponent<mBoss> ().g_currentHealth - damageCalc ();
		}

	}

	void ChangeImage(float a_health)
	{
		if (a_health < 20) 
		{
			m_edenPortrait.sprite = m_edenFaces [2];
		}

		else if (a_health <= 59) 
		{
			m_edenPortrait.sprite = m_edenFaces [1];
		}

		else if (a_health > 60) 
		{
			m_edenPortrait.sprite = m_edenFaces [0];
		} 
	}



	void Death()
	{
		if (m_health <= 0) 
		{
		m_playerBehaviour.Animation(AnimationClip.Die);

		}
	}

	//Following are the events that shall be called inside certain animation clips.

	//while in the jump state
	void EventOfJump()
	{
		//Jump
		transform.gameObject.GetComponent<Rigidbody>().AddForce (m_playerBehaviour.jumpVelocity, ForceMode.VelocityChange);

		//if the player was in the state of attack before going into the Jump state, reset that certain trigger.
		m_playerBehaviour.ResetCombatTriggers ();
	}

	//This is being called inside certain animation clips, to make player move. 
	void ActionMove(float a_speed)
	{
		m_playerBehaviour.m_speed = a_speed;
	}

	//To make sure the movement get disabled after that certain animation clip is ended.
	void ActionMoveDisable()
	{
		m_playerBehaviour.m_speed = 0;
	}

	void AttackMove()
	{
		m_playerBehaviour.m_attackMovement = true;	
	}
	void AttackMoveDisable()
	{
		m_playerBehaviour.m_attackMovement = false;	
	}

	//if this method is being called inside the charge attack of the player, it will disable and reset certain values.
	void DisableAura()
	{
		m_playerBehaviour.DisableChargeAttack ();
	}

	//When player is in the state of first attack
	void Attack1()
	{
		m_playerBehaviour.CombatAnimation (2, "Punch1");
	}
	//When player is in the state of second attack
	void Attack2()
	{
		m_playerBehaviour.CombatAnimation (3, "Punch2");
	}

	void Dead()
	{
		SceneManager.LoadScene (0);
	}
}