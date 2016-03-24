using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
	public GameObject m_cam,m_weapon, m_aura;
	public float m_speed;
	private Animator m_animator;
	private float timer;
	private Vector3 jumpVelocity = new  Vector3(0, 3.50f, 0);
	bool m_actionMovement;
	public Inventory m_inventory;
	public GameObject m_inventoryCanvas;
	public bool m_inventoryNotOpen;
	public float m_visible;
	public float m_health;
	public float m_attack;
	public float m_defence;
	public int collected = 0;
	public Weapon m_weaponScript;
	public bool invu;

	PlayerBehaviour m_playerBehaviour;

	// Use this for initialization
	void Start () 
	{
		timer = 0;
		m_actionMovement = false;
		m_animator = GetComponent<Animator> ();
		m_playerBehaviour = new PlayerBehaviour (m_animator,transform,m_speed,m_cam);

		m_inventoryNotOpen = false;
		m_visible = m_inventoryCanvas.GetComponent<CanvasGroup> ().alpha;

		m_health = 90;
		m_attack = 10;
		m_defence = 5;
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.M))
			{
				invu = true;
			}
		if (Input.GetKeyUp (KeyCode.N))
		{
			invu = false;
		}
		Death ();
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
		}

		if ((Input.GetKeyUp (KeyCode.K)) && (m_visible == 1)) 
		{
			m_inventory.AddItem (1);
		}

		if (Input.GetKeyUp (KeyCode.Comma)) 
		{
			m_inventory.AddItem (2);
		}

		m_playerBehaviour.Behaviour ();
		
//		if (Input.GetKeyUp (KeyCode.Space)) 
//		{
//			GetComponent<Health> ().ApplyDamage ();
//		}

		if (Input.GetKey (KeyCode.Q) && m_playerBehaviour.m_hit == 0) 
		{
			m_aura.SetActive (true);
			timer += Time.deltaTime;

			if (timer >= 1.5f) 
			{
				m_animator.SetTrigger ("Charged");
				Invoke ("ActionMovement", 0.75f);
				Invoke ("DisableChargeAttack", 1.5f);
			}
		} 
		else if (Input.GetKeyUp (KeyCode.Q)) 
		{
			DisableChargeAttack ();
		}			

		if (Input.GetKeyDown (KeyCode.Space) && m_animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump").Equals(false) && m_actionMovement == false) 
		{
			m_actionMovement = true;
			m_animator.SetTrigger ("Jump");
			Invoke ("Jump", 0.5f);
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
	void ActionMovementmentDisable()
	{
		m_actionMovement = false;
	}
	void Jump()
	{
		GetComponent<Rigidbody>().AddForce (jumpVelocity, ForceMode.VelocityChange);
	}
	void DisableChargeAttack()
	{
		m_animator.ResetTrigger ("Charged");
		timer = 0;
		m_aura.SetActive (false);
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

		if (collision.gameObject.tag == "Item") 
		{
			m_inventory.AddItem (1);
			//Debug.Log ("idrop");
		}

		if (collision.gameObject.tag == "Enemy") 
		{
			if (invu == false) 
			{
				//m_health = m_health - 20;
				Debug.Log ("hurt");
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

		}
	}

	public void RestoreHealth(float a_health)
	{
		m_health = m_health + a_health;
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
		a_collision.gameObject.GetComponent<EnemiesLife> ().g_currentHealth = a_collision.gameObject.GetComponent<EnemiesLife> ().g_currentHealth - damageCalc();

	}

	void Death()
	{
		if (m_health <= 0) 
		{
			SceneManager.LoadScene (0);
		}
	}


}