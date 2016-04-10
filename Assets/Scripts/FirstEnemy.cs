using UnityEngine;
using System.Collections;

public class FirstEnemy : MonoBehaviour 
{
	public float g_currentHealth = 20;
	RAIN.Core.AIRig m_AI;

	void Start () 
	{
		//g_currentHealth = a_maxHealth;
		m_AI = this.GetComponent<RAIN.Core.AIRig>();
	}

	void Update()
	{
		if (this.gameObject.activeInHierarchy == true) 
		{
			m_AI.AI.WorkingMemory.SetItem ("Health", g_currentHealth);
		} 
	}
}
