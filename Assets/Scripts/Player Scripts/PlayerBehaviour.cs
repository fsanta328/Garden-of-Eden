using UnityEngine;
using System.Collections;

public class PlayerBehaviour : Protagonist
{
	internal PlayerBehaviour(Animator a_animator, Transform a_transfrom, float a_speed, GameObject a_cam)
	{
		m_animator = a_animator;
		m_transform = a_transfrom;
		m_speed = a_speed;
		m_cam = a_cam;
	}
	
	internal void FreeMovement()
	{	
		if (Is_keyPressed(KeyCode.UpArrow)) 
		{
			if (Is_keyPressed(KeyCode.LeftArrow)) 
			{
				Move (Direction.FrontLeft);
			} 
			else if (Is_keyPressed(KeyCode.RightArrow)) 
			{
				Move (Direction.ForntRight);
			} 
			else 
			{
				Move (Direction.Front);
			}
		}

		else if (Is_keyPressed(KeyCode.DownArrow))
		{
			if (Is_keyPressed(KeyCode.LeftArrow)) 
			{
				Move (Direction.BackLeft);
			} 
			else if (Is_keyPressed(KeyCode.RightArrow)) 
			{
				Move (Direction.BackRight);
			} 
			else 
			{
				Move (Direction.Back);
			}
		}

		else if (Is_keyPressed(KeyCode.LeftArrow)) 
		{
			Move (Direction.Left);
		}

		else if (Is_keyPressed(KeyCode.RightArrow))
		{
			Move (Direction.Right);
		}

		else if(m_hit == 0 && m_timer == 0 && !Input.GetKey(KeyCode.D))
		{
			Animation (AnimationClip.Idle);
		}
	}

	internal void LockOnMovement()
	{
		//moving forward
		if (Is_keyPressed(KeyCode.UpArrow)) 
		{
			//move forward
			Walk(Vector3.forward, AnimationClip.WalkForward);
		}

		else if (Is_keyPressed(KeyCode.DownArrow)) 
		{
			//move backward
			Walk(Vector3.back, AnimationClip.WalkBackward);
		}

		else if(Is_keyPressed(KeyCode.RightArrow))
		{
			//move right
			Walk(Vector3.right, AnimationClip.WalkRight);
		}

		else if(Is_keyPressed(KeyCode.LeftArrow))
		{
			//move left
			Walk(Vector3.left, AnimationClip.WalkLeft);
		}

		else if(m_hit == 0 && m_timer == 0)
		{
			//Idle
			Animation (AnimationClip.Idle);
		}
	}

}
