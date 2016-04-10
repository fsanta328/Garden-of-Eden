using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : Protagonist 
{
	//Free Movement: allow protagonist to rotate and move only with forward animation clip in certain directions
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
			RunningParameterReset ();
			m_speed = 0;
			Animation (AnimationClip.Idle);
		}
	}

	//Allow protagonist to only move with certain animation clips and in certain directions
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

	internal void RunningParameterReset()
	{
		m_runningClip = false;
	}

	internal void LockOnTarget()
	{
		Vector3 a_commonEnemyDistance, a_miniBossDistance, a_bossDistance;

		float a_maxdistance = m_maxDistance, a_miniBossClose, a_bossClose;

		m_enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		if (m_miniMonster != null) 
		{
//			a_miniBossDistance = m_miniMonster.transform.position - m_transform.position;
//			a_miniBossClose = a_miniBossDistance.sqrMagnitude;
			//return a_miniBossClose;
		}

		if (m_boss != null)

		{
//			a_bossDistance = m_boss.transform.position - m_transform.position;
//			a_bossClose = a_bossDistance.sqrMagnitude;
			//return a_bossClose;
		}

		foreach (GameObject a_enemy in m_enemies) 
		{
			a_commonEnemyDistance = a_enemy.transform.position - m_transform.position;

			float a_closeDistance = a_commonEnemyDistance.sqrMagnitude;

			if (a_closeDistance < a_maxdistance) 
			{
				a_maxdistance = a_closeDistance;

				m_distance = a_enemy.gameObject.transform.position - m_transform.position;

				if(Is_lockedOn())
				{
					m_transform.rotation = Quaternion.Lerp(m_transform.rotation, Quaternion.LookRotation (m_distance), m_rotationSpeed *Time.deltaTime);
			
					LockCertainRotations ();
				}
			}

			if (m_miniMonster != null)
			{
				a_miniBossDistance = m_miniMonster.transform.position - m_transform.position;
				a_miniBossClose = a_miniBossDistance.sqrMagnitude;
				if(a_miniBossClose < a_maxdistance && m_miniMonster.activeInHierarchy== true)
				{
					a_maxdistance = a_miniBossClose;

					m_distance = m_miniMonster.gameObject.transform.position - m_transform.position;

					if(Is_lockedOn())
					{
						m_transform.rotation = Quaternion.Lerp(m_transform.rotation, Quaternion.LookRotation (m_distance), m_rotationSpeed *Time.deltaTime);

						LockCertainRotations ();
					}
				}
			}

			if (m_boss != null)
			{
				a_bossDistance = m_boss.transform.position - m_transform.position;
				a_bossClose = a_bossDistance.sqrMagnitude;
				if(a_bossClose < a_maxdistance && m_boss.activeInHierarchy == true)
				{
					a_maxdistance = a_bossClose;

					m_distance = m_boss.gameObject.transform.position - m_transform.position;

					if(Is_lockedOn())
					{
						m_transform.rotation = Quaternion.Lerp(m_transform.rotation, Quaternion.LookRotation (m_distance), m_rotationSpeed *Time.deltaTime);

						LockCertainRotations ();
					}
				}
			}
		}
	}
}
