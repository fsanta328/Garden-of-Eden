using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {


	// The enemy prefab to be spawned.
	public GameObject[] enemy; 

	 
	public Transform[] spawnPoints;         

	private float timer = 3;



	int index = 0 ;

	public int m_numberOfSpawn = 0;

	List <GameObject> EnemiesList = new List<GameObject>();

	private int m_enemyCount = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if (timer >0)
		{
			timer -= Time.deltaTime;

		}
		if (timer <= 0 )
		{
			// If all of our enemies are dead, respawn after 5 seconds.
			if ( EnemiesList.Count == 0 )
			{
				EnemySpawner();	
				timer = 5;

			}

		}

//		// On wave 3 (can be changed just for example used "3") and our list is empty ( all of the enemies are destroyed) 
//		else if ( m_numberOfSpawn >=3 && EnemiesList.Count == 0 )
//		{
//			// if you want stop spawning enemies.
//
//
//		}
	
	}


	void EnemySpawner ()
	{
		// Create an instance of the enemy prefab at the randomly selected spawn point's position.
		//Create the enemies at a random transform 
		for (int i = 0; i<m_enemyCount;i++)
		{
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);

			GameObject InstanceEnemies= Instantiate ( enemy[index] , spawnPoints[spawnPointIndex].position , Quaternion.identity) as GameObject;

			// Create enemies and add them to our list.
			EnemiesList.Add(InstanceEnemies);

		}

		m_numberOfSpawn++;



	}

	public void Remove (GameObject anything)
	{
		// Remove the enemy from the list when he is dead.
		EnemiesList.Remove (anything);
	}


		

}
