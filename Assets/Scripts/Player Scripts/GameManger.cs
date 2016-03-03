using UnityEngine;
using System.Collections.Generic;

public class GameManger : MonoBehaviour 
{
	public GameObject[] m_gems;
	int index = 0;
	int MaxGems = 2;
	private bool isLastBossDead = false;

	// Update is called once per frame
	void Update () 
	{
		if ( index >= MaxGems && isLastBossDead == true)
			{
				Application.LoadLevel("cameraScene");
			}	
	}

	void OnTriggerEnter (Collider obj)
	{
		if (obj.gameObject.tag == "gem")
		{
			Destroy(obj.gameObject);
			index ++;
		}
	}
}
