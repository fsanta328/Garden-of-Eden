using UnityEngine;
using System.Collections;

public class DropInfo : MonoBehaviour 
{
	public int m_itemDropID;
	// Use this for initialization

	public int AssignDrop(int a_drop)
	{
		m_itemDropID = a_drop;
		return m_itemDropID;
	}
}
