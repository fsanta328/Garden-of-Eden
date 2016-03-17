using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stats : MonoBehaviour 
{
	Player m_player;
	// Use this for initialization
	void Start () 
	{
		m_player = GameObject.FindWithTag ("Player").GetComponent<Player>();
		this.gameObject.GetComponent<Text> ().text = "Attack: " + m_player.m_attack + "\nDefence: " + m_player.m_defence + "\nHealth: " + m_player.m_health;
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.gameObject.GetComponent<Text> ().text = "Attack: " + m_player.m_attack + "\nDefence: " + m_player.m_defence + "\nHealth: " + m_player.m_health;
	}
}
