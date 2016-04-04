using UnityEngine;
using System.Collections;
using RAIN.Core;

public class CollisionDetection : MonoBehaviour   
{
	private bool m_gotHurt;
	
	void start()
	{
		//getting the boolean from the AI Rig attached to the AI(GameObject)
		m_gotHurt = GetComponent<AIRig> ().AI.WorkingMemory.ItemExists ("GotHurt");
	}
		
	public bool GetGotHurt(bool a_currentBool)
	{
		return m_gotHurt == a_currentBool;
	}

	public bool SetGotHurt(bool a_newBool)
	{
		return m_gotHurt = a_newBool;
	}
	
	void OnCollisionEnter(Collision a_collision)
	{
		if(a_collision.gameObject.tag == "PlayerSword")
		{
			SetGotHurt(true);
		}
	}

}
