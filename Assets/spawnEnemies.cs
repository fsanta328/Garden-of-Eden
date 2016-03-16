using UnityEngine;
using System.Collections.Generic;

public class spawnEnemies : MonoBehaviour
{
	// The enemy prefab to be spawned.
	public GameObject[] enemy; 

	// How long between each spawn.
	public float spawnTime = 30f;            
	public Transform[] spawnPoints;         

	private float timer = 5;


	int index = 0 ;



	List <GameObject> EnemiesList = new List<GameObject>();

	private int m_enemyCount = 5;

	void Update()
	{

		timer -= Time.deltaTime;

		if (timer <= 0  )
		{
			timer = 5;

			Spawn();

		}
			


	}

	void Spawn ()
	{

		// Spawn enemies, number of enemies is defined in the enemyCount Integer.
		for (int i = 0; i<m_enemyCount;i++)
		{
			Invoke("EnemySpawner" , 3);
		}
	}

	void EnemySpawner ()
	{
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		//Create the enemies at a random transform 
		GameObject InstanceEnemies= Instantiate ( enemy[index] , spawnPoints[spawnPointIndex].position , spawnPoints[spawnPointIndex].rotation) as GameObject;

		// Create enemies and add them to our list.
		EnemiesList.Add(InstanceEnemies);

	}

	public void Remove (GameObject anything)
	{
		// Remove the enemy from the list when he is destroyed.
		EnemiesList.Remove (anything);
		Debug.Log("im happeing");
	}


}