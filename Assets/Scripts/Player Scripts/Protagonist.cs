using UnityEngine;
using System.Collections;

public enum AnimationClip
{
	Idle = -1,
	WalkForward = 2,
	WalkBackward = 1,
	WalkRight = 3,
	WalkLeft = 4,
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
	internal float m_speed, m_timer = 0;
	internal GameObject m_cam;
	internal int m_hit = 0;

	internal void Animation(AnimationClip a_animationClip)
	{
		m_animator.SetFloat ("Anim", (int)a_animationClip);
	}

	internal bool Is_keyPressed(KeyCode a_key)
	{
		return Input.GetKey (a_key) && (m_hit == 0) && m_timer == 0;
	}

	internal void Move(Direction a_direction)
	{
		m_transform.Translate (Vector3.forward * m_speed * Time.deltaTime);

		Animation (AnimationClip.WalkForward);

		m_transform.eulerAngles = new Vector3 (0, m_cam.transform.eulerAngles.y + (int)a_direction, 0);

		CombatState ();
	}

	internal void CombatState()
	{
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			m_hit++;
		}

		if (m_hit == 1) 
		{
			Punch (1, 0.55f);
		}
		else if(m_hit == 2)
		{
			Punch (2, 0.85f);
		}
		else if(m_hit >= 3)
		{
			Punch (3, 1f);
		}
	}

	void Punch(int a_punch, float a_timerLimit)
	{
		m_timer += Time.deltaTime;

		//Trigger punch animation
		m_animator.SetTrigger ("Punch" + a_punch);
		m_animator.SetFloat ("Anim", a_punch + 4);

		//if timer goes beyond the requird limit, go back to default animation
		if (m_timer >= a_timerLimit) 
		{
			m_hit = 0;
			m_timer = 0;

			//Reset each Punching Trigger
			for (int i = 1; i <= a_punch; i++) 
			{
				m_animator.ResetTrigger ("Punch" + i);
			}
			//Go back to Idle
			Animation (AnimationClip.Idle);
		}
	}

	internal void Walk(Vector3 a_position, AnimationClip a_animationClip)
	{
		m_transform.Translate (a_position * m_speed * Time.deltaTime);
		Animation(a_animationClip);
		CombatState ();
	}
}