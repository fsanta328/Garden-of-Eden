using UnityEngine;
using System.Collections;

public class EnemiesLife : MonoBehaviour {

	private float a_maxHealth = 30f;
	public float g_currentHealth =30;


	// this bool is for future refrence.. we use it if u want to check something after the death of the enemy
	public bool enemyDead = false;


	// Use this for initialization
	void Start () {

		g_currentHealth = a_maxHealth;
	
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
