using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour {

	// canvas for pause and game scene set in engine 
	public Canvas m_gameCanvas;
	public Canvas m_pauseCanvas;

	// audio for the back ground music 
	//public AudioClip Background_music;

	//private AudioSource bk_source;



	bool IsPasued = false;




	void Awake()
	{
		// get component from engine
		//bk_source =GetComponent<AudioSource>();


	}

	// Use this for initialization
	void Start () 
	{
		// at first the pause canvas is set to false
		m_pauseCanvas.enabled = false;





	}

	void Update()
	{
		// call pause function
	//	CheckForPause();


	}



	public void Unpause()
	{

		// disable the canvas 
		m_gameCanvas.GetComponent<GraphicRaycaster>().enabled = true;
		// disable the pause canvas
		m_pauseCanvas.enabled = false;

		// unpause the game
		Time.timeScale = 1;


	//	DisableScript();



		IsPasued = false;

		// return audio
		//bk_source.UnPause();
	}

	public  void Pause()
	{

//		if (Input.GetKey(KeyCode.P) )
//		{

			Time.timeScale = 0;
			//bk_source.Pause();

			// game canvas is set to off
			m_gameCanvas.GetComponent<GraphicRaycaster>().enabled = false;

			// Enable the pause Scene .
			m_pauseCanvas.enabled = true;	

			
		//DisableScript();


		IsPasued = true;
	//	}

//		if (Input.GetKey(KeyCode.R))
//		{
//
//			// game canvas is set to on
//			m_gameCanvas.GetComponent<GraphicRaycaster>().enabled = true;
//
//			//bk_source.UnPause();
//
//			// Disables the pause Canvas. 
//			m_pauseCanvas.enabled = false;
//
//			Time.timeScale = 1;
//		}


	}

//	void DisableScript()
//	{
//		GameObject followTargetScriptClass = GameObject.Find("MainCamera");
//		GameObject PlayerScriptClass = GameObject.Find("Berserker");
//
//		if (IsPasued)
//		{
//
//			followTargetScriptClass.GetComponentInChildren<followTarget>().enabled = false;
//			PlayerScriptClass.GetComponent<Player>().enabled = false;
//		}
//
//		if (IsPasued == false)
//		{
//
//			followTargetScriptClass.GetComponentInChildren<followTarget>().enabled = true;
//			PlayerScriptClass.GetComponent<Player>().enabled = true;
//		}
//	}
}
