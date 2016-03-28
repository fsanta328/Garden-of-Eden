using UnityEngine;
using System.Collections;
using RAIN.Core;

public class EventTriggerScript : MonoBehaviour 
{
	public GameObject m_snowBall;
	public Transform m_startingPosition;

	public void ThrowBall()
	{
		Instantiate (m_snowBall, m_startingPosition.position, Quaternion.identity);
	}

	public void Roar()
	{
		AudioSource a_roar = GetComponent<AudioSource> ();

		a_roar.Play ();
	}
}
