using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
	private Item m_item;
	private string m_data;
	private GameObject m_toolTip;

	void Start () 
	{
		m_toolTip = GameObject.Find("ToolTip");
		m_toolTip.SetActive (false);
	}

	void Update () 
	{
		if (m_toolTip.activeSelf) 
		{
			m_toolTip.transform.position = Input.mousePosition;
		}
	}

	public void Activate(Item a_item)
	{
		m_item = a_item;
		BuildData();
		m_toolTip.SetActive (true);
	}

	public void Deactivate()
	{
		m_toolTip.SetActive (false);
	}

	public void BuildData()
	{
		m_data = "<color=#0473f0><b>" + m_item.m_title + "</b></color>\n\n" + m_item.m_description + "\nAttack: " + m_item.m_attack
										+ "\nDefence: " + m_item.m_defence + "\nHealth: " + m_item.m_health;
		m_toolTip.transform.GetChild (0).GetComponent<Text> ().text = m_data;
	}
}
