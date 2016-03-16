using UnityEngine;
using System.Collections;

public class PlayerBehaviour : PlayerMovement
{
	internal PlayerBehaviour(Animator a_animator, Transform a_transfrom, float a_speed, GameObject a_cam)
	{
		m_animator = a_animator;
		m_transform = a_transfrom;
		m_speed = a_speed;
		m_cam = a_cam;
	}

	internal void Behaviour()
	{
		CombatState ();

		LockOnTarget ();

		//is enemy near
		if (Is_lockedOn())
		{
			LockOnMovement ();
		}
		else if(!Is_lockedOn()) 
		{
			FreeMovement ();
		}
	}
}
