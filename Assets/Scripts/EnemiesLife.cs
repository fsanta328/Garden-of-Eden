using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesLife : MonoBehaviour 
{
	public float g_currentHealth = 30;
	int m_dropLimit = 2;

	public GameObject m_itemDrop;
	public List<AudioSource> m_audio;
	RAIN.Core.AIRig m_AI;
	public DropInfo m_dropInfo;
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
	}

	public void ItemRoll()
	{
		int m_dropCount = 0;
		float rnd = Random.Range (0, 100);
		if (g_currentHealth <= 0) 
		{
			if (m_dropCount < m_dropLimit)
			{
				if (rnd <=60) 
				{
					if (rnd >=30 && rnd <=40)
					{
						GetInfo ();
						Instantiate (m_itemDrop, this.transform.position, Quaternion.identity);
						m_dropInfo.m_itemDropID = 0;
						//Instantiate (m_drop[0], this.transform.position, Quaternion.identity);
						GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
						m_dropCount++;
					}

					else if (rnd >40 && rnd <= 50)
					{
						GetInfo ();
						Instantiate (m_itemDrop, this.transform.position, Quaternion.identity);
						m_dropInfo.m_itemDropID = 1;
						//Instantiate (m_drop[1], this.transform.position, Quaternion.identity);
						GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
						m_dropCount++;

					}

					else if (rnd >50 && rnd <= 60)
					{
						GetInfo ();

						Instantiate (m_itemDrop, this.transform.position, Quaternion.identity);
						m_dropInfo.m_itemDropID = 2;
						//Instantiate (m_drop[2], this.transform.position, Quaternion.identity);
						GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
						m_dropCount++;

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
						GetInfo ();

						Instantiate (m_itemDrop, this.transform.position, Quaternion.identity);
						m_dropInfo.m_itemDropID = 3;
						//Instantiate (m_drop[3], this.transform.position, Quaternion.identity);
						GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
						m_dropCount++;

					}

					else if (rnd >70 && rnd <= 80)
					{
						GetInfo ();

						Instantiate (m_itemDrop, this.transform.position, Quaternion.identity);
						m_dropInfo.m_itemDropID = 4;
						//Instantiate (m_drop[4], this.transform.position, Quaternion.identity);
						GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
						m_dropCount++;

					}

					else if (rnd >80 && rnd <= 90)
					{
						GetInfo ();

						Instantiate (m_itemDrop, this.transform.position, Quaternion.identity);
						m_dropInfo.m_itemDropID = 5;
						//Instantiate (m_drop[5], this.transform.position, Quaternion.identity);
						GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
						m_dropCount++;

					}

					else
					{
						// Remove the destroyed enemy from our list 
						GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
						m_dropCount++;

					}
				} 

				else if (rnd <=100 && rnd >90) 
				{
					if (rnd >90 && rnd <=95)
					{
						GetInfo ();

						Instantiate (m_itemDrop, this.transform.position, Quaternion.identity);
						m_dropInfo.m_itemDropID = 6;
						//Instantiate (m_drop[6], this.transform.position, Quaternion.identity);
						GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
						m_dropCount++;

					}

					else if (rnd >95 && rnd <= 100)
					{
						GetInfo ();

						Instantiate (m_itemDrop, this.transform.position, Quaternion.identity);
						m_dropInfo.m_itemDropID = 7;
						//Instantiate (m_drop[7], this.transform.position, Quaternion.identity);
						GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
						m_dropCount++;

					}

					else
					{
						// Remove the destroyed enemy from our list 
						GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
						m_dropCount++;

					}
				} 

				else 
				{
					// Remove the destroyed enemy from our list 
					GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);
				}
			}
		}
	}
	
	public void ApplyDamage()
	{
		g_currentHealth -= 10;
	}

	public void GetInfo()
	{
		m_dropInfo = m_itemDrop.gameObject.GetComponent<DropInfo> ();
	}

	void Die()
	{
		
		Destroy(gameObject);
	}
	
	void AudioEffect(int a_audio)
	{
		m_audio [a_audio].Play();
	}
}
