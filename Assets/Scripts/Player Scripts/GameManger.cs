using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManger : MonoBehaviour 
{
	public GameObject[] m_gems;
	int index = 0;
	int MaxGems = 10;
	private bool isLastBossDead = false;

	public ParticleSystem arena;
	public ParticleSystem Thunder;
	public ParticleSystem Smoke;




	public GameObject boss;


	public AudioClip Background_music;

	private AudioSource bk_source;

	public Text c_text;

	void Start()
	{
		boss.SetActive(false);

		bk_source =GetComponent<AudioSource>();


	}

		// Update is called once per frame
		void Update () 
		{
			if ( index >= MaxGems && isLastBossDead == true)
				{
					Application.LoadLevel("cameraScene");
				}	

			else if (isLastBossDead == true && index < MaxGems)
			{
				Application.LoadLevel("MainMenu");

			}

		}

	void OnCollisionEnter(Collision obj)
	{
		if (obj.gameObject.CompareTag ("Crystal"))
		{
			Destroy(obj.gameObject);
			index ++;
			c_text.text = + (int) index + "" ;
		}
	}


	void OnTriggerEnter (Collider obj)
	{



		if (gameObject.CompareTag("Player"))
		{
			transform.position = new Vector3(2504.89f, 1.57f, 475.2653f);
			arena.Play();
			Thunder.Play();
			Smoke.Play();
			bk_source.Play();


			if (Thunder.IsAlive(false))
			{
				boss.SetActive (true);
			}

		}
	}
}
