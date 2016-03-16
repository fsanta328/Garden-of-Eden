using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject enemy;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// kill zombie :D !!!! 
		if (Input.GetKeyUp(KeyCode.Space))
		{
			GetComponent<EnemiesLife>().ApplyDamage();
		}
	
	}
}
