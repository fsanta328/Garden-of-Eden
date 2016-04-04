using UnityEngine;
using System.Collections;
using RAIN.Core;
using System.Collections.Generic;

public class EventTriggerScript : MonoBehaviour 
{
	public GameObject m_snowBall;
	public Transform m_startingPosition;
	public List<AudioSource> m_soundEffects;

	void Start()
	{
		for (int i = 0; i < 2/*num of sound effects*/; i++)
		{
			m_soundEffects[i] = this.GetComponent<AudioSource> ();
		}
	}

	public void ThrowBall()
	{
		Instantiate (m_snowBall, m_startingPosition.position, Quaternion.identity);
	}

	public void Roar()
	{
		AudioSource a_roar = GetComponent<AudioSource> ();
		a_roar.Play ();
	}

	public void FinalBossAudio(int a_audio)
	{
		m_soundEffects [a_audio].Play ();
	}
}
