using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour 
{
	public void LoadLevel(string name)
	{
		Application.LoadLevel(name);
		Time.timeScale = 1;
	}
    
    public void Quit()
    {
        Application.Quit();
    }
}