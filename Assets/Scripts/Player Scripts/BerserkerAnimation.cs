using UnityEngine;
using System.Collections.Generic;

public class BerserkerAnimation : MonoBehaviour 
{
	public GameObject m_cam;
	public float m_speed;
	public float m_front,m_back, m_left,m_right, m_forntRight,m_frontLeft,m_backRight,m_backLeft;

	private Animator m_animator;
	private int m_hit = 0;
	private float m_timer = 0;
	private bool m_relativeDirectionMovement = false;

	// collection of float which will help transect b/w Animations
	public List<float> m_animationList = new List<float> ();

	public GameObject Weapon;

	// Animations for (Idle, Walk, Run, Attack)
	void SetAnimation(float slide)
	{
		m_animator.SetFloat ("Anim", slide);
	}

	// Use this for initialization
	void Start () 
	{
		m_animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () 
	{
		BasicMovement ();
		
		CombatState ();

		//Will only lock on target if it is near
		if (Input.GetKey (KeyCode.D) && GetComponent<TargetLock> ().m_distance.magnitude <= 5)
		{
			m_relativeDirectionMovement = true;
		}
		else if(GetComponent<TargetLock> ().m_distance.magnitude >= 5)
		{
			m_relativeDirectionMovement = false;
		}
			
		RelativeDirectionMovement ();

		if (Input.GetKeyUp(KeyCode.Space))
		{
			GetComponent<Health>().ApplyDamage();
		}
	}

	void Move(float a_rotation)
	{
		transform.Translate (Vector3.forward * m_speed * Time.deltaTime);

		m_animator.SetFloat ("Anim", 2);

		transform.eulerAngles = new Vector3 (0, m_cam.transform.eulerAngles.y + a_rotation, 0);
	}

	void BasicMovement()
	{	
		if (Input.GetKey (KeyCode.UpArrow) && m_relativeDirectionMovement == false && (m_hit == 0) && m_timer == 0) 
		{
			if (Input.GetKey (KeyCode.LeftArrow) && m_relativeDirectionMovement == false && (m_hit == 0) && m_timer == 0) 
			{
				Move (m_frontLeft);
			} 
			else if (Input.GetKey (KeyCode.RightArrow) && m_relativeDirectionMovement == false && (m_hit == 0) && m_timer == 0) 
			{
				Move (m_forntRight);
			} 
			else 
			{
				Move (m_front);
			}
		}

		else if (Input.GetKey(KeyCode.DownArrow) && m_relativeDirectionMovement == false && (m_hit == 0) && m_timer == 0)
		{
			if (Input.GetKey (KeyCode.LeftArrow) && m_relativeDirectionMovement == false && (m_hit == 0) && m_timer == 0) 
			{
				Move (m_backLeft);
			} 
			else if (Input.GetKey (KeyCode.RightArrow) && m_relativeDirectionMovement == false && (m_hit == 0) && m_timer == 0) 
			{
				Move (m_backRight);
			} 
			else 
			{
				Move (m_back);
			}
		}

		else if (Input.GetKey (KeyCode.LeftArrow) && m_relativeDirectionMovement == false && (m_hit == 0) && m_timer == 0) 
		{
			Move (m_left);
		}

		else if (Input.GetKey(KeyCode.RightArrow) && m_relativeDirectionMovement == false && (m_hit == 0) && m_timer == 0)
		{
			Move (m_right);
		}

		else if(m_hit == 0 && m_timer == 0 && m_relativeDirectionMovement == false)
		{
			SetAnimation (m_animationList [0]);
		}
	}


	void CombatState()
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			m_hit++;
		}

		if(m_hit == 1)
		{
			Punch (1, 0.55f);
		}

		else if(m_hit == 2)
		{
			Punch (2, 0.85f);
		}

		else if(m_hit >= 3)
		{
			m_hit = 3;
			Punch (3, 1f);
		}
	}

	void Punch(int a_punch, float a_timerLimit)
	{
		m_timer += Time.deltaTime;

		//Trigger punch animation
		m_animator.SetTrigger ("Punch" + a_punch);
		SetAnimation (m_animationList [a_punch + 2]);

		//if timer goes beyond the requird limit, go back to default animation
		if (m_timer >= a_timerLimit) 
		{
			m_hit = 0;
			m_timer = 0;

			for (int i = 1; i <= a_punch; i++) 
			{
				m_animator.ResetTrigger ("Punch" + i);
			}
			SetAnimation (m_animationList[0]);
		}
	}

	void RelativeDirectionMovement()
	{
		//moving forward
		if (Input.GetKey (KeyCode.UpArrow) && m_relativeDirectionMovement == true && (m_hit == 0) && m_timer == 0) 
		{
			//move forward
			transform.Translate (Vector3.forward * m_speed * Time.deltaTime);
			SetAnimation(m_animationList[2]);
		}

		else if (Input.GetKey (KeyCode.DownArrow) && m_relativeDirectionMovement == true && (m_hit == 0) && m_timer == 0) 
		{
			//move backward
			transform.Translate (Vector3.back * m_speed * Time.deltaTime);
			SetAnimation(m_animationList[1]);
		}

		else if(Input.GetKey(KeyCode.RightArrow) && m_relativeDirectionMovement == true && (m_hit == 0) && m_timer == 0)
		{
			//move right
			transform.Translate (Vector3.right * m_speed * Time.deltaTime);
			SetAnimation (m_animationList [7]);
		}

		else if(Input.GetKey(KeyCode.LeftArrow) && m_relativeDirectionMovement == true && (m_hit == 0) && m_timer == 0)
		{
			//move left
			transform.Translate (Vector3.left * m_speed * Time.deltaTime);
			SetAnimation (m_animationList [6]);
		}

		else if(m_relativeDirectionMovement == true && m_hit == 0 && m_timer == 0)
		{
			//Idle
			SetAnimation (m_animationList [0]);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "PickUpWeapon")
		{
			Weapon.SetActive (true);
			collision.gameObject.SetActive(false);
		}
	}
}
