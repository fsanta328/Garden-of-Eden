using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesLife : MonoBehaviour 
{
	public float g_currentHealth = 30;
	public List<GameObject> m_drop;
	RAIN.Core.AIRig m_AI;
	//public Inventory m_inventory;

	// this bool is for future refrence.. we use it if u want to check something after the death of the enemy
	private bool enemyDead = false;

	// Use this for initialization
	void Start () 
	{
		m_AI = this.GetComponent<RAIN.Core.AIRig>();
	}

	void Update()
	{
		if (this.gameObject.activeInHierarchy == true) 
		{
			m_AI.AI.WorkingMemory.SetItem("Health",g_currentHealth) ;
		}
		
		float rnd = Random.Range (0, 100);
		if (g_currentHealth <= 0) 
		{
			if (rnd <=60) 
			{
				if (rnd >=30 && rnd <=40)
				{
					Instantiate (m_drop[0], this.transform.position, Quaternion.identity);
					GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
				}

				else if (rnd >40 && rnd <= 50)
				{
					Instantiate (m_drop[1], this.transform.position, Quaternion.identity);
					GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
				}

				else if (rnd >50 && rnd <= 60)
				{
					Instantiate (m_drop[2], this.transform.position, Quaternion.identity);
					GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
				}

				else
				{
					// Remove the destroyed enemy from our list 
					GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
				}
			} 

			else if (rnd <=90 && rnd >60) 
			{
				if (rnd >60 && rnd <=70)
				{
					Instantiate (m_drop[3], this.transform.position, Quaternion.identity);
					GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
				}

				else if (rnd >70 && rnd <= 80)
				{
					Instantiate (m_drop[4], this.transform.position, Quaternion.identity);
					GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
				}

				else if (rnd >80 && rnd <= 90)
				{
					Instantiate (m_drop[5], this.transform.position, Quaternion.identity);
					GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
				}

				else
				{
					// Remove the destroyed enemy from our list 
					GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
				}
			} 

			else if (rnd <=100 && rnd >90) 
			{
				if (rnd >90 && rnd <=95)
				{
					Instantiate (m_drop[6], this.transform.position, Quaternion.identity);
					GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
				}

				else if (rnd >95 && rnd <= 100)
				{
					Instantiate (m_drop[7], this.transform.position, Quaternion.identity);
					GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
				}

				else
				{
					// Remove the destroyed enemy from our list 
					GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
				}
			} 

			else 
			{
				// Remove the destroyed enemy from our list 
				GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
			}
		}
	}
	
	public void ApplyDamage()
	{
		g_currentHealth -= 10;
	}


	void Die()
	{
		//GameObject.Find ("SpawnManager").GetComponent<Spawn>().Remove (gameObject);
		Destroy(gameObject);
	}
}
