using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void Play (string PlayScene) {
		
		Application.LoadLevel (PlayScene);
	}
	
	public void Credits (string CreditScene)
	{
		Application.LoadLevel (CreditScene);
	}
	
	public void Exit ()
	{
		Application.Quit();
	}
	
	public void Bonus (string BonusScene)
	{
		Application.LoadLevel (BonusScene);
	}
	

	public void Back (string GameScene)
	{
		Application.LoadLevel (GameScene);
	}
}
