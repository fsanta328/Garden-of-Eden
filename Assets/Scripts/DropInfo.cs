using UnityEngine;
using System.Collections;

public class DropInfo : MonoBehaviour 
{
	public int m_itemDropID;
	// Use this for initialization
	void Start () 
	{
	
	}

	public int AssignDrop(int a_drop)
	{
		m_itemDropID = a_drop;
		return m_itemDropID;
	}
}
