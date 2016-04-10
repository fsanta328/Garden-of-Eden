using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadLV : MonoBehaviour 
{
	public Text m_textInfo; 
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.anyKey) 
		{
			SceneManager.LoadScene (2);
		}
	}
}
