using UnityEngine;
using System.Collections;

public class PlayerBehaviour : PlayerMovement
{
	internal PlayerBehaviour(Animator a_animator, Transform a_transfrom, GameObject a_cam, GameObject a_aura)
	{
		m_animator = a_animator;
		m_transform = a_transfrom;
		m_cam = a_cam;
		m_aura = a_aura;
	}

	internal void Behaviour()
	{
		CombatState ();

		LockOnTarget ();

		m_animator.SetFloat ("Idle", Player.m_weaponEquipped);

		//is enemy near
		if (Is_lockedOn() && Player.m_weaponEquipped == 1)
		{	
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
			
		JumpState ();

		ChargeState ();

		RunningClip ();

	}

	void RunningClip()
	{
		m_animator.SetBool ("Running", m_runningClip);
	}

	//this logic is being used to make player move while doing certain animations
	void ActionMovement()
	{
		m_transform.Translate (Vector3.forward * m_speed * Time.deltaTime);
	}

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
			TriggerAnimation ("Jump");
		}
	}

	internal void ChargeState()
	{
		if (Input.GetKey (KeyCode.Q) && m_hit == 0 && Is_animation("ChargedAttack",false)) 
		{
			m_timeKeeper += Time.deltaTime;
			m_aura.SetActive (true);

			if (m_timeKeeper >= 1.5f) 
			{
				Animation (AnimationClip.Idle);

				if(Is_animation("Idle", true) && Is_animation("ChargedAttack", false))
				{
					TriggerAnimation ("Charged");
				}
			}
		} 
		else if (Input.GetKeyUp (KeyCode.Q) && m_timeKeeper <= 1.5f) 
		{
			DisableChargeAttack ();
		}			
	}

	//To disable certain valuse after the charge attack clip is done.
	internal void DisableChargeAttack()
	{
		m_timeKeeper = 0;
		m_animator.ResetTrigger ("Charged");
		m_aura.SetActive (false);
	}
}
