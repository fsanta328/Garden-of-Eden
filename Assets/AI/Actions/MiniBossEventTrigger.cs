using UnityEngine;
using System.Collections.Generic;

public class MiniBossEventTrigger : MonoBehaviour 
{
	public GameObject m_minion;

	public List<AudioSource> m_soundEffects;

	public void InstantiateMinion()
	{
		
		for(int i = 0; i < 2; i++)
		{
			Instantiate (m_minion, new Vector3(transform.position.x+2+i,transform.position.y,transform.position.z+2+i) , Quaternion.identity);
		}
	}

	public void PinkMonsterAudio(int a_audio)
	{
		m_soundEffects [a_audio].Play ();
	}
}
