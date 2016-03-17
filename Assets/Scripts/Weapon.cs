using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
	public Player m_player;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnCollisionEnter (Collision a_collision)
	{
		Debug.Log ("col");
		if (a_collision.gameObject.tag == "Enemy") 
		{
			Debug.Log (a_collision.gameObject.GetComponent<EnemiesLife> ().g_currentHealth);

			m_player.ApplyDamage (a_collision);
			Debug.Log (a_collision.gameObject.GetComponent<EnemiesLife> ().g_currentHealth);

		}
	}
}
