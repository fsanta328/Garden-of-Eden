using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour 
{
	public float g_currentHealth = 300;
	public GameObject m_portal;
	RAIN.Core.AIRig m_AI;
	GameManger m_gameM;
	public bool m_defeated = false;

	void Start () 
	{
		m_AI = this.GetComponent<RAIN.Core.AIRig>();

	}

	void Update()
	{
		if (g_currentHealth <= 0) 
		{
			OnDeath ();
			m_defeated = true;
		}

		if (this.gameObject.activeInHierarchy == true) 
		{
			m_AI.AI.WorkingMemory.SetItem ("Health", g_currentHealth);
		} 
	}

	void OnDeath()
	{
		m_portal.SetActive (true);
	}
}
