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
	internal float m_speed,m_timer = 0,m_timeKeeper = 0, m_maxDistance = 5, m_rotationSpeed = 10;
	internal GameObject m_cam,m_aura;
	internal int m_hit = 0;
	internal bool m_attackMovement = false, m_comboTimer = false;
	internal Vector3 m_distance, jumpVelocity = new  Vector3(0, 3.0f, 0);

	internal MonoBehaviour m_monoBehaviour = new MonoBehaviour();

	internal bool Is_animation(string a_nameTag, bool a_isActive)
	{
		return m_animator.GetCurrentAnimatorStateInfo (0).IsTag (a_nameTag).Equals (a_isActive);
	}

	internal void Animation(AnimationClip a_animationClip)
	{
		m_animator.SetFloat ("Anim", (int)a_animationClip);
	}

	internal void TriggerAnimation(string a_animationClip)
	{
		m_animator.SetTrigger (a_animationClip);
	}

	internal bool Is_keyPressed(KeyCode a_key)
	{
		return Input.GetKey (a_key) && (m_hit == 0);
	}

	internal bool Is_lockedOn()
	{
		return Input.GetKey (KeyCode.Mouse1) && m_distance.magnitude <= m_maxDistance;
	}

	internal void Move(Direction a_direction)
	{
		//m_transform.Translate (Vector3.forward * m_speed * Time.deltaTime);

		Animation (AnimationClip.WalkForward);

		m_transform.eulerAngles = new Vector3 (0,  m_cam.transform.eulerAngles.y + (int)a_direction, 0);

		CombatState ();
	}

	internal void CombatState()
	{
		if (Input.GetKeyDown (KeyCode.E) && Player.m_weaponEquipped == 1) 
		{
			m_hit++;
		}


		if(m_hit == 1)
		{
			//Trigger punch animation
			TriggerAnimation ("Punch" + 1);
			m_animator.SetFloat ("Anim", 1 + 4);

			m_comboTimer = true;
		}

		if(m_comboTimer == true)
		{
			m_timer += Time.deltaTime;
		}

		BreakCombo ("Punch1");

		BreakCombo ("Punch2");

		BreakCombo ("Punch3");
	}

	//Method to break combo if not done correctly by the user
	void BreakCombo(string a_animationClipTag)
	{
		float a_animationClipAverageLimit = 0.95f;

		//if animation clip reach its limit
		if(m_timer >= a_animationClipAverageLimit && Is_animation(a_animationClipTag,true))
		{
			ResetCombatTriggers ();
			m_timer = 0;
			m_comboTimer = false;
		}
	}

	//To check if player is doing the combo in a right mannar
	internal void CombatAnimation(int a_hit,string a_animationClipTag)
	{
		int a_CombatStartingParameter = 4;

		//if player pressed Attack key at the right time
		if(m_hit == a_hit && Is_animation(a_animationClipTag,true))
		{
			//Trigger Next Attack animation
			TriggerAnimation ("Punch" + a_hit);
			m_animator.SetFloat ("Anim", a_hit + a_CombatStartingParameter);
			m_timer = 0;
		}
	}

	internal void ResetCombatTriggers()
	{
		//Reset whole combo
		m_hit = 0;

		//Reset each Punching Trigger/parameter in the Animator panel
		for (int i = 0; i < m_hit; i++) 
		{
			m_animator.ResetTrigger ("Punch" + i);
		}
	}

	internal void Walk(Vector3 a_position, AnimationClip a_animationClip)
	{
		m_transform.Translate (a_position * m_speed * Time.deltaTime);
		Animation(a_animationClip);
		CombatState ();
	}

	internal void LockCertainRotations()
	{
		m_transform.eulerAngles = new Vector3 (0, m_transform.eulerAngles.y, 0);
	}
}