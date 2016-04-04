using UnityEngine;
using System.Collections;

public class EnemiesLife : MonoBehaviour {

	private float a_maxHealth = 30f;
	public float g_currentHealth = 120;
	public GameObject m_drop;
	public GameObject m_drop1;
	public GameObject m_drop2;
	//public Inventory m_inventory;

	// this bool is for future refrence.. we use it if u want to check something after the death of the enemy
	private bool enemyDead = false;


	// Use this for initialization
	void Start () 
	{
		g_currentHealth = a_maxHealth;
	}

	void Update()
	{
		float rnd = Random.Range (0, 3);
		if (g_currentHealth <= 0) 
		{
			if (rnd == 0) 
			{
				Instantiate (m_drop, this.transform.position, Quaternion.identity);
				GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);

				// Destroy the zombie 
				Destroy (gameObject);
			} 

			else if (rnd == 1) 
			{
				Instantiate (m_drop1, this.transform.position, Quaternion.identity);
				GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);

				// Destroy the zombie 
				Destroy (gameObject);
			} 

			else if (rnd == 2) 
			{
				Instantiate (m_drop2, this.transform.position, Quaternion.identity);
				GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);

				// Destroy the zombie 
				Destroy (gameObject);
			} 

			else 
			{
				// Remove the destroyed enemy from our list 
				GameObject.Find ("SpawnManager").GetComponent<Spawn> ().Remove (gameObject);

				// Destroy the zombie 
				Destroy (gameObject);
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
