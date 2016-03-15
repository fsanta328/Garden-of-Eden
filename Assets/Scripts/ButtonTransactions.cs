using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTransactions : MonoBehaviour {

	// Use this for initialization
	public void ChangeScene (string sceneChange) 
	{
		Application.LoadLevel(sceneChange);
	
	}
	
	public void TogglePanel (GameObject panel) 
	{
		panel.SetActive (!panel.activeSelf);

	}

	public void TogglePauseMenu()
	{
		if () 
		{

		}
	}
}