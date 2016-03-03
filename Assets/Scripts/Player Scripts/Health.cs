using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	private float a_maxHealth = 100f;
	public float g_currentHealth;
	public GameObject healthBar;



	// Use this for initialization
	void Start () 
	{
		g_currentHealth = a_maxHealth;
	}



	public void ApplyDamage()
	{

		g_currentHealth -= 5;
		float calculateHealth = g_currentHealth / a_maxHealth;
		SetHealthBar(calculateHealth);

		if (g_currentHealth <=0)
		{
			Debug.Log("pldplf");
			g_currentHealth = 0f;
		
		}

	}


	public void SetHealthBar(float myHealth)
	{
		// Setting the scale of our image inside the the healthbar Canvas.
		if (g_currentHealth>=0)
		{
			healthBar.transform.localScale = new Vector3 (myHealth , healthBar.transform.localScale.y , healthBar.transform.localScale.x) ;	
		}

	}
}
