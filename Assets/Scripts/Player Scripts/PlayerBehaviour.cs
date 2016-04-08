using UnityEngine;
using System.Collections;

public class PlayerBehaviour : PlayerMovement
{
	internal PlayerBehaviour(Animator a_animator, Transform a_transfrom, GameObject a_cam, GameObject a_aura, GameObject a_miniMonster, GameObject a_boss)
	{
		m_animator = a_animator;
		m_transform = a_transfrom;
		m_cam = a_cam;
		m_aura = a_aura;
		m_miniMonster = a_miniMonster;
		m_boss = a_boss;
	}

	internal void Behaviour()
	{
		CombatState ();

		LockOnTarget ();

		UpdateIdleState ();

		//is enemy near and have certain weapon in the hand of the player
		if (Is_lockedOn() && Player.m_weaponEquipped == 1)
		{	
			//cannot allow to run in lock on state
			m_runningClip = false;
			LockOnMovement ();
		}
		else if(!Is_lockedOn()) 
		{
			ActionMovement ();
			FreeMovement ();
		}

		if(m_attackMovement == true)
		{
			AttackMovement ();
		}

		RunningState ();
			
		JumpState ();

		ChargeState ();
	}

	void UpdateIdleState()
	{
		//check if player is holding a weapon or not, and update idle animation accordingly.
		m_animator.SetFloat ("Idle", Player.m_weaponEquipped);
	}

	void RunningState()
	{
		if(Input.GetKeyDown(KeyCode.RightShift) && !Is_lockedOn())
		{
			if(m_runningClip == true)
			{
				m_runningClip = false;
			}
			else
			{
				m_runningClip = true;
			}
		}

		m_animator.SetBool ("Running", m_runningClip);
	}

	//Following method Shall be used to make player move with a desired speed, while it is in certain walking state
	void ActionMovement()
	{
		m_transform.Translate (Vector3.forward * m_speed * Time.deltaTime);
	}
	//This logic is being used to make player move while doing certain combat animations
	void AttackMovement()
	{
		m_transform.Translate (Vector3.forward * 3 * Time.deltaTime);
	}

	//Method to make player jump
	void JumpState()
	{
		//if not in the state of jumping
		if (Input.GetKeyDown (KeyCode.Space) && Is_animation("Jump", false)) 
		{
			//Let protagonist jump
			TriggerAnimation ("Jump");
		}
	}

	internal void ChargeState()
	{
		float a_chargeMaxLimit = 1.5f;
		
		//While certain input key is being hold down,
		if (Input.GetKey (KeyCode.Q) && m_hit == 0 && Is_animation("ChargedAttack",false)) 
		{
			//start charge timer
			m_timeKeeper += Time.deltaTime;
			m_aura.SetActive (true);

			//if timer reachs to its limit
			if (m_timeKeeper >= a_chargeMaxLimit) 
			{
				//tap into the state of Idle to make smooth animation state
				Animation (AnimationClip.Idle);

				//check, is character in the state of idle
				if(Is_animation("Idle", true) && Is_animation("ChargedAttack", false))
				{
					//Attack
					TriggerAnimation ("Charged");
				}
			}
		} 
		//check, is charge key released before it was charged  
		else if (Input.GetKeyUp (KeyCode.Q) && m_timeKeeper <= 1.5f) 
		{
			DisableChargeAttack ();
		}			
	}

	//To disable certain valuse of the charge attack.
	internal void DisableChargeAttack()
	{
		m_timeKeeper = 0;
		m_animator.ResetTrigger ("Charged");
		m_aura.SetActive (false);
	}
}
