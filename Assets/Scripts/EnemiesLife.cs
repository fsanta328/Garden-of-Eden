using UnityEngine;
using System.Collections;

public class EnemiesLife : MonoBehaviour {

	private float a_maxHealth = 30f;
	public float g_currentHealth =120;
	public GameObject m_drop;


	// this bool is for future refrence.. we use it if u want to check something after the death of the enemy
	private bool enemyDead = false;


	// Use this for initialization
	void Start () {

		g_currentHealth = a_maxHealth;
	}

	void Update()
	{
		float rnd = Random.Range (0, 1);
		if (g_currentHealth <= 0) 
		{
			if (rnd == 0) 
			{
				Instantiate (m_drop, this.transform.position, Quaternion.identity);
				GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);

				// Destroy the zombie 
				Destroy (gameObject);
				Debug.Log ("ded");
			} 

			else 
			{
//			if (rnd = 1) 
//			{
//				Instantiate (m_drop, this.transform.position, Quaternion.identity);
//			}
				// Remove the destroyed enemy from our list 
				GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);

				// Destroy the zombie 
				Destroy (gameObject);
				Debug.Log ("ded");
			}

		}
	}

	
	public void ApplyDamage()
	{

		g_currentHealth -= 10;

		// kill the zombie if his health is below zero 
		if ( g_currentHealth <=0 && enemyDead == false)
		{
			// bool to follow up is our enemy is dead or not.
			enemyDead = true;
			
			// Remove the destroyed enemy from our list 
			GameObject.Find ("SpawnManager").GetComponent<Spawn>().Remove (gameObject);

			// Destroy the zombie 
			Destroy(gameObject);
		}
	}


}
