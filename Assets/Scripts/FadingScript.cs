using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadingScript : MonoBehaviour {


	public Image myPanel;
	float fadingTime = 3f;
	Color colorToFade;

	bool isPenelEnabled = true;


	// Use this for initialization
	void Update () {


		PanelFading();
	
	}

	public void PanelFading ()
	{
		// Create a timer and called function in update instead of start because the panel was 
		// above the UI buttons therefore pressing them wasn't possible.. This need to be optimized
		// Because calling this function on update is useless.
		fadingTime -= Time.deltaTime;
		colorToFade = new Color (2f, 2f, 2f, 0f);
		myPanel.CrossFadeColor (colorToFade, fadingTime, true, true);
		isPenelEnabled = true;

		if (fadingTime <= 0)
		{
			myPanel.enabled = false;
			isPenelEnabled = false;
			fadingTime = 5;
		}

		else if (fadingTime >= 0)
		{
			isPenelEnabled = true;
		}
	}
	

}
