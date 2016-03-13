using UnityEngine;
using System.Collections.Generic;

public class TargetLock : MonoBehaviour 
{
	internal List<GameObject> m_targets = new List<GameObject>();

	internal GameObject m_target;

	internal Vector3 m_distance;

	// Use this for initialization
	void Start () 
	{
		foreach (GameObject a_target in GameObject.FindGameObjectsWithTag("Enemy")) 
		{
			m_targets.Add (a_target);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach (GameObject a_target in m_targets) 
		{
			if(a_target.activeInHierarchy == true)
			{
				m_target = a_target;
				m_distance = a_target.transform.position - transform.position;

				break;
			}
			else
			{
				break;
			}
		}

		if(Input.GetKey(KeyCode.D) && m_target.activeInHierarchy == true && m_distance.magnitude <= 5)
		{
			LockOnm_target ();
		}

		else if(Input.GetKeyUp(KeyCode.D) || m_target.activeInHierarchy  == false)
		{
			transform.eulerAngles = new Vector3 (0,transform.eulerAngles.y,0);
		}
	}

	public void LockOnm_target()
	{
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation (m_distance), 10*Time.deltaTime);

		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
		
	}
}
