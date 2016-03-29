using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManger : MonoBehaviour 
{
	public GameObject[] m_gems;
	int index = 0;
	int MaxGems = 2;
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

	//	// Update is called once per frame
	//	void Update () 
	//	{
	//		if ( index >= MaxGems && isLastBossDead == true)
	//			{
	//				Application.LoadLevel("cameraScene");
	//			}	
	//	}

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
			transform.position = new Vector3(25.57f, 1.57f, 475.6f);
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
