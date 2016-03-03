using UnityEngine;
using System.Collections;

public class TargetLock : MonoBehaviour 
{
	internal GameObject m_target;

	internal Vector3 m_distance;

	// Use this for initialization
	void Start () 
	{
		m_target = GameObject.FindGameObjectWithTag ("Enemy");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_target.activeInHierarchy == true)
		{
			m_distance = m_target.transform.position - transform.position;
		}

		if(Input.GetKey(KeyCode.D) && m_target.activeInHierarchy == true && m_distance.magnitude <= 5)
		{
			LockOnm_target ();
		}

		else if(Input.GetKeyUp(KeyCode.D) || m_target.activeInHierarchy == false)
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
