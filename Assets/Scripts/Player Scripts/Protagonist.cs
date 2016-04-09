using UnityEngine;
using System.Collections.Generic;

public enum AnimationClip
{
	Idle = -1,
	WalkForward = 2,
	WalkBackward = 1,
	WalkRight = 3,
	WalkLeft = 4,
	Die = 8,
};

public enum Direction
{
	Front = 0,
	Back = 180,
	Left = 270,
	Right = 90, 
	ForntRight = 45,
	FrontLeft = 315,
	BackRight = 135,
	BackLeft = 225,
};

public class Protagonist
{
	internal Animator m_animator;
	internal Transform m_transform;
	internal float m_speed, m_timer = 0, m_timeKeeper = 0, m_maxDistance = 5, m_rotationSpeed = 10, m_miniBossCurrentDistance, m_FinalBossCurrentDistance;
	internal GameObject m_cam,m_aura,m_miniMonster,m_boss;
	internal int m_hit = 0;
	internal bool m_attackMovement = false, m_runningClip = false, m_comboTimer = false;
	internal Vector3 m_distance,m_commonEnemyDistance, m_miniBossDistance, m_bossDistance, jumpVelocity = new  Vector3(0, 3.0f, 0);
	internal GameObject[] m_enemies;

	//Checking is player in the state of certain animation
	internal bool Is_animation(string a_nameTag, bool a_isActive)
	{
		return m_animator.GetCurrentAnimatorStateInfo (0).IsTag (a_nameTag).Equals (a_isActive);
	}

	//Apply Certain animation clips as according to the condition menditon in mecanim
	internal void Animation(AnimationClip a_animationClip)
	{
		m_animator.SetFloat ("Anim", (int)a_animationClip);
	}

	//This method calls certain animtions that uses triggers to active
	internal void TriggerAnimation(string a_animationClip)
	{
		m_animator.SetTrigger (a_animationClip);
	}

	//To check if certain input key is being hold down
	internal bool Is_keyPressed(KeyCode a_key)
	{
		return Input.GetKey (a_key) && (m_hit == 0);
	}
		
	internal bool Is_lockedOn()
	{
		return Input.GetKey (KeyCode.LeftShift);
	}

	internal void Move(Direction a_direction)
	{
		//Free movemnt, allowing player to move and play forward animation at all time
		Animation (AnimationClip.WalkForward);

		//making sure player is facing a right derection, while certain input key is being hold down
		m_transform.eulerAngles = new Vector3 (0,  m_cam.transform.eulerAngles.y + (int)a_direction, 0);

		CombatState ();
	}

	internal void CombatState()
	{
		if (Input.GetKeyDown (KeyCode.E) && Player.m_weaponEquipped == 1) 
		{
			m_hit++;
		}

		if(m_hit == 1 && Is_animation("Run",false))
		{
			//Trigger first attack animation
			TriggerAttack(1);

			AttackOnTheDirectionOfCamera ();

			//This timer will start when first attack was made
			m_comboTimer = true;
		}
		else if (m_hit >= 1 && Is_animation("Run", true))
		{
			TriggerAnimation ("Punch" + 1);	
		}

		//This will make sure to exit combo, if the combo is not done correctly
		if(m_comboTimer == true)
		{
			m_timer += Time.deltaTime;
		}

		Break ("Punch1");

		Break ("Punch2");

		Break ("Punch3");

	}

	//Method to break combo if not done correctly by the user
	void Break(string a_animationClipTag)
	{
		float a_animationClipAverageLimit = 0.95f;

		//if animation clip reach its limit
		if(m_timer >= a_animationClipAverageLimit && Is_animation(a_animationClipTag,true))
		{
			ResetCombatParameters();
			m_comboTimer = false;
			m_timer = 0;
		}
	}

	//To check if player is doing the combo in a right mannar
	internal void CombatAnimation(int a_hit,string a_animationClipTag)
	{
		//if player pressed Attack key at the right time
		if(m_hit == a_hit && Is_animation(a_animationClipTag,true))
		{
			//Trigger Next Attack animation
			TriggerAttack(m_hit);

			AttackOnTheDirectionOfCamera ();
			//reset timer
			m_timer = 0;
		}
	}

	//Reset all combat parameters 
	internal void ResetCombatParameters()
	{
		//Reset whole combo
		m_hit = 0;

		//Reset each Punching Trigger/parameter in the Animator panel
		for (int i = 0; i < m_hit; i++) 
		{
			m_animator.ResetTrigger ("Punch" + i);
		}
	}

	//Method that triggers conditions of the combat/attack states
	void TriggerAttack(int a_hit)
	{
		//starting value of combo, as according to the condition in the mecanim 
		int a_combatStartingValue = 4;

		TriggerAnimation ("Punch" + a_hit);
		m_animator.SetFloat ("Anim", a_hit + a_combatStartingValue);
	}

	internal void Walk(Vector3 a_position, AnimationClip a_animationClip)
	{
		m_transform.Translate (a_position * m_speed * Time.deltaTime);
		Animation(a_animationClip);
		CombatState ();
	}

	internal void AttackOnTheDirectionOfCamera()
	{
		if(!Is_lockedOn() && Is_animation("RunAttack",false))
		{
			m_transform.eulerAngles = new Vector3 (0, m_cam.transform.eulerAngles.y, 0);
		}
	}

	internal void LockCertainRotations()
	{	//allowing player to rotate only in y-axis rotation
		m_transform.eulerAngles = new Vector3 (0, m_transform.eulerAngles.y, 0);
	}
}