﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour 
{
	public GameObject[] m_gems;
	int index = 0;
	int MaxGems = 2;
	//private bool isLastBossDead = false;

	public Transform m_arenaPos;
	public Transform m_mapPos;
	public ParticleSystem arena;
	public ParticleSystem Thunder;
	public ParticleSystem Smoke;
	public GameObject boss;
	public AudioClip Background_music;
	private AudioSource bk_source;
	int m_area = 0;

	public Image myPanel;
	float fadingTime = 3f;
	Color colorToFade;
	FadingScript fade;
	public Text c_text;

	void Start()
	{
		myPanel.enabled = false;
		boss.SetActive(false);
		bk_source =GetComponent<AudioSource>();
		fade = GetComponent<FadingScript> ();
	}

	// Update is called once per frame
//	void Update () 
//	{
//		if (index >= MaxGems && blah2.isBossDead == true)
//		{
//			Application.LoadLevel("BonusScene");
//			blah2.isBossDead = false;
//		}	
//
//		else if (blah2.isBossDead == true && index < MaxGems)
//		{
//			Application.LoadLevel("Main Menu");
//			blah2.isBossDead = false;
//		}
//	}

	void OnCollisionEnter(Collision obj)
	{
		if (obj.gameObject.CompareTag ("Crystal"))
		{
			Destroy(obj.gameObject);
			index ++;
			c_text.text = + (int) index + "" ;
		}

		else if (obj.gameObject.CompareTag ("TunnelEnd")) 
		{
			PanelFading();
			//add fade in and out
			transform.position = m_mapPos.position;

		}
	}

	void OnTriggerEnter (Collider obj)
	{
		if (gameObject.CompareTag("Player"))
		{
			if (m_area == 1)
			{
				if (Boss.dead ==1)
				{
					if (index >= MaxGems) 
					{
						SceneManager.LoadScene (3);
					} 

					else
						SceneManager.LoadScene (2);
				}
			}

			else if (m_area == 0)
			{
				transform.position = m_arenaPos.transform.position;
				arena.Play();
				Thunder.Play();
				Smoke.Play();
				bk_source.Play();

				if (Thunder.IsAlive(false))
				{
					boss.SetActive (true);
				}
				m_area = 1;
			}
		}
	}

	public void PanelFading ()
	{
		myPanel.enabled = true;
		colorToFade = new Color (2f, 2f, 2f, 0f);
		myPanel.CrossFadeColor (colorToFade, fadingTime, true, true);

		//myPanel.enabled = false;
	}
}
