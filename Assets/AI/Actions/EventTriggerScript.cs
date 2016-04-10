using UnityEngine;
using System.Collections;
using RAIN.Core;
using System.Collections.Generic;

public class EventTriggerScript : MonoBehaviour 
{
	public GameObject m_fireBall;
	public GameObject m_particles, m_fireParticles;
	public Transform m_startingPosition;
	public List<AudioSource> m_soundEffects;

	public void ThrowBall()
	{
		Instantiate (m_fireBall, m_startingPosition.position, Quaternion.identity);
	}

	public void FinalBossAudio(int a_audio)
	{
		m_soundEffects [a_audio].Play ();
	}

	public void Fade(int a_activater)
	{
		Rigidbody a_rb = GetComponent<Rigidbody> ();

		a_rb.constraints = RigidbodyConstraints.FreezeAll;

		if(a_activater >= 1)
		{
			m_particles.SetActive (true);
		}	
		else
		{
			m_particles.SetActive (false);
		}

		m_fireParticles.SetActive (false);

	}

	public void Dead()
	{
		m_soundEffects [0].Stop ();
		Destroy (gameObject);
	}
}
