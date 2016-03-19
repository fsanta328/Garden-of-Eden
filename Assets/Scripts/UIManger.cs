﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UIManger : MonoBehaviour {

	// canvas for pause and game scene set in engine 
	public Canvas m_gameCanvas;
	public Canvas m_pauseCanvas;
	public Canvas m_helpCanas;

	// audio for the back ground music 
	//public AudioClip Background_music;

	//private AudioSource bk_source;

	bool IsPasued = false;
	bool isHelpOpend = false;





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
		m_helpCanas.enabled = false;





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


		IsPasued = false;

		// return audio
		//bk_source.UnPause();
	}

	public  void Pause()
	{
		if (isHelpOpend == false)
		{
			
		
			Time.timeScale = 0;
			//bk_source.Pause();

			// game canvas is set to off
			m_gameCanvas.GetComponent<GraphicRaycaster>().enabled = true;

			// Enable the pause Scene .
			m_pauseCanvas.enabled = true;	

			
			IsPasued = true;
		}

	}

	public void OpenHelpCanvas()
	{
		if (IsPasued == false)
		{
			m_gameCanvas.GetComponent<GraphicRaycaster>().enabled = true;
			m_helpCanas.enabled = true;
			isHelpOpend = true;
		}


	


	}

	public void CloseHelpCanvas()
	{
		m_gameCanvas.GetComponent<GraphicRaycaster>().enabled = true;
		m_helpCanas.enabled = false;
		isHelpOpend = false;


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