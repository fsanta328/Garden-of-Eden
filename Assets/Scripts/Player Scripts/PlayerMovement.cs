using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : Protagonist 
{
	internal void FreeMovement()
	{	
		if (Is_keyPressed(KeyCode.W)) 
		{
			if (Is_keyPressed(KeyCode.A)) 
			{
				Move (Direction.FrontLeft);
			} 
			else if (Is_keyPressed(KeyCode.D)) 
			{
				Move (Direction.ForntRight);
			} 
			else 
			{
				Move (Direction.Front);
			}
		}

		else if (Is_keyPressed(KeyCode.S))
		{
			if (Is_keyPressed(KeyCode.A)) 
			{
				Move (Direction.BackLeft);
			} 
			else if (Is_keyPressed(KeyCode.D)) 
			{
				Move (Direction.BackRight);
			} 
			else 
			{
				Move (Direction.Back);
			}
		}

		else if (Is_keyPressed(KeyCode.A)) 
		{
			Move (Direction.Left);
		}

		else if (Is_keyPressed(KeyCode.D))
		{
			Move (Direction.Right);
		}

		else if(m_hit == 0)
		{
			m_runningClip = false;
			m_speed = 0;
			Animation (AnimationClip.Idle);
		}
	}

	internal void LockOnMovement()
	{
		//moving forward
		if (Is_keyPressed(KeyCode.W)) 
		{
			//move forward
			Walk(Vector3.forward, AnimationClip.WalkForward);
		}

		else if (Is_keyPressed(KeyCode.S)) 
		{
			//move backward
			Walk(Vector3.back, AnimationClip.WalkBackward);
		}

		else if(Is_keyPressed(KeyCode.D))
		{
			//move right
			Walk(Vector3.right, AnimationClip.WalkRight);
		}

		else if(Is_keyPressed(KeyCode.A))
		{
			//move left
			Walk(Vector3.left, AnimationClip.WalkLeft);
		}

		else if(m_hit == 0)
		{
			//Idle
			m_speed = 0;
			Animation (AnimationClip.Idle);
		}
	}

	internal void LockOnTarget()
	{
		Queue<GameObject> a_enemies = new Queue<GameObject> ();
		
		foreach (GameObject a_target in GameObject.FindGameObjectsWithTag("Enemy")) 
		{
			a_enemies.Enqueue (a_target);
		}

		foreach(GameObject a_enemy in a_enemies)
		{
			m_distance = a_enemy.transform.position - m_transform.position;
		}

		if(Is_lockedOn())
		{
			m_transform.rotation = Quaternion.Lerp(m_transform.rotation, Quaternion.LookRotation (m_distance), m_rotationSpeed *Time.deltaTime);

			LockCertainRotations ();
		}
	}
}
